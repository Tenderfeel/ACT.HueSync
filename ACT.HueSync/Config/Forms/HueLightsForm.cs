using ACT.HueSync.Hue;
using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        private List<LightConfig> lightConfigs;

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


        private  void HueLightsForm_Load(object sender, EventArgs e)
        {

            _isEmptyConfig = List_HueLights.Items.Count == 0;

            GetHueLights();

        }

        private async void GetHueLights()
        {
            if (hueController.IpAddress == null)
            {
                Label_GetLightsState.Text = "IP address is not set.";
                return;
            }

            if (hueController.BridgeId == null)
            {
                Label_GetLightsState.Text = "Bridge ID is not set.";
            }

            Label_GetLightsState.Text = "Loading...";

            var result = await hueController.GetAllLights();

            if (result == null)
            {
                Label_GetLightsState.Text = "Error!";

                return;
            }

            Label_GetLightsState.Text = $"{result.Count} found.";

            lightConfigs = result.Select(kv =>
            {
                if (_isEmptyConfig)
                {
                    List_HueLights.Items.Add($"{kv.Value.Name}   ({kv.Value.Uniqueid})", CheckState.Unchecked);
                }
                    
                return new LightConfig()
                {
                    Enabled = false,
                    Power = kv.Value.State.On,
                    Name = kv.Value.Name,
                    Uniqueid = kv.Value.Uniqueid,
                    ProductName = kv.Value.Productname
                };
            })
            .ToList();
        }
    }
}
