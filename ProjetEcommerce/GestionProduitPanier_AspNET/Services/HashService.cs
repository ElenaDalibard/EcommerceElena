using GestionProduitPanier_AspNET.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Services
{
    public class HashService : IHash
    {
        public string GetHash(HashAlgorithm algo, string password)
        {
            byte[] hashData = algo.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                sBuilder.Append(hashData[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyHash(HashAlgorithm algo, string password, string hash)
        {
            string passwordHashed = GetHash(algo, password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(passwordHashed, hash) == 0;
        }
    }
}
