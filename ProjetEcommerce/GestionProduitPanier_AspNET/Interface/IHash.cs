using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Interface
{
    public interface IHash
    {
        string GetHash(HashAlgorithm algo, string password);
        bool VerifyHash(HashAlgorithm algo, string password, string hash);
    }
}
