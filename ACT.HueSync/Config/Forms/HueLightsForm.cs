using ACT.HueSync.Hue;
using Advanced_Combat_Tracker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ACT.HueSync.Config.Forms
{
    /// <summary>
    /// ブリッジに接続中のライトをリストで表示する
    /// チェックを入れたライトをコントロール対象にする
    /// </summary>
    public partial class HueLightsForm : UserControl, IConfigForm
    {
        readonly Hue.HueController hueController;

        /// <summary>
        /// ライト一覧が空だった場合のフラグ
        /// </summary>
        private bool _isEmptyConfig;

        /// <summary>
        /// Constructor
        /// </summary>
        public HueLightsForm()
        {
            InitializeComponent();

            PluginSetting.Instance.GeneralDataInitialized += AddControlSetting;
            PluginSetting.Instance.GeneralDataLoaded += AfterSettingLoaded;

            hueController = Hue.HueController.Instance;

        }


        /// <summary>
        /// 設定機能を追加する
        /// </summary>
        public void AddControlSetting(object sender, EventArgs e)
        {
            PluginSetting.Instance.GeneralData.AddControlSetting(List_HueLights.Name, List_HueLights);
        }

        /// <summary>
        /// GeneralData読み込み完了時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AfterSettingLoaded(object sender, EventArgs e)
        {

            _isEmptyConfig = List_HueLights.Items.Count == 0;

            GetHueLights();
        }

        private  void HueLightsForm_Load(object sender, EventArgs e)
        {
            if (List_HueLights.Items.Count == 0)
            {
                GetHueLights();
            }
        }

        /// <summary>
        /// Bridgeに接続中のライトをリストにして表示する
        /// </summary>
        private async void GetHueLights()
        {
            ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights Called.");

            if (hueController.IpAddress == null)
            {
                Label_GetLightsState.Text = "IP address is not set.";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, IP address is not set.");
                return;
            }

            if (hueController.BridgeId == null)
            {
                Label_GetLightsState.Text = "Bridge ID is not set.";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, Bridge ID is not set.");
                return;
            }

            Label_GetLightsState.Text = "Loading...";

            // 全てのライトを得る
            var result = await hueController.GetAllLights();

            if (result == null)
            {
                Label_GetLightsState.Text = "Error!";
                ActGlobals.oFormActMain.WriteInfoLog("[HueSync] GetHueLights, result is null.");
                return;
            }

            Label_GetLightsState.Text = $"{result.Count} found.";

            // リストを作成
            var lightConfigs = new List<LightConfig>();

            foreach (var item in result)
            {
                bool isEnabled = false;

                if (!_isEmptyConfig)
                {
                    var index = List_HueLights.Items.IndexOf($"({item.Key}) {item.Value.Name}");
                    if (index != -1)
                    {
                        isEnabled = List_HueLights.GetItemChecked(index);
                    }
                }
                else
                {
                    List_HueLights.Items.Add($"({item.Key}) {item.Value.Name}", CheckState.Unchecked);

                }

                lightConfigs.Add(
                    new LightConfig()
                    {
                        Enabled = isEnabled,
                        Id = item.Key,
                        Power = item.Value.State.On,
                        Name = item.Value.Name,
                        Uniqueid = item.Value.Uniqueid,
                        ProductName = item.Value.Productname
                    }
                );

            }

            hueController.LightConfigs = lightConfigs;
        }

        /// <summary>
        /// チェックボックスの状態が変更された時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_HueLights_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // チェックボックスの状態が変更されたアイテムのインデックスを取得
            int itemIndex = e.Index;

            if (hueController.LightConfigs == null)
            {
                return;
            }

            // チェックボックスがONになった場合
            if (e.NewValue == CheckState.Checked)
            {
                hueController.LightConfigs[itemIndex].Enabled = true;
            }
            // チェックボックスがOFFになった場合
            else if (e.NewValue == CheckState.Unchecked)
            {
                hueController.LightConfigs[itemIndex].Enabled = false;
            }
        }
    }
}
