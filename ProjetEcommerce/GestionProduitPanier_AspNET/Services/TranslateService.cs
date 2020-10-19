using GestionProduitPanier_AspNET.Interface;
using GestionProduitPanier_AspNET.Models;
using GestionProduitPanier_AspNET.Tools;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Services
{
    public class TranslateService : ITranslate
    {
        //static SqlCommand command;
        //static SqlDataReader reader;
        private IHttpContextAccessor accessor;

        public TranslateService(IHttpContextAccessor _accessor) 
            {
            accessor = _accessor;
            }


        public string Translate(string expression)
        {
            string langue = accessor.HttpContext.Session.GetString("Langue");
            if (langue == null)
            {
                langue = "FR";
            }
            string translation = expression;
            Word word = DataContext.Instance.Translation.FirstOrDefault(a => a.Expression == expression && a.Language == langue);
            if(word != null)
            {
                translation = word.Translation;
            }

            //string request = "SELECT Value FROM Translate where mot = @mot AND langue=@langue";
            //command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@mot", expression));
            //command.Parameters.Add(new SqlParameter("@langue", langue));
            //Connection.Instance.Open();
            //reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    translation = reader.GetString(0);
            //}
            //reader.Close();
            //command.Dispose();
            //Connection.Instance.Close();

            return translation;
        }

        public void ChangeLangue(string langue)
        {
            if(langue != null)
            {
                accessor.HttpContext.Session.SetString("Langue", langue);
            }
        }
    }
}
