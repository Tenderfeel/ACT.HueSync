using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ACT.HueSync
{
    public partial class ConfigForm : UserControl
    {
        readonly Hue.Controller hueController;
        private List<Hue.HueBridgeInfo> hueBridges;

        public ConfigForm()
        {
            InitializeComponent();
            hueController = new Hue.Controller();
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

        private void SearchResultList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = SearchResultList.SelectedIndex;
            var item = hueBridges[index];
            IpAddress.Text = item.IpAddress;
        }
    }
}
