using GestionProduitPanier_AspNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Tools
{
    public class DataContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Word> Translation { get; set; }

        private static DataContext instance;

        public static DataContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataContext();
                }
                return instance;
            }
        }

        public DataContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Dans la classe
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrateur\Documents\Elena\FullStackCoursElena\DotNet\coursDotNet\Entity.mdf;Integrated Security=True;Connect Timeout=30");

            //Dans la maison
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acer\Desktop\Code\Examples_MVC\ProjetEcommerce\Produits_Entity.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
