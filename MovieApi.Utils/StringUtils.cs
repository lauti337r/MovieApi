using System;
using System.Security.Cryptography;
using System.Text;

namespace MovieApi.Utils
{
    public static class StringUtils
    {
        public static string Hash(string input)
        {
            string output = string.Empty;


            using (var alg = SHA512.Create())
            {
                var hashedBytes = alg.ComputeHash(Encoding.UTF8.GetBytes(input));

                output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return output;
        }
    }
}
