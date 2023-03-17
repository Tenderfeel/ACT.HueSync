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

        readonly private DataTable _colorDataTable = new DataTable("ColorData");
        readonly private DataTable _lightDataTable = new DataTable("LightData");
        readonly private DataSet _colorSettingDataSet = new DataSet();

        public event EventHandler ColorDataTableChanged;

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
            _colorDataTable.Columns.Add("ColorID", typeof(string));
            _colorDataTable.Columns.Add("ZoneName", typeof(string));
            _colorDataTable.Columns.Add("StartTime", typeof(decimal));
            _colorDataTable.Columns.Add("WeatherId", typeof(string));

            //主キーの設定
            _colorDataTable.PrimaryKey = new DataColumn[] { 
                _colorDataTable.Columns["ColorID"] 
            };

            _colorDataTable.RowChanged += ColorDataTable_RowChanged;

            _lightDataTable.Columns.Add("ColorId", typeof(string));
            _lightDataTable.Columns.Add("LightId", typeof(int));
            _lightDataTable.Columns.Add("LightName", typeof(string));
            _lightDataTable.Columns.Add("ColorMode", typeof(string));
            _lightDataTable.Columns.Add("Bri", typeof(int));
            _lightDataTable.Columns.Add("Hue", typeof(int));
            _lightDataTable.Columns.Add("Sat", typeof(int));
            _lightDataTable.Columns.Add("X", typeof(int));
            _lightDataTable.Columns.Add("Y", typeof(int));
            _lightDataTable.Columns.Add("Ct", typeof(int));

            _colorSettingDataSet.Tables.Add(_colorDataTable);
            _colorSettingDataSet.Tables.Add(_lightDataTable);

            // リレーションの設定
            DataRelation Datatablerelation = new DataRelation("LightsDetail",
                    _colorSettingDataSet.Tables["ColorData"].Columns["ColorId"], 
                    _colorSettingDataSet.Tables["LightData"].Columns["ColorId"], 
                    true);
            
            _colorSettingDataSet.Relations.Add(Datatablerelation);
        }

        private void ColorDataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            ColorDataTableChanged.Invoke(this, EventArgs.Empty);
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

        /// <summary>
        /// ColorId, StartTime, ZoneId, WeatherId
        /// </summary>
        public DataTable ColorDataTable { 
            get {
                return _colorDataTable;
            }
        }

        /// <summary>
        /// ColorId, LightId, LightName, ...LightState
        /// </summary>
        public DataTable LightDataTable
        {
            get
            {
                return _lightDataTable;
            }
        }

        /// <summary>
        /// ColorDataTable + LightDataTable (Relation)
        /// </summary>
        public DataSet ColorSettingDataSet
        {
            get
            {
                return _colorSettingDataSet;
            }
        }
        /*
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
        }*/

        /// <summary>
        /// GeneralData読み込み時に叩かれる
        /// </summary>
        public void InvokeGeneralDataLoaded()
        {
            GeneralDataLoaded.Invoke(this, EventArgs.Empty);
        }
    }
}
