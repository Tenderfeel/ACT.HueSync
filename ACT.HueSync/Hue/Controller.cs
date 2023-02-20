using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Advanced_Combat_Tracker;
using RestSharp;
using System.Security.Cryptography.X509Certificates;

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
        public HueErrorResponse Error { get; set; }

        [JsonPropertyName("success")]
        public RegisterSuccess Success { get; set; }
    }

    internal class Controller
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

        public async Task<List<RegisterResponse>> RegistApp(string ipAddress)
        {
            try
            {
                // PEM形式のCA証明書を読み込む
                X509Certificate2Collection certs = new X509Certificate2Collection();

                var client = new RestClient($"https://{ipAddress}");
                var request = new RestRequest("/api", Method.Post);
                var param = new { devicetype = $"ActHueSync#{Environment.MachineName}" };
                request.AddJsonBody(param);

                var result = await client.PostAsync<List<RegisterResponse>>(request);

                Console.WriteLine(result);

                return result;
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }
    }
}
