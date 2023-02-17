using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace ACT.HueSync
{
    internal class HueSyncMain
    {
        private readonly string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ActHueSync.config.xml");

        SettingsSerializer xmlSettings;

        readonly ConfigForm configForm;
        readonly ListBox log; // for log display
        readonly OverlayForm overlay; // overlay window

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        TabPage pluginScreen; 

        public HueSyncMain() {
            configForm = new ConfigForm();

            // List box for log display
            log = new ListBox
            {
                Dock = DockStyle.Bottom,
                Height = 250
            };

            // Overlay Mini Window
            overlay = new OverlayForm();
            overlay.Controls.Add(log);
        }

        /// <summary>
        /// プラグインが有効化されたときにInitPluginから呼び出される
        /// </summary>
        /// <param name="pluginScreenSpace">プラグインのタブページ</param>
        /// <param name="pluginStatusText">プラグインのステータステキスト</param>
        public void Init(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;
            pluginScreen = pluginScreenSpace;

            pluginScreen.Text = "HueSync";
            pluginScreen.Controls.Add(configForm);

            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();

            overlay.Show();

            // Every time a log line is read
            ActGlobals.oFormActMain.BeforeLogLineRead += OnBeforeLogLineRead;

            // 起動時のゾーンを得る
            Log(ActGlobals.oFormActMain.CurrentZone);

            Log("Plugin Started.");
        }

        public void DeInit()
        {
            SaveSettings();
            overlay.Close();

            // Unsubscribe
            ActGlobals.oFormActMain.BeforeLogLineRead -= OnBeforeLogLineRead;
        }

        private void OnBeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

            var log = logInfo.logLine; // The full log line
            var zone = logInfo.detectedZone;
            var type = logInfo.detectedType;
            var time = logInfo.detectedTime;

            // 40:ChangeMap 
            if (type == 40 || type == 1)
            {
                Log(log + " --[zone]: " + zone + " --[type]: " + type + " --[time]: " + time);
            }
        }

        /// <summary>
        /// Add a new item to the ListBox for Log
        /// </summary>
        private void Log(string format, params object[] args)
        {
            log.Items.Add(DateTime.Now.ToString() + " | " + string.Format(format, args));
        }


        /// <summary>
        /// プラグイン設定をロードする
        /// </summary>
        private void LoadSettings()
        {
            // Add any controls you want to save the state of
            xmlSettings.AddControlSetting(configForm.textBox1.Name, configForm.textBox1);

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
        }

        /// <summary>
        /// プラグイン設定を保存する
        /// </summary>
        private void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 1,
                IndentChar = '\t'
            };
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }
    }
}
