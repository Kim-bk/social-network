using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Services
{
    public class Encryptor
    {
        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            // 1. Compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            // 2. Get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // 3. Change it into 2 hexadecimal digits  
                // for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
