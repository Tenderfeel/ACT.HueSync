using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Advanced_Combat_Tracker;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Runtime.InteropServices;
using System.Linq;

namespace ACT.HueSync.Hue
{

    internal sealed class HueController
    {

        private static HueController instance = null;
        private static readonly object padlock = new object();


        private string _bridgeId;
        private string _ipAddress;
        private string _appKey;

        private List<LightConfig> _lightConfigs;
        public event EventHandler ConfigLoaded;

        HueController()
        {
        }

        public static HueController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HueController();
                    }
                    return instance;
                }
            }
        }

        public string BridgeId
        {
            get { return _bridgeId; }

            set { _bridgeId = value; }
        }

        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        public string AppKey
        {
            get { return _appKey; }
            set { _appKey = value; }   
        }

        public List<LightConfig> LightConfigs
        {
            get { return _lightConfigs;  }
            set { _lightConfigs = value;

                ConfigLoaded.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// ライト名からIDを返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetLightIdbyName(string name)
        {
           var config = LightConfigs.Find(x => x.Name == name);

            if (config != null)
            {
                return config.Id;
            }

            return null;
        }


        /// <summary>
        /// Bridgeに接続されている全ての照明機器を返す
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, HueLight>> GetAllLights()
        {
            ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetAllLights!");

            try
            {
                var client = RestClientFactory();
                var request = new RestRequest($"/api/{_appKey}/lights", Method.Get);
                var responses = await client.GetAsync<Dictionary<string, HueLight>>(request);

                if (responses.Count == 0)
                {
                    return null;
                }
                return responses;

            } catch(Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Enabledがtrueに設定されている全ライトのステータスを取得する
        /// </summary>
        /// <returns></returns>
        public async Task<HueLight[]> GetLightState()
        {
            if (_lightConfigs == null || _lightConfigs.Count == 0)
            {
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetLightState: NO Lights Setting");
                return null;
            }

            try
            {
                var client = RestClientFactory();
                var enabledConfigs = _lightConfigs.Where(config => config.Enabled).ToArray();
                // Taskだとエラーがでる
                //var tasks = new Task<HueLight>[enabledConfigs.Length];
                var result = new HueLight[enabledConfigs.Length];

                for (var i = 0; i < enabledConfigs.Length; i++)
                {
                    // var request = new RestRequest($"/api/{_appKey}/lights/{enabledConfigs[i].Id}", Method.Get);
                    //tasks[i] = client.GetAsync<HueLight>(request);
                    result[i] = await client.GetJsonAsync<HueLight>($"/api/{_appKey}/lights/{enabledConfigs[i].Id}");

                }

                //return await Task.WhenAll(tasks);
               return result;

            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ライトのステータスを設定する
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<PutResponse>[]> SetLightState(object param)
        {
            if (_lightConfigs == null || _lightConfigs.Count == 0)
            {
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] SetLightState: NO Lights Setting");
                return null;
            }

            if (param == null)
            {

                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] SetLightState: NO Params");
                return null;
            }

            try
            {
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] SetLightState: Request " + param.ToString());

                var client = RestClientFactory();

                var enabledConfigs = _lightConfigs.Where(config => config.Enabled).ToArray();

                var tasks = new Task<List<PutResponse>>[enabledConfigs.Length];
                

                for (var i = 0; i < enabledConfigs.Length; i++)
                {
                    var request = new RestRequest($"/api/{_appKey}/lights/{enabledConfigs[i].Id}/state", Method.Put);
                    
                    request.AddJsonBody(param);
                    tasks[i] = client.PutAsync<List<PutResponse>>(request);
                }

                return await Task.WhenAll(tasks);

            }
            catch (Exception ex)
            {

                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// https://discovery.meethue.comを利用してHue Bridgeを探す
        /// </summary>
        /// <returns></returns>
        public async Task<List<HueBridgeInfo>> SearchHueBridge()
        {

            ActGlobals.oFormActMain.WriteInfoLog("GetDataAsync!");

            try
            {
                var client = new RestClient("https://discovery.meethue.com");
                var request = new RestRequest("/");
                var result = await client.GetAsync<List<HueBridgeInfo>>(request);

                return result;
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 証明書付きのRestClientを生成する
        /// </summary>
        /// <returns></returns>
        private RestClient RestClientFactory()
        {
            // HueBridgeの証明書を読み込む
            string huebridgeCacert = Properties.Resources.HuebridgeCacert;
            byte[] certificateBytes = Encoding.ASCII.GetBytes(huebridgeCacert);
            X509Certificate2 certificate = new X509Certificate2(certificateBytes);
            X509Certificate2Collection certificateCollection = new X509Certificate2Collection
                {
                    certificate
                };

            var options = new RestClientOptions(new Uri($"https://{_ipAddress}"))
            {
                ClientCertificates = certificateCollection,
                RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return cert.Subject.Contains(_bridgeId);
                }
            };

            return new RestClient(options);

        }

        /// <summary>
        /// Bridgeにアプリを登録する
        /// </summary>
        /// <returns></returns>
        public async Task<RegisterResult> RegistApp()
        {
            try
            {

                var client = RestClientFactory();

                var request = new RestRequest("/api", Method.Post);
                var param = new { devicetype = $"ActHueSync#{Environment.MachineName}" };
                request.AddJsonBody(param);

                var responses = await client.PostAsync<List<RegisterResponse>>(request);

                if (responses.Count == 0)
                {
                    return new RegisterResult { Type = "error", Message = "NO_RESULT" };
                }

                var response = responses[0];

                ActGlobals.oFormActMain.WriteInfoLog($"[RegistApp response] {response}");

                if (response.Error != null)
                {
                    if (response.Error.Type == 101)
                    {
                        return new RegisterResult { Type = "error", Message = "LINK_BUTTON_PRESS" };
                    } else
                    {
                        return new RegisterResult { 
                            Type = "error", 
                            Message = $"UNKNOWN_{response.Error.Type} {response.Error.Description}" 
                        };
                    }
                }

                if (response.Success != null)
                {
                    return new RegisterResult { Type =  "success", Message = response.Success.Username };
                }

                return null;
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, $"[RegistApp Error] {ex.Message}");
                return null;
            }
        }
    }
}
