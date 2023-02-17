using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ACT.HueSync
{
    public class ActPlugin: IActPluginV1
    {

        Label lblStatus;    // The status label that appears in ACT's Plugin tab

        readonly HueSyncMain hueSyncMain;

       public ActPlugin ()
        {
            hueSyncMain = new HueSyncMain();
        }

        /// <summary>
        /// プラグインが有効化されたときに呼び出される
        /// </summary>
        /// <param name="pluginScreenSpace">プラグインのタブページ</param>
        /// <param name="pluginStatusText">プラグインのステータステキスト</param>
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var

            hueSyncMain.Init( pluginScreenSpace, pluginStatusText);

            lblStatus.Text = "Plugin Started";
        }

        /// <summary>
        /// プラグインが無効化されたときに呼び出される
        /// </summary>
        public void DeInitPlugin()
        {
            hueSyncMain.DeInit();

            lblStatus.Text = "Plugin Exited";
        }

    }
}
