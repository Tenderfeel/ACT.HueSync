using System;
using System.Collections.Generic;

namespace Eorzea
{
    public class Constants
    {
        public static string WEATHER_BLIZZARDS = "blizzards";
        public static string WEATHER_CLEAR_SKIES = "clearSkies";
        public static string WEATHER_CLOUDS = "clouds";
        public static string WEATHER_DUST_STORMS = "dustStorms";
        public static string WEATHER_FAIR_SKIES = "fairSkies";
        public static string WEATHER_FOG = "fog";
        public static string WEATHER_GALES = "gales";
        public static string WEATHER_GLOOM = "gloom";
        public static string WEATHER_HEAT_WAVES = "heatWaves";
        public static string WEATHER_RAIN = "rain";
        public static string WEATHER_SHOWERS = "showers";
        public static string WEATHER_SNOW = "snow";
        public static string WEATHER_THUNDER = "thunder";
        public static string WEATHER_THUNDERSTORMS = "thunderstorms";
        public static string WEATHER_UMBRAL_STATIC = "umbralStatic";
        public static string WEATHER_UMBRAL_WIND = "umbralWind";
        public static string WEATHER_WIND = "wind";

        /// <summary>
        /// 天気のIDリスト
        /// </summary>
        public static List<string> WeathersIdList = new List<string>() {
            WEATHER_BLIZZARDS,
            WEATHER_CLEAR_SKIES,
            WEATHER_CLOUDS,
            WEATHER_DUST_STORMS,
            WEATHER_FAIR_SKIES,
            WEATHER_FOG,
            WEATHER_GALES,
            WEATHER_GLOOM,
            WEATHER_HEAT_WAVES,
            WEATHER_RAIN,
            WEATHER_SHOWERS,
            WEATHER_SNOW,
            WEATHER_THUNDER,
            WEATHER_THUNDERSTORMS,
            WEATHER_UMBRAL_STATIC,
            WEATHER_UMBRAL_WIND,
            WEATHER_WIND
        };

        public static Dictionary<string, string> WeatherId
        {
            get
            {
                string locale = "ja";
                Dictionary<string, string> data = new Dictionary<string, string>();

                foreach (var wid in WeathersIdList)
                {
                    // キャメルケース型の文字列を英語の表記に成型
                    string outputString = System.Text.RegularExpressions.Regex.Replace(wid, @"(\p{Lu})", " $1").TrimStart();

                    switch (locale)
                    {
                        case "ja":
                            Locales.Ja.TryGetValue(wid, out var weatherLabel);
                            if (weatherLabel != null)
                            {
                                data.Add(wid, weatherLabel);
                            }
                            else
                            {
                                data.Add(wid, outputString);
                            }
                            break;
                        default:
                            data.Add(wid, outputString);
                            break;
                    }
                }

                return data;
            }
        }


        /// <summary>
        /// ACTのZoneIDをメソッド名に置換するための
        /// </summary>
        public static Dictionary<string, string> ZoneId = new Dictionary<string, string>()
        {
            {"Limsa Lominsa Lower Decks", "LimsaLominsa"},
            {"Limsa Lominsa Upper Decks", "LimsaLominsa"},
            {"Middle La Noscea", "MiddleLaNoscea" },
            {"Lower La Noscea", "LowerLaNoscea" },
            {"Eastern La Noscea", "EasternLaNoscea" },
            {"Western La Noscea", "WesternLaNoscea" },
            {"Upper La Noscea", "UpperLaNoscea" },
            {"Outer La Noscea", "OuterLaNoscea" },
            {"Wolves' Den Pier", "WolvesDenPier" },
            {"Idyllshire", "Idyllshire"},
            {"Empyreum", "Empyreum"},
            {"ishgard", "Ishgard"},
            {"New Gridania", "Gridania"},
            {"Old Gridania", "Gridania"},
            {"morDhona", "MorDhona" },
            {"Ul'dah - Steps of Nald", "Uldah" },
            {"Ul'dah - Steps of Thal", "Uldah" },
        };

    }
}