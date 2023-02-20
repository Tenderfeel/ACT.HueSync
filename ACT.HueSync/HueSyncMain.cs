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
        readonly Label infoBox; // for info display

        readonly Eorzea.Clock eorzeaClock;
        readonly Eorzea.Weather eorzeaWeather;

        System.Timers.Timer timer; // info display timer

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        TabPage pluginScreen; 

        /// <summary>
        /// Constructor
        /// </summary>
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
            infoBox = overlay.InfoBox;

            eorzeaClock = new Eorzea.Clock(); 
            eorzeaWeather = new Eorzea.Weather();

            timer = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer.Elapsed += (o, e) =>
            {
                try
                {
                    DisplayUpdate();
                }
                catch (Exception ex)
                {
                    Log("Error: Update: {0}", ex.ToString());
                }
            };
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

            Log("Plugin Started.");

            // 起動時のエオルゼア時間を得る
            string currentET = eorzeaClock.GetCurrentET(ActGlobals.oFormActMain.LastKnownTime);
            // 起動時のエオルゼア天気を得る
            string currentWeather = eorzeaWeather.GetWeather(ActGlobals.oFormActMain.CurrentZone);
            
            Log($"{ActGlobals.oFormActMain.CurrentZone} {currentET} -- {currentWeather}");

            timer.Start();
        }
        /// <summary>
        /// プラグインが無効化されるときにDeInitPluginから呼び出される
        /// </summary>
        public void DeInit()
        {
            SaveSettings();
            overlay.Close();
            timer.Stop();

            // Unsubscribe
            ActGlobals.oFormActMain.BeforeLogLineRead -= OnBeforeLogLineRead;
        }

        private void DisplayUpdate()
        {
            string zone = ActGlobals.oFormActMain.CurrentZone;
            DateTime time = ActGlobals.oFormActMain.LastKnownTime;
            string currentET = eorzeaClock.GetCurrentET(time);
            string currentWeather = eorzeaWeather.GetWeather(zone);

            Info($"{zone} {currentET} -- {currentWeather}");
        }

        /// <summary>
        /// ログが読み込まれる前に実行されるイベントハンドラ
        /// </summary>
        /// <param name="isImport"></param>
        /// <param name="logInfo"></param>
        private void OnBeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

            string zone = logInfo.detectedZone;
            int type = logInfo.detectedType;
            DateTime time = logInfo.detectedTime;

            // 40:ChangeMap 
            if (type == 40)
            {
                // エオルゼア時間
                string currentET = eorzeaClock.GetCurrentET(time);

                // エオルゼア天気
                string currentWeather = eorzeaWeather.GetWeather(zone);

                Log($"[ChangeMap] {zone} {currentET} -- {currentWeather}");
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
        /// Update to the InfoBox Text
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        private void Info(string format, params object[] args)
        {
            infoBox.Text = string.Format(format, args);
        }

        /// <summary>
        /// プラグイン設定をロードする
        /// </summary>
        private void LoadSettings()
        {
            // Add any controls you want to save the state of
            xmlSettings.AddControlSetting(configForm.IpAddress.Name, configForm.IpAddress);

            configForm.SearchInfo.Text = configForm.GetSearchInfoText();


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
