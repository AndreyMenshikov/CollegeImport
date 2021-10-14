using System;
using System.Linq;

namespace CollegeImport
{
    public static class StringHelper
    {

        public static int[] ParseIndex(string index)
        {
            return index.Split('_').Select(x => Convert.ToInt32(x)).ToArray();
        }

        public static string CreateIndex(int n1, int n2, int n3)
        {
            return String.Format("{0}_{1}_{2}", n1, n2, n3);
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string[] SplitBy(string str, char c)
        {
            string res = System.Text.RegularExpressions.Regex.Replace(str, c + "+", c.ToString());
            return res.Split(c).Where(x => !String.IsNullOrEmpty(x)).ToArray();
        }

        public static string ByteArrayToImageUrl(byte[] array)
        {
            if (array == null) return "";
            string base64String = Convert.ToBase64String(array, 0, array.Length);
            return "data:image/jpeg;base64," + base64String;
        }
    }
}