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
        public List<Estate> estates;

        private EstateManager()
        {

        }

        public static EstateManager getInstance()
        {
            if (instance == null)
            {
                instance = new EstateManager();
                instance.estates = new List<Estate>();
            }
            return instance;
        }


        public void addEstate(Estate estate)
        {
            estates.Add(estate);
            saveEstates();
            MessageBox.Show("Added Esate " + estate.EstateName, "INFO");
        }

        public void loadEstates()
        {
            List<Estate> estatesFromFile = Data.Instance.read();
            if (estatesFromFile != null)
            {
                this.estates = estatesFromFile;
            }
        }

        public void saveEstates()
        {
            Data.Instance.write(estates);
        }

        public List<Estate> checkAvailability(Estate reference)
        {
            loadEstates();

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
                if (!estate.Region.Equals(reference.Region) && reference.Region != null)
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
