using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eorzea
{
    /// <summary>
    /// エリア毎の天気を判別する
    /// </summary>
    /// <see cref="https://github.com/eorzea-weather/node-eorzea-weather"/>
    internal class WeatherChance
    {
        /// <summary>
        /// リムサロミンサの天気
        /// </summary>
        /// <param name="chance">CalculateForecastTargetの戻り値</param>
        /// <returns>天気のID文字列</returns>
        public static string LimsaLominsa(int chance)
        {
            if (chance < 20)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 50)
            {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_RAIN;
        }

        /// <summary>
        /// イディルシャイアの天気
        /// </summary>
        /// <param name="chance">CalculateForecastTargetの戻り値</param>
        /// <returns>天気のID文字列</returns>
        public static string Idyllshire(int chance)
        {
            if (chance < 10)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 20)
            {
                return Constants.WEATHER_FOG;
            }
            if (chance < 30)
            {
                return Constants.WEATHER_RAIN;
            }
            if (chance < 40)
            {
                return Constants.WEATHER_SHOWERS;
            }
            if (chance < 70)
            {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            return Constants.WEATHER_FAIR_SKIES;
        }

        public static string Gridania (int chance) {
            if (chance < 5) {
                return Constants.WEATHER_RAIN;
            }

            if (chance < 20) {
                return Constants.WEATHER_RAIN;
            }

            if (chance < 30)
            {
                return Constants.WEATHER_FOG;
            }

            if (chance < 40)
            {
                return Constants.WEATHER_CLOUDS;
            }

            if (chance < 55)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }

            if (chance < 85)
            {
                return Constants.WEATHER_CLEAR_SKIES;
            }

            return Constants.WEATHER_FAIR_SKIES;
        }

        public static string Ishgard (int chance) {
            if (chance < 60) {
                return Constants.WEATHER_SNOW;
            }

            if (chance < 70) {
                return Constants.WEATHER_FAIR_SKIES;
            }

            if (chance < 75)
            {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_CLOUDS;
            }
            return Constants.WEATHER_FOG;
        }

        public static string MorDhona (int chance) {
            if (chance < 15) {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 30) {
                return Constants.WEATHER_FOG;
            }
            if (chance < 60)
            {
                return Constants.WEATHER_GLOOM;
            }
            if (chance < 75)
            {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            return Constants.WEATHER_FAIR_SKIES;
        }

        public static string Uldah (int chance) {
            if (chance < 40) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 60) {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 85)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 95)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_RAIN;
        }

        public static string EasternLaNoscea (int chance) {
            if (chance < 5) {
                return Constants.WEATHER_FOG;
            }
            if (chance < 50) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 95)
            {
                return Constants.WEATHER_RAIN;
            }
            return Constants.WEATHER_SHOWERS;
        }

        public static string UpperLaNoscea (int chance) {
            if (chance < 30) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 50) {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 70)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_FOG;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_THUNDER;
            }
            return Constants.WEATHER_THUNDERSTORMS;
        }

        public static string WesternLaNoscea (int chance) {
            if (chance < 10) {
                return Constants.WEATHER_FOG;
            }
            if (chance < 40) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 60)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_WIND;
            }
            return Constants.WEATHER_GALES;
        }

        public static string OuterLaNoscea (int chance) {
            if (chance < 30) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 50) {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 70)
            {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 85)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_RAIN;
        }

        public static string MiddleLaNoscea (int chance) {
            if (chance < 20) {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 50) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 70)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_WIND;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_RAIN;
        }

        public static string LowerLaNoscea (int chance) {
            if (chance < 20) {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 50) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 70)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_WIND;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_RAIN;
        }

        public static string WolvesDenPier (int chance) {
            if (chance < 20) {
                return Constants.WEATHER_CLOUDS;
            }
            if (chance < 50) {
                return Constants.WEATHER_CLEAR_SKIES;
            }
            if (chance < 80)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }
            if (chance < 90)
            {
                return Constants.WEATHER_FOG;
            }
            return Constants.WEATHER_THUNDERSTORMS;
        }

        public static string Empyreum (int chance)
        {
            if (chance < 5)
            {
                return Constants.WEATHER_CLOUDS;
            }

            if (chance < 20)
            {
                return Constants.WEATHER_FAIR_SKIES;
            }

            if (chance < 40)
            {
                return Constants.WEATHER_FOG;
            }

            if (chance < 60)
            {
                return Constants.WEATHER_FOG;
            }


            if (chance < 90)
            {
                return Constants.WEATHER_SNOW;
            }

            return Constants.WEATHER_CLEAR_SKIES;

        }
    }
}