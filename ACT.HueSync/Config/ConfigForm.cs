using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Windows.Forms;

namespace ACT.HueSync
{
    public partial class ConfigForm : UserControl
    {

        readonly Hue.HueController hueController;
        public ConfigForm()
        {
            InitializeComponent();
            hueController = Hue.HueController.Instance;
            this.Dock= DockStyle.Fill;

            hueController.ConfigLoaded += HandleLightsConfigLoaded;
        }

        private async void Btn_Enabled_Click(object sender, EventArgs e)
        {
            /*
            Label_Status.Text = "Loading..";

            var param = PluginSetting.Instance.GetLightState();

            var result = await hueController.SetLightState(param);
            Label_Status.Text = "";

            if (result == null || result.Length < 0)
            {
                Label_Status.Text = "No Response or Error";
                return;
            }

            for (var i = 0; i < result.Length; i++)
            {
                Label_Status.Text += "\n";

                result[i].ForEach(response =>
                {
                    if (response.Success != null)
                    {
                        Label_Status.Text += $"{i} Success";
                        Label_Status.Text += "\n";
                    }
                    else
                    {
                        Label_Status.Text += $"{response.Error.Type} {response.Error.Description}";
                        Label_Status.Text += "\n";
                    }

                });
            }

            */
            
        }

        private void HandleLightsConfigLoaded( object sender, EventArgs e)
        {
            /*
            var param = PluginSetting.Instance.GetLightState();
            Label_Status.Text = PluginSetting.Instance.TimeZone;

            if (param != null)
            {
                Label_Status.Text += param.ToString();
            }*/
            
        }
    }
}
