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

        public Estate read()
        {
            using (var reader = new StreamReader(File.OpenRead(@".\Data.json")))
            {
                return (Estate)JsonConvert.DeserializeObject(reader.ReadToEnd());
            }

        }

        public void write(Estate OBJ)
        {

            using (var write = new StreamWriter(File.OpenWrite(@".\Data.json")))
            {
                string estateJson = JsonConvert.SerializeObject(OBJ);

                write.Write(estateJson);
            }


        }
    }


}
