using GestionProduitPanier_AspNET.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Models
{
    public class Utilisateur
    {
        int id;
        string nom;
        string prenom;
        string email;
        string password;
        string role;

        public int Id { get => id; set => id = value; }

        [Required]
        public string Email { get => email; set => email = value; }

        [Required]
        [Column("PasswordHashed")]
        public string Password { get => password; set => password = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Role { get => role; set => role = value; }

        public Utilisateur()
        {
            Role = "user";
        }

        public bool Save()
        {
            DataContext.Instance.Utilisateurs.Add(this);
            DataContext.Instance.SaveChanges();
            return Id > 0;
        }

        public static Utilisateur GetUserByEmail(string email)
        {
            Utilisateur user = new Utilisateur();
            user = DataContext.Instance.Utilisateurs.FirstOrDefault(a => a.Email == email);
            return user;
        }
    }
}
