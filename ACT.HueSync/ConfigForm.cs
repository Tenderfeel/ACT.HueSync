using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ACT.HueSync
{
    public partial class ConfigForm : UserControl
    {
        readonly Hue.HueController hueController;
        private List<Hue.HueBridgeInfo> hueBridges;
        readonly private string _pluginDirectory;

        private bool _linkBtnWaiting = false;

        public ConfigForm(string pluginDirectory)
        {
            InitializeComponent();
            _pluginDirectory = pluginDirectory;
            hueController = new Hue.HueController();
            ReClickLabel.Visible = false;
        }

        private void IpAddress_Change(object sender, EventArgs e)
        {
            SearchInfo.Text = GetSearchInfoText();
        }

        public string GetSearchInfoText()
        {
            if (IpAddress.Text.Length < 10)
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
            SearchInfo.Text = "Searching...";

            var response = await hueController.SearchHueBridge();

            hueBridges = response;

            if (response == null)
            {
                SearchInfo.Text = "Error! Wait 15min and try it.";
                return;
            }

            SearchInfo.Text = $"{response.Count} item found.";

            foreach (var item in response)
            {
                SearchResultList.Items.Add($"{item.ID ?? item.Name} - {item.IpAddress}");
            }
        }

        /// <summary>
        /// Hue Bridge SearchResultList SelectedIndexChanged Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResultList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = SearchResultList.SelectedIndex;
            var item = hueBridges[index];
            if (item != null)
            {
                BridgeId.Text = item.ID;
                IpAddress.Text = item.IpAddress;
            }
        }
        
        /// <summary>
        /// RegistHueBtn ClickEvent Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RegistHueBtn_Click(object sender, EventArgs e)
        {
            if (IpAddress.Text == null)
            {
                RegistInfo.Text = "IP address is not set.";
                return;
            }

            if (BridgeId.Text == null)
            {
                RegistInfo.Text = "Bridge ID is not set.";
            }

            if (_linkBtnWaiting == true)
            {
                _linkBtnWaiting = false;
                ReClickLabel.Visible = false;
            }

            RegistInfo.Text = "Wait...";

            var response = await hueController.RegistApp(BridgeId.Text, IpAddress.Text);

            if (response == null)
            {
                RegistInfo.Text = "Error!";
                return;
            }

            if (response.Type == "error")
            {
                switch (response.Message)
                {
                    case "LINK_BUTTON_PRESS":
                        RegistInfo.Text = "Press the Hue Bridge link button.";
                        _linkBtnWaiting = true;
                        ReClickLabel.Visible = true;
                        break;

                    default:
                        RegistInfo.Text = $"{response.Type} {response.Message}";
                        break;
                }
            }

            if (response.Type == "success")
            {
                RegistInfo.Text = "App registration is complete!";
                HueAppKey.Text = response.Message;
            }
            
        }
    }
}
