using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace ExamenTI.Business.Util
{
    public class EncripUtil
    {
        public string GetMd5(string pass)
        {
            StringBuilder stringBuilder = new StringBuilder();
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pass);
            data = x.ComputeHash(data);
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }
    }
}
