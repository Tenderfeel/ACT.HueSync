using Advanced_Combat_Tracker;

namespace ACT.HueSync.Config.Forms
{
    internal interface IConfigForm
    {
        /// <summary>
        /// 設定機能に対応させる
        /// </summary>
        /// <param name="xmlSettings"></param>
        void AddControlSetting(SettingsSerializer xmlSettings);
    }
}
