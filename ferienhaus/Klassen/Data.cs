using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ferienhaus.Klassen
{
    public class Data
    {

        private static Data instance = null;
        private static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ferienhaus";


        private Data()
        {
        }

        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                    instance.init();
                }
                return instance;
            }
        }

        public void init()
        {
            if (!Directory.Exists(appData))
            {
                Directory.CreateDirectory(appData);
            }
            if (!File.Exists(appData + "\\estate_data.json"))
            {
                File.Create(appData + "\\estate_data.json");
            }
        }

        public List<Estate> read()
        {
            using (StreamReader file = File.OpenText(appData + "\\estate_data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Estate> estates = (List<Estate>)serializer.Deserialize(file, typeof(List<Estate>));
                return estates;
            }
        }

        public void write(List<Estate> OBJ)
        {

            using (StreamWriter file = File.CreateText(appData + "\\estate_data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, OBJ);
            }
        }
    }
}
