using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Xml.Serialization;
using ACT.HueSync.Hue;
using Advanced_Combat_Tracker;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ACT.HueSync.Config.Forms
{


    public partial class ColorIndexForm : UserControl
    {
        List<Hue.ColorSetting> colorSettings;
        const string FileName = @"ColorData\General.xml";
        DataSet dataSet;
        Guid _guid;

        public ColorIndexForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            dataSet = new DataSet();


            Dictionary<string, string> defaultDictionary = new Dictionary<string, string>()
            {
                { "", "" }
            };

            Dictionary<string, string> defaultZoneDictionary = new Dictionary<string, string>()
            {
                { "General", "" }
            };

            // Dictionaryを複製する
            Dictionary<string, string> clonedZoneDictionary = defaultZoneDictionary.Concat(Eorzea.Constants.ZoneId).ToDictionary(pair => pair.Key, pair => pair.Value);
            Dictionary<string, string> clonedWeatherDictionary = defaultDictionary.Concat(Eorzea.Constants.WeatherId).ToDictionary(pair => pair.Key, pair => pair.Value);

            // ゾーン名
            ComboBox_ZoneName.DataSource = new BindingSource(clonedZoneDictionary, null);
            ComboBox_ZoneName.DisplayMember = "Key";
            ComboBox_ZoneName.ValueMember = "Key";

            // 天気
            ComboBox_Weather.DataSource = new BindingSource(clonedWeatherDictionary, null);
            ComboBox_Weather.DisplayMember = "Value";
            ComboBox_Weather.ValueMember = "Key";

            // LoadData();
            // DataGrid_ColorSetting.DataBindingComplete += DataGrid_ColorSetting_DataBindingComplete;
        }

        private void DataGrid_ColorSetting_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // SetColorCellBgColor();
        }


        private void SaveData ()
        {
            /*
            XmlSerializer serializer = new XmlSerializer(typeof(List<Hue.ColorSetting>));
            using (FileStream stream = new FileStream(PluginSetting.Instance.PluginDirectory + @"\" + FileName, FileMode.Create))
            {
                serializer.Serialize(stream, colorSettings);
            }*/


            dataSet.WriteXml(PluginSetting.Instance.PluginDirectory + @"\" + FileName);
        }

        private void SetDefaultData ()
        {
            colorSettings = new List<Hue.ColorSetting>()
            {
                new Hue.ColorSetting{Category="General", Color = "", TimeZone="morning"},
                new Hue.ColorSetting{Category="General", Color = "", TimeZone="afternoon"},
                new Hue.ColorSetting{Category="General", Color = "", TimeZone="evening"},
                new Hue.ColorSetting{Category="General", Color = "", TimeZone="night"},
            };

            //DataGrid_ColorSetting.DataSource = colorSettings;
            // DataGrid_ColorSetting.Columns[2].Width = 200;

            DataTable table = new DataTable("ColorSetting");

            table.Columns.Add(new DataColumn("Category", typeof(string)));
            table.Columns.Add(new DataColumn("TimeZone", typeof(string)));
            table.Columns.Add(new DataColumn("Color", typeof(string)));


            string[] timezone =  { "morning", "argernoon", "evening", "night" };


            for (int i = 0; i < timezone.Length; i++)
            {

                DataRow row = table.NewRow();
                row["Category"] = "General";
                row["TimeZone"] = timezone[i];
                row["Color"] = "";
            }

            dataSet.Tables.Add(table);
        }

        private void CreateListDataFromDataTable(DataTable BSTable)
        {
            int columnIndex;
            int rowIndex = 0;
            colorSettings = new List<Hue.ColorSetting>();

            foreach (DataRow row in BSTable.Rows)
            {
                columnIndex = 0;
                var rowData = new ColorSetting();

                foreach (DataColumn column in BSTable.Columns)
                {
                    switch (column.ColumnName)
                    {
                        case nameof(ColorSetting.Category):
                            rowData.Category = row[columnIndex].ToString();
                            break;
                        case nameof(ColorSetting.TimeZone):
                            rowData.TimeZone = row[columnIndex].ToString();
                            break;
                        case nameof(ColorSetting.Color):
                            var color = row[columnIndex].ToString();
                            rowData.Color = color;
                            break;
                    }

                    columnIndex++;
                }
                rowIndex++;
                colorSettings.Add(rowData);
            }
        }

        private void SetColorCellBgColor()
        {
            int rowIndex = 0;
            int dataIndex = 0;

            DataGrid_LightSetting.SuspendLayout();

            foreach (DataGridViewRow row in DataGrid_LightSetting.Rows)
            {
                int columnIndex = 0;

                foreach (DataGridViewColumn column in DataGrid_LightSetting.Columns)
                {
                    // ヘッダー行でなく、かつヘッダー名が"Color"の場合のみ処理を実行
                    if (rowIndex >= 0 && DataGrid_LightSetting.Columns[columnIndex].HeaderText == "Color")
                    {

                        var val = colorSettings[dataIndex].Color;
                        // ActGlobals.oFormActMain.WriteInfoLog($"[HueSync]rowIndex:{rowIndex}  columnIndex:{columnIndex} value:{DataGrid_ColorSetting.Rows[rowIndex].Cells[columnIndex].Value}==={val}");
                        DataGrid_LightSetting.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Util.RGBstringToColor(val);
                    }

                    columnIndex++;
                }

                rowIndex++;
                dataIndex++;
            }

            DataGrid_LightSetting.ResumeLayout();

        }

        private void LoadData()
        {

            try
            {

                dataSet.ReadXml(PluginSetting.Instance.PluginDirectory + @"\" + FileName);

                // SetLoadData(BSTable);
                LoadGridValuesFromTable(ref DataGrid_LightSetting, dataSet.Tables["ColorSetting"]);

                //PluginSetting.Instance.GeneralColorSetting = dataSet.Tables["ColorSetting"];

            } catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, ex.Message);

                SetDefaultData();
                return;
            }

            
        }

        /// <summary>
        /// XMLファイルから読み込んだデータをDataGridに反映する
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="data"></param>
        private void LoadGridValuesFromTable(ref DataGridView dv, DataTable data)
        {

            dv.SuspendLayout();

            foreach (DataColumn column in data.Columns)
            {
                DataGridViewTextBoxColumn TextColumn = new DataGridViewTextBoxColumn
                {
                    Name = column.ColumnName,
                    ReadOnly = true
                };
                switch (column.ColumnName)
                {
                    case "ID":
                        TextColumn.Width = 50;
                        break;
                    case "Name":
                        break;
                    default:
                        TextColumn.Width = 80;
                        break;
                }
                dv.Columns.Add(TextColumn);
            }

            foreach (DataRow row in data.Rows)
            {
                int columnIndex = 0;
                int rowIndex = dv.Rows.Add();

                foreach (DataColumn column in data.Columns)
                {
                    if (column.ColumnName == "Color")
                    {
                        string value = row[columnIndex].ToString();

                        dv.Rows[rowIndex].Cells[columnIndex].Value = value;
                        dv.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Util.RGBstringToColor(value);
                    } else
                    {
                        dv.Rows[rowIndex].Cells[columnIndex].Value = row[columnIndex];
                    }
                    columnIndex++;
                }

            }

            dv.ResumeLayout();
        }

        /// <summary>
        /// 現在接続されているライトの設定を得る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_GetLightState_Click_1(object sender, EventArgs e)
        {

            Label_GetStateInfo.Text = "Wait...";
            Panel_Trigger.Visible = false;

            var response = await Hue.HueController.Instance.GetLightState();

            if (response == null)
            {
                Label_GetStateInfo.Text = "Error!";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetLightState, result is null.");
                return;
            }


            if (response.Count() == 0)
            {
                Label_GetStateInfo.Text = $"Not one status was retrieved.";
                return;
            }

            // GUID update
            _guid = Guid.NewGuid();

            Label_GetStateInfo.Text = $"{response.Count()} found";

            Panel_Trigger.Visible = true;

            dataSet.Tables.Clear();

            DataTable table = new DataTable("LightSetting");

            table.Columns.Add(new DataColumn("ID", typeof(string)));
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("ColorMode", typeof(string)));
            table.Columns.Add(new DataColumn("Bri", typeof(int)));
            table.Columns.Add(new DataColumn("Hue", typeof(int)));
            table.Columns.Add(new DataColumn("Sat", typeof(int)));
            table.Columns.Add(new DataColumn("X", typeof(float)));
            table.Columns.Add(new DataColumn("Y", typeof(float)));
            table.Columns.Add(new DataColumn("Ct", typeof(int)));

            foreach (var item in response)
            {
                if (item.State != null)
                {
                    var Id = Hue.HueController.Instance.GetLightIdbyName(item.Name);

                    DataRow row = table.NewRow();
                    row["ID"] = Id;
                    row["Name"] = item.Name;
                    row["ColorMode"] = item.State.Colormode;
                    row["Bri"] = item.State.Bri;
                    row["Hue"] = item.State.Hue;
                    row["Sat"] = item.State.Sat;
                    row["X"] = item.State.Xy[0];
                    row["Y"] = item.State.Xy[1];
                    row["Ct"] = item.State.Ct;
                    table.Rows.Add(row);
                }
            }

            dataSet.Tables.Add(table);

            // DataGridに反映
            LoadGridValuesFromTable(ref DataGrid_LightSetting, dataSet.Tables["LightSetting"]);

        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        /// <param name="sender"></param>   
        /// <param name="e"></param>
        private void Btn_SaveColorSetting_Click(object sender, EventArgs e)
        {

            if (UpDown_StartTime.Value == -1 && ComboBox_Weather.SelectedValue.ToString() == "")
            {
                Label_SaveSetting.Text = "Requied StartTime or Weather.";
                return;
            }

            string uniqid = _guid.ToString("N");
            string zoneName = ComboBox_ZoneName.SelectedValue.ToString();
            decimal startTime = UpDown_StartTime.Value;
            string weatherId = ComboBox_Weather.SelectedValue.ToString();

            // ZoneName, StartTime, WeatherIdの値が一致する行を検索する
            var foundRows = from DataRow row in PluginSetting.Instance.ColorDataTable.Rows
                            where (string)row["ZoneName"] == zoneName
                            && (decimal)row["StartTime"] == startTime
                            && (string)row["WeatherId"] == weatherId
                            select row;

            // 該当する行が存在する
            if (foundRows.Any())
             {
                Label_SaveSetting.Text = "Settings with the same conditions are registered.";
                return;
            }

             Label_SaveSetting.Text = "";

            try
            {
                // Color設定テーブルに追加
                PluginSetting.Instance.ColorDataTable.Rows.Add(
                    uniqid,
                    zoneName,
                    startTime,
                    weatherId
                );
            } catch
            {
                // 主キーが重複している
                Label_SaveSetting.Text = $"{uniqid} is already registered.";
                return;
            }


            DataTable table = dataSet.Tables["LightSetting"];

            // Light設定テーブルに追加
            foreach (DataRow row in table.Rows)
            {
                PluginSetting.Instance.LightDataTable.Rows.Add(
                    uniqid,
                    row["ID"],
                    row["Name"],
                    row["ColorMode"],
                    row["Bri"],
                    row["Hue"],
                    row["Sat"],
                    row["X"],
                    row["Y"],
                    row["Ct"]
                );
            }

            Label_SaveSetting.Text = "Saved!";
        }
    }
}
