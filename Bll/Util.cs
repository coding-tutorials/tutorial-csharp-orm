using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;


namespace Bll
{
    public class Util
    {
        /// <summary>
        /// Encode text to MD5
        /// </summary>
        /// <param name="text"></param>
        /// <author>(leonardiwagner@gmail.com)</author>
        /// <returns></returns>
        public static String EncodeMD5(String text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                //Declarations
                Byte[] originalBytes;
                Byte[] encodedBytes;
                MD5 md5;

                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
                md5 = new MD5CryptoServiceProvider();
                originalBytes = ASCIIEncoding.Default.GetBytes(text);
                encodedBytes = md5.ComputeHash(originalBytes);

                //Convert encoded bytes back to a 'readable' string
                return BitConverter.ToString(encodedBytes).Replace("-", "");
            }
            else
            {
                return String.Empty;
            }
        }

    }
}
