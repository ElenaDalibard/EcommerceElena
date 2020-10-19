using GestionProduitPanier_AspNET.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Services
{
    public class SaveErreurs : ISaveErreurs
    {
        public void WriteErrors(Exception ex)
        {
            List<string> liste;
            string pathToFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");

            if (File.Exists(Path.Combine(pathToFolder, "errors.json")))
            {
                StreamReader reader = new StreamReader(Path.Combine(pathToFolder, "errors.json"));
                liste = JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());
                reader.Close();
            }
            else
            {
                liste = new List<string>();
            }

            liste.Add(ex.Message);

            StreamWriter writer = new StreamWriter(Path.Combine(pathToFolder, "errors.json"));
            writer.WriteLine(JsonConvert.SerializeObject(liste));
            writer.Close();
        }
    }
}
