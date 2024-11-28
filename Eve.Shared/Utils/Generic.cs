using System.Text;

namespace Eve.Shared.Utils
{
    public static class Generic
    {
        public static string StringToBase64(string str)
        {
            if (str == null || str == "")
                return "";

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string Base64ToString(string base64)
        {
            if (base64 == null || base64 == "")
                return "";

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
