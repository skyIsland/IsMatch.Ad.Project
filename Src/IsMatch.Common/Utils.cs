using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsMatch.Common
{
    public static class Utils
    {
        #region 按字符串位数补0

        /// <summary>
        /// 按字符串位数补0
        /// </summary>
        /// <param name="CharTxt">字符串</param>
        /// <param name="CharLen">字符长度</param>
        /// <returns></returns>
        public static string FillZero(int CharTxt, int CharLen)
        {
            return FillZero(CharTxt.ToString(), CharLen);
        }
        /// <summary>
        /// 按字符串位数补0
        /// </summary>
        /// <param name="CharTxt">字符串</param>
        /// <param name="CharLen">字符长度</param>
        /// <returns></returns>
        public static string FillZero(string CharTxt, int CharLen)
        {
            if (CharTxt.Length < CharLen)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < CharLen - CharTxt.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(CharTxt);
                return sb.ToString();
            }
            else
            {
                return CharTxt;
            }
        }
        #endregion

        #region 转为枚举

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名或值,
        /// 范例:Enum1枚举有成员A=0,则传入"A"或"0"获取 Enum1.A</param>
        public static T GetEnumInstance<T>(object member)
        {
            if (member != null)
            {
                string value = member.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("member");
                return (T)System.Enum.Parse(typeof(T), value, true);
            }
            return default(T);
        }

        public static T ToEnum<T>(this string str)
        {
            return GetEnumInstance<T>(str);
        }        
        #endregion
    }
}
