using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ferienhaus.Klassen
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public class EstateManager
    {
        private static EstateManager instance;
        public List<Estate> estates = new List<Estate>();

        private EstateManager()
        {

        }

        public static EstateManager getInstance()
        {
            if (instance == null)
            {
                instance = new EstateManager();
            }
            return instance;
        }


        public void addEstate(Estate estate)
        {
            estates.Add(estate);
            Data.Instance.write(estates);
            MessageBox.Show("Added Esate " + estate.EstateName, "INFO");
        }

        public void loadEstates()
        {
            this.estates = Data.Instance.read();
        }

        public List<Estate> checkAvailability(Estate reference)
        {
            loadEstates();
            //https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/conditional-operator

            List<Estate> foundEstates = new List<Estate>();

            foreach (Estate estate in this.estates)
            {

                if (estate.Bedrooms < reference.Bedrooms && reference.Bedrooms != null)
                {
                    Debug.WriteLine("Search Estate Bedrooms: " + reference.Bedrooms + "| current estate in list: " + estate.Bedrooms);
                    continue;
                }
                if (estate.Persons < reference.Persons && reference.Persons != null)
                {
                    Debug.WriteLine("Search Estate Persons: " + reference.Persons + "| current estate in list: " + estate.Persons);
                    continue;
                }
                if (estate.Price - 1 >= reference.Price && reference.Price != null)
                {
                    Debug.WriteLine("Search Estate Price: " + reference.Price + "| current estate in list: " + estate.Price);
                    continue;
                }
                if (estate.Region != reference.Region && reference.Region != null)
                {
                    Debug.WriteLine("Search Estate Region: " + reference.Region + "| current estate in list: " + estate.Region);
                    continue;
                }
                if (estate.isBooked(reference.BookingTimes[0]) == true && reference.BookingTimes != null)
                    continue;

                foundEstates.Add(estate);
               
            }

            return foundEstates;
        }
    }
}
