using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private List<Estate> estates = new List<Estate>();

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
            this.estates.Add(estate);
        }

        // mach mal lieber einen negativ-check in der schleife. Falls bedingung nicht erfüllt dann break;
        // ist sauberer als if in if in if ...



        // ich würde das nach auschlussverfahren probieren. wenn ein attribut nicht übereinstimmtt dann mus der rest auch nicht abgechekct werden
        //achso verstehe

        //ne ich glaube das geht nicht nach ausschlussverfahren
        //er muss ja durchiterieren durch sämtliche attribute. 
        //es gibt für einen attribut keinen state der die abfrage beenden würde

        // besser ? 

        //discord? 


        public List<Estate> checkAvailability(Estate reference)
        {

            //https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/conditional-operator

            List<Estate> List = new List<Estate>();

            foreach (Estate estate in this.estates)
            {

                if(estate.Bedrooms != reference.Bedrooms && reference.Bedrooms != null)
                    continue;
                if (estate.Persons != reference.Persons && reference.Persons != null)
                    continue;
                if (estate.Price != reference.Price && reference.Price != null)
                    continue;
                if (estate.Region != reference.Region && reference.Region != null)
                    continue;
                if (estate.CustomerID != reference.CustomerID && reference.CustomerID != null)
                    continue;
                if (estate.isBooked(reference.BookingTimes[0]) == true && reference.BookingTimes != null)
                    continue;



                if (estate.Bedrooms == reference.Bedrooms || estate.Bedrooms == null)
                {
                    if (estate.Persons == reference.Persons || estate.Persons == null)
                    {
                        if (estate.Price == reference.Price || estate.Price == null)
                        {
                            if (estate.Region == reference.Region || estate.Region == "")
                            {
                                if (estate.CustomerID == reference.CustomerID || estate.CustomerID == "")
                                {
      
                                            List.Add(estate);
                                }
                            }
                        }
                    }
                }
            }


            return List;
        }
    }
}
