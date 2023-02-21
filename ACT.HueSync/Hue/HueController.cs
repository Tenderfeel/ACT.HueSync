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

namespace ACT.HueSync.Hue
{
    public class HueBridgeInfo
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("internalipaddress")]
        public string IpAddress { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class RestError
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class HueErrorResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }
    }

    public class RegisterSuccess
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }

    public class RegisterResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }

        [JsonPropertyName("success")]
        public RegisterSuccess Success { get; set; }
    }


    public class RegisterResult
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }

    internal class HueController
    {
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

        public async Task<RegisterResult> RegistApp(string bridgeId, string ipAddress)
        {
            try
            {
                // HueBridgeの証明書を読み込む
                string huebridgeCacert = Properties.Resources.HuebridgeCacert;
                byte[] certificateBytes = Encoding.ASCII.GetBytes(huebridgeCacert);
                X509Certificate2 certificate = new X509Certificate2(certificateBytes);
                X509Certificate2Collection certificateCollection = new X509Certificate2Collection
                {
                    certificate
                };


                var options = new RestClientOptions(new Uri($"https://{ipAddress}"))
                {
                    ClientCertificates = certificateCollection,
                   RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                   {
                       // CN=ecb5fafffe82eea0, O=Philips Hue, C=NL
                       ActGlobals.oFormActMain.WriteInfoLog($"[RegistApp response] {cert.Subject}");
                       return cert.Subject.Contains(bridgeId);
                   }
                };

                var client = new RestClient(options);

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
