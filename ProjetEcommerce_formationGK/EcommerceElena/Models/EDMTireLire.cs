namespace EcommerceElena.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMTireLire : DbContext
    {
        public EDMTireLire()
            : base("name=EDMTireLire")
        { }

        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailCommande> DetailCommandes { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>()
                .HasMany(e => e.Factures)
                .WithRequired(e => e.Commande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.telephoneFourn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.sexe)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
