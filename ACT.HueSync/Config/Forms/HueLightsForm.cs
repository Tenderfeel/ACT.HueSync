using ACT.HueSync.Hue;
using Advanced_Combat_Tracker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ACT.HueSync.Config.Forms
{
    public partial class HueLightsForm : UserControl, IConfigForm
    {
        readonly Hue.HueController hueController;

        private bool _isEmptyConfig;



        public HueLightsForm()
        {
            InitializeComponent();

            hueController = Hue.HueController.Instance;

        }


        /// <summary>
        /// 設定機能を追加する
        /// </summary>
        /// <param name="xmlSettings">ACTのSettingsSerializer</param>
        public void AddControlSetting(SettingsSerializer xmlSettings)
        {
            xmlSettings.AddControlSetting(List_HueLights.Name, List_HueLights);
        }

        public void AfterSettingLoaded()
        {

            _isEmptyConfig = List_HueLights.Items.Count == 0;

            GetHueLights();
        }

        private  void HueLightsForm_Load(object sender, EventArgs e)
        {
            if (List_HueLights.Items.Count == 0)
            {
                GetHueLights();
            }
        }

        private async void GetHueLights()
        {
            ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights Called.");

            if (hueController.IpAddress == null)
            {
                Label_GetLightsState.Text = "IP address is not set.";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, IP address is not set.");
                return;
            }

            if (hueController.BridgeId == null)
            {
                Label_GetLightsState.Text = "Bridge ID is not set.";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, Bridge ID is not set.");
                return;
            }

            Label_GetLightsState.Text = "Loading...";

            var result = await hueController.GetAllLights();

            if (result == null)
            {
                Label_GetLightsState.Text = "Error!";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, result is null.");
                return;
            }

            Label_GetLightsState.Text = $"{result.Count} found.";

            var lightConfigs = new List<LightConfig>();

            foreach (var item in result)
            {
                bool isEnabled = false;

                if (!_isEmptyConfig)
                {
                    var index = List_HueLights.Items.IndexOf($"({item.Key}) {item.Value.Name}");
                    if (index != -1)
                    {
                        isEnabled = List_HueLights.GetItemChecked(index);
                    }
                }
                else
                {
                    List_HueLights.Items.Add($"({item.Key}) {item.Value.Name}", CheckState.Unchecked);

                }

                lightConfigs.Add(
                    new LightConfig()
                    {
                        Enabled = isEnabled,
                        Id = item.Key,
                        Power = item.Value.State.On,
                        Name = item.Value.Name,
                        Uniqueid = item.Value.Uniqueid,
                        ProductName = item.Value.Productname
                    }
                );

            }

            hueController.LightConfigs = lightConfigs;
        }
    }
}
