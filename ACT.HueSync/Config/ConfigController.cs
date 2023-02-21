using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using Advanced_Combat_Tracker;

namespace ACT.HueSync.Config
{
    internal class ConfigController
    {
        readonly ConfigForm configForm;


        public ConfigController(string pluginDirectory)
        {

            configForm = new ConfigForm(pluginDirectory);
        }


        public void AddPluginControls(TabPage pluginScreenSpace)
        {
            pluginScreenSpace.Controls.Add(configForm);
        }

        public void AddControlSetting(SettingsSerializer xmlSettings)
        {
            // Add any controls you want to save the state of
            xmlSettings.AddControlSetting(configForm.BridgeId.Name, configForm.BridgeId);
            xmlSettings.AddControlSetting(configForm.IpAddress.Name, configForm.IpAddress);
            xmlSettings.AddControlSetting(configForm.HueAppKey.Name, configForm.HueAppKey);

            configForm.SearchInfo.Text = configForm.GetSearchInfoText();

        }
    }
}
