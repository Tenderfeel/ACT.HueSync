using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.HueSync
{
    internal static class Util
    {
        /// <summary>
        /// RGB文字列からColorを生成して返す。デフォルトは白色
        /// </summary>
        /// <param name="str">カンマ区切りのRGB文字列 "255, 255, 255" </param>
        /// <returns></returns>
        public static Color RGBstringToColor(string str)
        {
            string[] strArray = str.Split(',');

            if (strArray.Length == 3)
            {
                int[] intArray = new int[strArray.Length];
                for (int i = 0; i < strArray.Length; i++)
                {
                    bool success = Int16.TryParse(strArray[i].Trim(), out short num);
                    if (success)
                    {
                        intArray[i] = num;
                    }
                    else
                    {
                        intArray[i] = 255;
                    }
                }

                return Color.FromArgb(intArray[0], intArray[1], intArray[2]);
            }

            return Color.FromArgb(255, 255, 255);
        }
    }
}
