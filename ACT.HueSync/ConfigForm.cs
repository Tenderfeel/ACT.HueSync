using System;
using System.Windows.Forms;

namespace ACT.HueSync
{
    public partial class ConfigForm : UserControl
    {
        readonly Hue.Controller hueController;

        public ConfigForm()
        {
            InitializeComponent();
            hueController = new Hue.Controller();
        }

        private async void SearchHueBtn_Click(object sender, EventArgs e)
        {
            SearchInfo.Text = "Loading...";

            var response = await hueController.SearchHueBridge();

            if (response == null)
            {
                SearchInfo.Text = "Error!";
                return;
            }

            SearchInfo.Text = "Success\n\n";

            foreach (var item in response)
            {
                SearchInfo.Text += $"{item.ID}: {item.Name} {item.IpAddress}\n";
            }
        }
    }
}
