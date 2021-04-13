using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ferienhaus.klassen
{
    class CSV
    {

        public static object ReadData()
        {

            return new object();
        }

        public static void WriteData(object obj)
        {

            var reader = new StreamReader(File.OpenRead(@"D:\New folder\Data.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
                foreach (var coloumn1 in listA)
                {
                    Console.WriteLine(coloumn1);
                }
                foreach (var coloumn2 in listA)
                {
                    Console.WriteLine(coloumn2);
                }
            }


        }

    }
}
