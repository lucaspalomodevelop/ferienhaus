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
                }
                return instance;
            }
        }

        public List<Estate> read()
        {
            using (StreamReader file = File.OpenText(@".\Data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Estate> estates = (List<Estate>)serializer.Deserialize(file, typeof(List<Estate>));
                return estates;
            }
        }

        public void write(List<Estate> OBJ)
        {

            using (StreamWriter file = File.CreateText(@".\Data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, OBJ);
            }
        }
    }
}
