using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT.HueSync.Config.Forms
{
    public partial class LimsaLominsaForm : UserControl
    {
        public LimsaLominsaForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            PluginSetting.Instance.ColorDataTableChanged += ColorDataTableChanged;

            DataGrid_LimsaLominsa.Paint += DataGrid_LimsaLominsa_Paint;
            DataGrid_LimsaLominsa.CurrentCellChanged += DataGrid_LimsaLominsa_CurrentCellChanged;

            DataGrid_LimsaLominsa.BackButtonClick += DataGrid_LimsaLominsa_BackButtonClick;
            DataGrid_LimsaLominsa.Navigate += DataGrid_LimsaLominsa_Navigate;

            this.Load += LimsaLominsaForm_Load;
        }

        private void DataGrid_LimsaLominsa_Navigate(object sender, NavigateEventArgs ne)
        {
            Label_DataCount.Text = "Navigate ChildTable";
        }

        private void DataGrid_LimsaLominsa_BackButtonClick(object sender, EventArgs e)
        {
            Label_DataCount.Text = "BackButtonClick";
        }

        private void LimsaLominsaForm_Load(object sender, EventArgs e)
        {
            DataGrid_LimsaLominsa.DataSource = PluginSetting.Instance.ColorSettingDataSet;
            DataGrid_LimsaLominsa.DataMember = "ColorData";

            // Name, Age, Addressが一致するデータを検索する
            /*
            var query = from row in myDataTable.AsEnumerable()
                        group row by new { Name = row.Field<string>("Name"), Age = row.Field<int>("Age"), Address = row.Field<string>("Address") } into grouped
                        where grouped.Count() > 1
                        select grouped;
            // 該当するデータがある場合、DataGridViewに表示する
                if (query.Any())
                {
                    DataTable result = query.SelectMany(g => g).CopyToDataTable();
                    myDataGridView.DataSource = result;
                }
            */


            Label_DataCount.Text = PluginSetting.Instance.ColorSettingDataSet.Tables["ColorData"].Rows.Count.ToString();

        }

        private void ColorDataTableChanged(object sender, EventArgs e)
        {
            Label_DataCount.Text = PluginSetting.Instance.ColorSettingDataSet.Tables["ColorData"].Rows.Count.ToString();

        }

        /// <summary>
        /// DataGrid_LimsaLominsa　描画時のイベントハンドラ
        /// </summary>
        /// <see cref="https://atmarkit.itmedia.co.jp/fdotnet/dotnettips/126dgselline/dgselline.html"/>
        private void DataGrid_LimsaLominsa_Paint(object sender, PaintEventArgs e)
        {
            // 描画される場合には行を選択しなおす
            if (DataGrid_LimsaLominsa.VisibleRowCount > 0)
            {
                DataGrid_LimsaLominsa.Select(DataGrid_LimsaLominsa.CurrentCell.RowNumber);

            }
        }

        /// <summary>
        /// DataGrid_LimsaLominsa 選択されたセルが変更されたイベントハンドラ
        /// </summary>
        private void DataGrid_LimsaLominsa_CurrentCellChanged(object sender, EventArgs e)
        {
            Label_DataCount.Text = "RowNumber:" + DataGrid_LimsaLominsa.CurrentCell.RowNumber;

        }

    }
}
