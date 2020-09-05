using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceElena.Outils
{
    public class IdProdTotalVM
    {
        public string nomprod { get; set; }
        public string url { get; set; }
        public int idprod { get; set; }
        public double total { get; set; }
        public double? prix { get; set; }

    }
    public class TopListe
    {
        public List<IdProdTotalVM> ListProds { get; set; }
    }


    public class IdUserList
    {
        public int iduser { get; set; }
        public string nomuser { get; set; }
        public string prenomuser { get; set; }
        public double? prixtotal { get; set; }
        public string emailuser { get; set; }
        public string telephone { get; set; }
        public string paysuser { get; set; }
        public string villeuser { get; set; }
    }

    public class BestListe
    {
        public List<IdUserList> ListUsers { get; set; }
    }
}

