using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ACT.HueSync.Config.Forms
{
    public partial class HueInitializeForm : UserControl, IConfigForm
    {

        readonly Hue.HueController hueController;
        private List<Hue.HueBridgeInfo> hueBridges;

        /// <summary>
        /// リンクボタン待機中フラグ
        /// </summary>
        private bool _linkBtnWaiting = false;

        public HueInitializeForm()
        {
            InitializeComponent();

            PluginSetting.Instance.GeneralDataInitialized += AddControlSetting;

            hueController = Hue.HueController.Instance;
            Label_ReClick.Visible = false;
        }

        /// <summary>
        /// 設定機能を追加する
        /// </summary>
        public void AddControlSetting(object sender, EventArgs e)
        {
            // Add any controls you want to save the state of
            PluginSetting.Instance.GeneralData.AddControlSetting(Text_BridgeId.Name, Text_BridgeId);
            PluginSetting.Instance.GeneralData.AddControlSetting(Text_IpAddress.Name, Text_IpAddress);
            PluginSetting.Instance.GeneralData.AddControlSetting(Text_HueAppKey.Name, Text_HueAppKey);

            Label_SearchInfo.Text = GetSearchInfoText();

        }

        /// <summary>
        /// Label_SearchInfoに表示するテキストを返す
        /// </summary>
        /// <returns></returns>
        public string GetSearchInfoText()
        {
            if (Text_IpAddress.Text.Length < 10)
            {
                if (hueBridges == null || hueBridges.Count == 0)
                {
                    return "Search for Hue Bridge.";
                }

                return "Select Hue Bridge.";

            }
            else
            {
                return "Ready.";
            }
        }

        /// <summary>
        /// Search Hue Bridge Button ClickEvent Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SearchHueBtn_Click(object sender, EventArgs e)
        {
            Label_SearchInfo.Text = "Searching...";

            var response = await hueController.SearchHueBridge();

            hueBridges = response;

            if (response == null)
            {
                Label_SearchInfo.Text = "Error! Wait 15min and try it.";
                return;
            }

            Label_SearchInfo.Text = $"{response.Count} item found.";

            foreach (var item in response)
            {
                List_SearchResult.Items.Add($"{item.ID ?? item.Name} - {item.IpAddress}");
            }
        }



        /// <summary>
        /// Hue Bridge SearchResultList SelectedIndexChanged Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResultList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = List_SearchResult.SelectedIndex;
            var item = hueBridges[index];
            if (item != null)
            {
                Text_BridgeId.Text = item.ID;
                Text_IpAddress.Text = item.IpAddress;
            }
        }

        /// <summary>
        /// RegistHueBtn ClickEvent Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RegistHueBtn_Click(object sender, EventArgs e)
        {
            if (Text_IpAddress.Text == null)
            {
                Label_RegistInfo.Text = "IP address is not set.";
                return;
            }

            if (Text_BridgeId.Text == null)
            {
                Label_RegistInfo.Text = "Bridge ID is not set.";
            }

            if (_linkBtnWaiting == true)
            {
                _linkBtnWaiting = false;
                Label_ReClick.Visible = false;
            }

            Label_RegistInfo.Text = "Wait...";

            var response = await hueController.RegistApp();

            if (response == null)
            {
                Label_RegistInfo.Text = "Error!";
                return;
            }

            if (response.Type == "error")
            {
                switch (response.Message)
                {
                    case "LINK_BUTTON_PRESS":
                        Label_RegistInfo.Text = "Press the Hue Bridge link button.";
                        _linkBtnWaiting = true;
                        Label_ReClick.Visible = true;
                        break;

                    default:
                        Label_RegistInfo.Text = $"{response.Type} {response.Message}";
                        break;
                }
            }

            if (response.Type == "success")
            {
                Label_RegistInfo.Text = "App registration is complete!";
                Text_HueAppKey.Text = response.Message;
            }

        }

        private void Text_BridgeId_TextChanged(object sender, EventArgs e)
        {
            hueController.BridgeId = Text_BridgeId.Text;
        }

        private void Text_IpAddress_TextChanged(object sender, EventArgs e)
        {
            hueController.IpAddress = Text_IpAddress.Text;
        }

        private void Text_HueAppKey_TextChanged(object sender, EventArgs e)
        {
            hueController.AppKey = Text_HueAppKey.Text;
        }
    }
}
