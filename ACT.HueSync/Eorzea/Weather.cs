using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;

namespace Eorzea
{
    /// <summary>
    /// エオルゼア天気
    /// </summary>
    /// <see cref="https://github.com/eorzea-weather/node-eorzea-weather"/>
    internal class Weather
    {
        public Weather()
        {

        }

        /// <summary>
        /// ACTのZoneNameを元にエオルゼア天気を返す
        /// </summary>
        /// <param name="zoneName">ACTのZoneName情報</param>
        /// <returns>指定したZoneNameのエオルゼア天気</returns>
        public string GetWeather(string zoneName)
        {

            // ACTのZoneNameをZoneIDに変換
            Constants.ZoneId.TryGetValue(zoneName, out string zoneId);

            if (zoneId == null)
            {
                return "Unknown";
            }


            Type type = typeof(WeatherChance);
            MethodInfo methodInfo = type.GetMethod(zoneId);

            if (methodInfo != null)
            {
                // 天気を算出
                int chance = CalculateForecastTarget();
                object[] parameters = new object[] { chance };
                string weatherId = (string)methodInfo.Invoke(null, parameters);

                // TODO: Locale対応
                Locales.Ja.TryGetValue(weatherId, out var weather);

                return weather;
            }

            return "Unknown";
        }

        /// <summary>
        /// 時間からエオルゼア天気を算出する
        /// </summary>
        /// <returns>WeatherChanceに渡す整数</returns>
        public int CalculateForecastTarget()
        {
            long unixtime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds;
            // Get Eorzea hour for weather start
            double bell = (double)unixtime / 175;

            // Do the magic 'cause for calculations 16:00 is 0, 00:00 is 8 and 08:00 is 16
            double increment = (bell + 8 - (bell % 8)) % 24;

            // Take Eorzea days since unix epoch
            double totalDays = unixtime / 4200;
            uint calcBase = (uint)(totalDays * 0x64 + increment);

            uint step1 = ((calcBase << 0xb) ^ calcBase);
            uint step2 = (step1 >> 8) ^ step1;

            return (int)(step2 % 0x64);

        }
    }

}