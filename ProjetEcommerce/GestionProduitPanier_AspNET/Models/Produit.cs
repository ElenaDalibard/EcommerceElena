using GestionProduitPanier_AspNET.Interface;
using GestionProduitPanier_AspNET.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Produit
    {
        int id;
        string titre;
        string description;
        decimal prix;
        int quantity;
        List<Image> images;
        //static SqlCommand command;
        //static SqlDataReader reader;


        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public List<Image> Images { get => images; set => images = value; }

        public Produit()
        {
            Images = new List<Image>();
        }

        public virtual bool Save()
        {
            DataContext.Instance.Produits.Add(this);
            DataContext.Instance.SaveChanges();
            return Id > 0;
        }

        public void Update()
        {
            foreach (Produit a in DataContext.Instance.Produits)
            {
                if (a.Id == Id)
                {
                    a.Images = Images;
                    a.Titre = Titre;
                    a.Description = Description;
                }
            }
            DataContext.Instance.SaveChanges();
        }

        public static List<Produit> GetProduitsByTitre(string titre = null)
        {
            List<Produit> produits = new List<Produit>();
            if (titre != null)
            {
                produits = DataContext.Instance.Produits.Include(a => a.Images).Where(a => a.Titre.Contains(titre)).ToList();
            }
            else
            {
                produits = DataContext.Instance.Produits.Include(a => a.Images).ToList();
            }
            return produits;
        }

        public static Produit GetProduitById(int id)
        {
            Produit produit = new Produit();
            produit = DataContext.Instance.Produits.Include(a => a.Images).FirstOrDefault(a => a.Id == id);
            return produit;
        }

        public static Produit GetProduitByImage(int id_image)
        {
            Produit produit = new Produit();
            foreach (Produit p in DataContext.Instance.Produits)
            {
                foreach (Image i in p.Images)
                {
                    if (i.Id == id_image)
                    {
                        produit = p;
                    }
                }
            }
            //produit = DataContext.Instance.Produits.Include(a => a.Images).Where(a => a.Images.FirstOrDefault(i=>i.Id==id_image));
            return produit;
        }


        // ----- Méthodes SQL
        //public virtual bool Save()
        //{
        //    string request = "INSERT INTO Produit(titre, description, prix, quantity) " +
        //        "OUTPUT INSERTED.ID values (@titre, @description, @prix, @quantity)";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@titre", Titre));
        //    command.Parameters.Add(new SqlParameter("@description", Description));
        //    command.Parameters.Add(new SqlParameter("@prix", Prix));
        //    command.Parameters.Add(new SqlParameter("@quantity", Quantity));
        //    Connection.Instance.Open();
        //    Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    if (Id > 0)
        //    {
        //        foreach (Image i in Images)
        //        {
        //            i.Save(Id);
        //        }
        //    }
        //    return Id > 0;
        //}

        //public bool Update()
        //{
        //    string request = "UPDATE Produit set titre=@titre, description=@description, prix=@prix, quantity=@quantity where id=@id";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@titre", Titre));
        //    command.Parameters.Add(new SqlParameter("@description", Description));
        //    command.Parameters.Add(new SqlParameter("@prix", Prix));
        //    command.Parameters.Add(new SqlParameter("@quantity", Quantity));
        //    command.Parameters.Add(new SqlParameter("@id", Id));
        //    Connection.Instance.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return nbRow == 1;
        //}

        //public static List<Produit> GetProduitsByTitre(string titre = null)
        //{
        //    List<Produit> produits = new List<Produit>();
        //    string request = "SELECT * FROM Produit";
        //    if (titre != null)
        //    {
        //        request += " where titre like @titre";
        //    }
        //    command = new SqlCommand(request, Connection.Instance);
        //    if (titre != null)
        //    {
        //        command.Parameters.Add(new SqlParameter("@titre", "%" + titre + "%"));
        //    }
        //    Connection.Instance.Open();
        //    reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Produit p = new Produit()
        //        {
        //            Id = reader.GetInt32(0),
        //            Titre = reader.GetString(1),
        //            Description = reader.GetString(2),
        //            Prix = reader.GetDecimal(3),
        //            Quantity = reader.GetInt32(4),
        //        };
        //        produits.Add(p);
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    foreach (Produit p in produits)
        //    {
        //        p.Images = Image.GetImagesByProduit(p.Id);
        //    }
        //    return produits;
        //}

        //public static Produit GetProduitById(int id)
        //{
        //    Produit produit = new Produit();
        //    string request = "SELECT * FROM Produit where id = @id";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@id", id));
        //    Connection.Instance.Open();
        //    reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        produit.Id = id;
        //        produit.Titre = reader.GetString(1);
        //        produit.Description = reader.GetString(2);
        //        produit.Prix = reader.GetDecimal(3);
        //        produit.Quantity = reader.GetInt32(4);
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    produit.Images = Image.GetImagesByProduit(produit.Id);
        //    return produit;
        //}

        //public static Produit GetProduitByImage(int id_image)
        //{
        //    Produit produit = new Produit();
        //    string request = "SELECT * FROM Produit as p inner join Image as i on p.id=i.id_produit WHERE i.id = @id_image";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@id_image", id_image));
        //    Connection.Instance.Open();
        //    reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        produit.Id = reader.GetInt32(0);
        //        produit.Titre = reader.GetString(1);
        //        produit.Description = reader.GetString(2);
        //        produit.Prix = reader.GetDecimal(3);
        //        produit.Quantity = reader.GetInt32(4);
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return produit;
        //}
    }
}
