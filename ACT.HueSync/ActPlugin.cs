using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ACT.HueSync
{
    public class ActPlugin: IActPluginV1
    {

        private Label lblStatus;    // The status label that appears in ACT's Plugin tab

        private object hueSyncMain;

        private string pluginDirectory;


        /// <summary>
        /// プラグインが有効化されたときに呼び出される
        /// </summary>
        /// <param name="pluginScreenSpace">プラグインのタブページ</param>
        /// <param name="pluginStatusText">プラグインのステータステキスト</param>
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var

            // get the working directory of the plugin
            // https://github.com/lonk44/ffxiv_act_discord/blob/master/FFXIV_Discord/PluginLoader.cs
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            pluginDirectory = (plugin != null) ? Path.GetDirectoryName(plugin.pluginFile.FullName) : throw new Exception();

            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            FinalInit(pluginScreenSpace, pluginStatusText);

            lblStatus.Text = "Plugin Started";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FinalInit(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            hueSyncMain = new HueSyncMain();
           ((HueSyncMain)hueSyncMain).Init(pluginScreenSpace, pluginStatusText);
        }

        /// <summary>
        /// プラグインが無効化されたときに呼び出される
        /// </summary>
        public void DeInitPlugin()
        {
            ((HueSyncMain)hueSyncMain).DeInit();

            lblStatus.Text = "Plugin Exited";
        }

        public Assembly Resolver(object sender, ResolveEventArgs args)
        {
            var asmName = new AssemblyName(args.Name).Name;

            if (!asmName.EndsWith(".dll"))
            {
                asmName += ".dll";
            }

            var asmPath = Path.Combine(pluginDirectory, asmName);
            if (File.Exists(asmPath))
            {
                return Assembly.LoadFile(asmPath);
            }

            return null;
        }

    }
}
