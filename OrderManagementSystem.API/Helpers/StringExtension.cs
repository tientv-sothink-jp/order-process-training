using System;
using System.Security.Cryptography;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class StringExtension
    {
        public static string ToMD5Hash(this string inputText)
        {
            if (string.IsNullOrEmpty(inputText)) return "";

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(inputText));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            
            return hash.ToString();
        }

        public static string RemoveVietnameseTones(this string inputText)
        {
            if (string.IsNullOrEmpty(inputText)) return inputText;
            inputText = inputText.ToLower();
            string[] vietnameseChar = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < vietnameseChar.Length; i++)
            {
                for (int j = 0; j < vietnameseChar[i].Length; j++)
                {
                    inputText = inputText.Replace(vietnameseChar[i][j], vietnameseChar[0][i - 1]);
                }
            }
            return inputText;
        }
    }
}
