﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using ACT.HueSync.Config.Forms;
using Advanced_Combat_Tracker;

namespace ACT.HueSync.Config
{
    internal class ConfigController
    {
        readonly ConfigForm configForm;
        readonly HueInitializeForm hueInitializeForm;
        readonly HueLightsForm hueLightsForm;


        public ConfigController(string pluginDirectory)
        {

            hueInitializeForm = new HueInitializeForm();
            hueLightsForm = new HueLightsForm();
            configForm = new ConfigForm();

            configForm.Tree_MainMenu.AfterSelect += Tree_MainMenu_AfterSelect;
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tree_MainMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            configForm.Panel_Content.Controls.Clear();
            configForm.Panel_Content.Visible = true;

            switch (configForm.Tree_MainMenu.SelectedNode.Name)
            {
                case "Hue_Initialize":
                    configForm.Panel_Content.Controls.Add(hueInitializeForm);
                    break;

                case "Hue_Lights":
                    configForm.Panel_Content.Controls.Add(hueLightsForm);
                    break;

                default:
                    configForm.Panel_Content.Visible = false;
                    break;
            }
        }

        public void AddPluginControls(TabPage pluginScreenSpace)
        {
            // ACTプラグインタブパネルに登録
            pluginScreenSpace.Controls.Add(configForm);
        }

        /// <summary>
        /// サブクラスにSettingsSerializerを渡す
        /// </summary>
        /// <param name="xmlSettings"></param>
        public void AddControlSetting(SettingsSerializer xmlSettings)
        {
            hueInitializeForm.AddControlSetting(xmlSettings);
            hueLightsForm.AddControlSetting(xmlSettings);
        }
    }
}
