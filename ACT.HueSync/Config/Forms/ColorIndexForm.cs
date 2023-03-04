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

namespace ACT.HueSync.Config.Forms
{


    public partial class ColorIndexForm : UserControl
    {
        List<Hue.ColorSetting> colorSettings;
        const string FileName = @"ColorData\General.xml";
        DataSet dataSet;

        public ColorIndexForm()
        {
            InitializeComponent();

            dataSet = new DataSet();

            LoadData();

            DataGrid_ColorSetting.CellClick += DataGrid_ColorSetting_CellClick;
            //DataGrid_ColorSetting.DataBindingComplete += DataGrid_ColorSetting_DataBindingComplete;
        }

        private void DataGrid_ColorSetting_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // SetColorCellBgColor();
        }

        private void DataGrid_ColorSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックされたセルの列と行のインデックスを取得
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            // クリックされたのがヘッダー行でなく、かつヘッダー名が"Color"の場合のみ処理を実行
            if (rowIndex >= 0 && columnIndex > 0 && DataGrid_ColorSetting.Columns[columnIndex].HeaderText == "Color")
            {
                // カラーピッカーを表示し、ユーザーが選択した色を取得
                ColorDialog colorDialog = new ColorDialog();

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    float red = colorDialog.Color.R;
                    float green = colorDialog.Color.G;
                    float blue = colorDialog.Color.B;

                    string colorText = $"{red}, {green}, {blue}";

                    // セルに選択された色を設定
                    DataGrid_ColorSetting.Rows[rowIndex].Cells[columnIndex].Style.BackColor = colorDialog.Color;

                    DataGrid_ColorSetting.Rows[rowIndex].Cells[columnIndex].Value = colorText;

                    // データセットに保存
                    dataSet.Tables["ColorSetting"].Rows[rowIndex]["Color"] = colorText;

                    SaveData();
                }
            }
            return;
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

            DataGrid_ColorSetting.SuspendLayout();

            foreach (DataGridViewRow row in DataGrid_ColorSetting.Rows)
            {
                int columnIndex = 0;

                foreach (DataGridViewColumn column in DataGrid_ColorSetting.Columns)
                {
                    // ヘッダー行でなく、かつヘッダー名が"Color"の場合のみ処理を実行
                    if (rowIndex >= 0 && DataGrid_ColorSetting.Columns[columnIndex].HeaderText == "Color")
                    {

                        var val = colorSettings[dataIndex].Color;
                        // ActGlobals.oFormActMain.WriteInfoLog($"[HueSync]rowIndex:{rowIndex}  columnIndex:{columnIndex} value:{DataGrid_ColorSetting.Rows[rowIndex].Cells[columnIndex].Value}==={val}");
                        DataGrid_ColorSetting.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Util.RGBstringToColor(val);
                    }

                    columnIndex++;
                }

                rowIndex++;
                dataIndex++;
            }

            DataGrid_ColorSetting.ResumeLayout();

        }


        private void LoadData()
        {

            try
            {

                dataSet.ReadXml(PluginSetting.Instance.PluginDirectory + @"\" + FileName);

                // SetLoadData(BSTable);
                LoadGridValuesFromTable(ref DataGrid_ColorSetting, dataSet.Tables["ColorSetting"]);

                PluginSetting.Instance.GeneralColorSetting = dataSet.Tables["ColorSetting"];

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
    }
}
