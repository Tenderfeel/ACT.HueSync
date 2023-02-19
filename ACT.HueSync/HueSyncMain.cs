using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ACT.HueSync
{
    internal class HueSyncMain
    {
        private readonly string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ActHueSync.config.xml");

        private SettingsSerializer xmlSettings;

        ConfigForm configForm;
        readonly ListBox log; // for log display
        readonly OverlayForm overlay; // overlay window
        readonly Label infoBox; // for info display

        readonly Eorzea.Clock eorzeaClock;
        readonly Eorzea.Weather eorzeaWeather;

        readonly private System.Timers.Timer timer; // info display timer

        private Label lblStatus;    // The status label that appears in ACT's Plugin tab
        private TabPage pluginScreen; 

        /// <summary>
        /// Constructor
        /// </summary>
        public HueSyncMain() {

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
        /// Called by InitPlugin when the plugin is activated
        /// </summary>
        /// <param name="pluginScreenSpace">Plugin setting tab page</param>
        /// <param name="pluginStatusText">Plugin status text</param>
        public void Init(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;
            pluginScreen = pluginScreenSpace;

            pluginScreen.Text = "HueSync";

            // Config UserControl
            configForm = new ConfigForm();
            pluginScreen.Controls.Add(configForm);

            // Create a new settings serializer and pass it this instance
            xmlSettings = new SettingsSerializer(this);
            LoadSettings();

            overlay.Show();

            // Every time a log line is read
            ActGlobals.oFormActMain.BeforeLogLineRead += OnBeforeLogLineRead;

            Log("Plugin Started.");

            // Eorzea time at startup
            string currentET = eorzeaClock.GetCurrentET(ActGlobals.oFormActMain.LastKnownTime);
            // Eorzea weather at startup
            string currentWeather = eorzeaWeather.GetWeather(ActGlobals.oFormActMain.CurrentZone);
            
            Log($"{ActGlobals.oFormActMain.CurrentZone} {currentET} -- {currentWeather}");

            timer.Start();
        }
        /// <summary>
        /// Called by DeInitPlugin when the plugin is deactivated
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
        /// Event handler to be executed before the ACT log is read
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
                // Eorzea time
                string currentET = eorzeaClock.GetCurrentET(time);

                // Eorzea weather
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
        /// Load plugin settings
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
        /// Save plugin settings
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
