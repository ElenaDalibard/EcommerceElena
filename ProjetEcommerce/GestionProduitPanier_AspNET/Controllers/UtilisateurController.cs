using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GestionProduitPanier_AspNET.Interface;
using GestionProduitPanier_AspNET.Models;
using GestionProduitPanier_AspNET.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace GestionProduitPanier_AspNET.Controllers
{
    public class UtilisateurController : Controller
    {
        IHash hash;
        public UtilisateurController(IHash _hash)
        {
            hash = _hash;
        }

        public IActionResult SignInLogInForm()
        {
            return View();
        }
        public IActionResult SignInForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSignIn([FromForm]Utilisateur user)
        {
            if (Utilisateur.GetUserByEmail(user.Email) != null)
            {
                ViewBag.Message = "Cet email existe déjà.";
                return View("SignInForm");
            }
            else
            {
                user.Password = hash.GetHash(SHA256.Create(), user.Password);
                user.Save();
                return RedirectToAction("FormLogin");
            }

        }

        public IActionResult FormLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitLogin([FromForm] string email, string password)
        {
            string passwordHashed = hash.GetHash(SHA256.Create(), password);
            Utilisateur user = DataContext.Instance.Utilisateurs.FirstOrDefault(u => u.Email == email && u.Password == passwordHashed);
            if(user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Prenom),
                    new Claim("FirstName", user.Nom),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Id", user.Id.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties option = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), option);
                return RedirectToAction("Acceuil", "Produit");
            }
            else
            {
                ViewBag.Message = "Votre mot de passe n'est pas bon.";
                return View("FormLogin");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Acceuil", "Produit");
        }

        public IActionResult AccesDenied()
        {
            ViewBag.Message = "Vous n'avez pas d'accès à cette page.";
            return View();
        }
    }
}
