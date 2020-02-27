using System.Linq;

namespace JsonModel.Util
{
    public static class StringUtil
    {
        /// <summary>
        /// 分离出换行
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] StringReplaceSplit(string value)
        {
            return value.Replace("\n", "").Split('\r');
        }

        /// <summary>
        /// 代码段组合为大驼峰
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string NameConverter(string[] strValue)
        {
            string result = "";
            //过滤
            foreach (var tempValue in strValue)
            {
                string value = tempValue.Trim();
                if(string.IsNullOrEmpty(value)) continue;

                //说明这一行估计是注释 { } 的东西
                if(value.StartsWith("//")|| value.StartsWith("{")|| value.StartsWith("}")) continue;

                string[] codeLine = value.Split(' ');

                //这一行估计是class
                if (codeLine.Contains("class")) continue;

                //可能有下划线。默认是带public之类的代码行
                string[] name = codeLine[2].Split('_');

                string tempStr = "";
                foreach (string part in name)
                {
                    tempStr = tempStr + part.Substring(0, 1).ToUpper() + part.Substring(1);
                }

                string lastCodeLine = string.Concat("public ", codeLine[1], " ", tempStr," ", "{ get;set; }");

                result = string.Concat(result, "/// <summary>\r\n/// \r\n/// </summary>\r\n[JsonProperty(\"",
                    codeLine[2], "\")]\r\n", lastCodeLine, "\r\n");
            }

            return result;
        }
    }
}
