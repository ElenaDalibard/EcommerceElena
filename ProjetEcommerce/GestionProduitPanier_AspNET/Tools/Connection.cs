using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Tools
{
    class Connection
    {
        private static SqlConnection _instance;
        private static object _lock = new object();
        public static SqlConnection Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        // Pour la maison
                        _instance = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acer\Desktop\FullStack\Cours\FullStackCoursElena\DotNet\coursDotNet\GestionProduitPanier_AspNET\ProduitsPanier.mdf;Integrated Security=True;Connect Timeout=30");

                        // Pour la classe
                        //_instance = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrateur\Documents\Elena\FullStackCoursElena\DotNet\coursDotNet\GestionProduitPanier_AspNET\Produit_Panier.mdf;Integrated Security=True;Connect Timeout=30");
                    }
                    return _instance;
                }
            }
        }

        private Connection()
        {
           
        }
    }
}
