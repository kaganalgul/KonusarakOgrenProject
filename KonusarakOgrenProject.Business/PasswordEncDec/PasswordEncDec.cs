using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.PasswordEndDec
{
    public class PasswordEncDec
    {
        public static string Key = "@S3cr)3t!.,"; // SecretKey. In real time project this value must be taken from secret.json with IConfiguration. Otherwise, it can be easily seen by bad people(HACKERS!) :)

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
            {
                return "";
            }
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}
