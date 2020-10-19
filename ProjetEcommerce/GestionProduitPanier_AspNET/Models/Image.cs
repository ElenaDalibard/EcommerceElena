using GestionProduitPanier_AspNET.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Image
    {
        int id;
        string url;
        //static SqlCommand command;
        //static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }

        public static Image GetImageById(int id)
        {
            Image image = new Image();
            image = DataContext.Instance.Images.FirstOrDefault(a => a.Id == id);
            return image;
        }

        //public bool Save(int id_produit)
        //{
        //    string request = "INSERT INTO Image(id_Produit, url) " +
        //        "OUTPUT INSERTED.ID values (@id_Produit, @url)";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@id_Produit", id_produit));
        //    command.Parameters.Add(new SqlParameter("@url", Url));
        //    Connection.Instance.Open();
        //    Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return Id > 0;
        //}

        //public bool Update()
        //{
        //    string request = "UPDATE Image set url=@url where id=@id";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@url", Url));
        //    command.Parameters.Add(new SqlParameter("@id", Id));
        //    Connection.Instance.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return nbRow == 1;
        //}

        //public static bool Delete(int id)
        //{
        //    string request = "DELETE Image where id=@id";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@id", id));
        //    Connection.Instance.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return nbRow == 1;
        //}

        //public static List<Image> GetImagesByProduit(int id_produit)
        //{
        //    List<Image> images = new List<Image>();
        //    string request = "SELECT id, url FROM Image WHERE id_produit=@id_produit";
        //    command = new SqlCommand(request, Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@id_produit", id_produit));
        //    Connection.Instance.Open();
        //    reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Image i = new Image()
        //        {
        //            Id = reader.GetInt32(0),
        //            Url = (reader.GetString(1).Contains("http")) ? reader.GetString(1) : @"http://localhost:64022/" + reader.GetString(1),
        //            //Id_Produit = id_produit
        //        };
        //        images.Add(i);
        //    }
        //    reader.Close();
        //    command.Dispose();

        //    Connection.Instance.Close();
        //    return images;
        //}
    }
}
