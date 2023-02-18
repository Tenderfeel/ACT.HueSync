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
        /// ACTのZoneIDをメソッド名に置換するための
        /// </summary>
        public static Dictionary<string, string> ZoneId = new Dictionary<string, string>()
        {
            {"Limsa Lominsa Lower Decks", "LimsaLominsa"},
            {"Limsa Lominsa Upper Decks", "LimsaLominsa"},
            {"Idyllshire", "Idyllshire"},
            {"Empyreum", "Empyreum"}
        };
    }
}