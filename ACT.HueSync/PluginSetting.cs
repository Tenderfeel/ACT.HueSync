using ACT.HueSync.Hue;
using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.HueSync
{
    internal sealed class PluginSetting
    {
        private static PluginSetting instance = null;
        private static readonly object padlock = new object();

        private double _currentET;
        private string _timeZone;
        private SettingsSerializer _generalData;

        /// <summary>
        /// GeneralData読み込み時に発火するイベント
        /// </summary>
        public event EventHandler GeneralDataLoaded;

        /// <summary>
        /// GeneralData初期化時に発火するイベント
        /// </summary>
        public event EventHandler GeneralDataInitialized;

        /// <summary>
        /// GeneralDataファイルの場所
        /// </summary>
        public readonly string GeneralDataFileName = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ActHueSync.config.xml");

        PluginSetting()
        {
        }

        public static PluginSetting Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PluginSetting();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// プラグイン設定
        /// </summary>
        public SettingsSerializer GeneralData 
        { 
            set
            {
                _generalData = value;
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GeneralData Initialized.");
                GeneralDataInitialized.Invoke(this, EventArgs.Empty);
            }
            get
            {
                return _generalData;
            }
        }

        /// <summary>
        /// プラグインのディレクトリ
        /// </summary>
        public string PluginDirectory { set; get; }

        public double CurrentET { 
            set {
                _currentET = value;

                if (value < 6 && value < 12)
                {
                    _timeZone = "morning";
                } else if (value < 12 && value < 18 )
                {
                    _timeZone = "afternoon";
                } else if (value < 18 && value < 21 )
                {
                    _timeZone = "evening";
                } else
                {
                    _timeZone = "night";
                }

            }

            get
            {
                return _currentET;
            }
        }

        public string TimeZone
        {
            get { return _timeZone; }
        }

        public string CurrentWeather { set; get; }

        public string CurrentZoneName { set; get; }

        public DataTable GeneralColorSetting { get; set; }

        public object GetLightState()
        {
            if (GeneralColorSetting == null)
            {
                return null;
            }

            DataRow[] rows = GeneralColorSetting.Select($"TimeZone = '{_timeZone}'");

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                Console.WriteLine(row["Color"]);
                var color = Util.RGBstringToColor(row["Color"].ToString());

                return new { 
                    on = true, 
                    sat = (byte) color.GetSaturation() * 255.0f, // 彩度
                    bri = (byte) color.GetBrightness() * 255.0f, // 明るさ
                    hue = (ushort) color.GetHue() * (65535.0f / 360.0f) // 色相値
                };

            }

            return null;
        }

        /// <summary>
        /// GeneralData読み込み時に叩かれる
        /// </summary>
        public void InvokeGeneralDataLoaded()
        {
            GeneralDataLoaded.Invoke(this, EventArgs.Empty);
        }
    }
}
