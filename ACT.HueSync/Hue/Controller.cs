using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Advanced_Combat_Tracker;
using RestSharp;
using HueApi.BridgeLocator;

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
        /// <summary>
        /// Find the IP address of the Hue Bridge using RestSharp's RestClient.
        /// </summary>
        /// <returns>BridgeID and IpAddress list</returns>
        public async Task<List<HueBridgeInfo>> SearchHueBridge()
        {

            ActGlobals.oFormActMain.WriteInfoLog("SearchHueBridge!");

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
        /// Find the IP address of the Hue Bridge using the HueAPI MdnsBridgeLocator.
        /// </summary>
        /// <returns>BridgeID and IpAddress list</returns>
        public async Task<List<HueBridgeInfo>> SearchHueBridgeMdns()
        {
            ActGlobals.oFormActMain.WriteInfoLog("SearchHueBridgeMdns!");

            try
            {
                var locator = new MdnsBridgeLocator();
                var timeout = TimeSpan.FromSeconds(30);
                var bridges = await locator.LocateBridgesAsync(timeout);

                if (bridges == null)
                {
                    return null;
                }

                var results = new List<HueBridgeInfo>();

                //return bridges.ToList();
                foreach (var bridge in bridges)
                {
                    results.Add(new HueBridgeInfo { ID = bridge.BridgeId, IpAddress = bridge.IpAddress });
                }

                return results;

            } catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);
                return null;
            }
        }
    }
}
