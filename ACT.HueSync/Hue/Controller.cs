using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Advanced_Combat_Tracker;
using RestSharp;

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
    }
}
