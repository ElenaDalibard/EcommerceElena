using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Word
    {
        int id;
        string expression;
        string translation;
        string language;

        public int Id { get => id; set => id = value; }
        public string Expression { get => expression; set => expression = value; }
        public string Translation { get => translation; set => translation = value; }
        public string Language { get => language; set => language = value; }
    }
}
