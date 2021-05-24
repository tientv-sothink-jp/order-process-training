using System;
using System.Security.Cryptography;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class StringExtension
    {
        public static string ToMD5Hash(this string inputText)
        {
            if(inputText == "" || inputText == null)
            {
                return "";
            }
            try
            {
                StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(inputText));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
