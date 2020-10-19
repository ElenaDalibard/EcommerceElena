using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Interface
{
    public interface ITranslate
    {
        string Translate(string expression);
        void ChangeLangue(string langue);
    }
}
