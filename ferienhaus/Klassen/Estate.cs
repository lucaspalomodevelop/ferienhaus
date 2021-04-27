using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ferienhaus.Klassen
{
    public class Estate {
        public int? Bedrooms { get; set; }
        public int? Persons { get; set; }
        public double? Price { get; set; }
        public string Region { get; set; }
        public string CustomerID { get; set; }
        public List<BookingTime> BookingTimes { get; set; }
        public string EstateName { get; set; }


        public Estate()
        {

        }
        public Estate(string estateName, int? bedrooms, int? persons, double? price, string region, string customerID, List<BookingTime> bookingTimes)
        {
            Bedrooms = bedrooms;
            Persons = persons;
            Price = price;
            Region = region;
            CustomerID = customerID;
            BookingTimes = bookingTimes;
            EstateName = estateName;
        }
        /*if((start < bisDat && start > vonDat) || (ende < bisDat && ende > vonDat) || (start < vonDat && ende > bisDat)) {
        frei = false;
			}*/
    public bool isBooked(BookingTime BT)
        {
            foreach (var item in BookingTimes)
            {
                if (!((item.startTime <= BT.startTime && item.endTime <= BT.startTime) || (item.startTime >= BT.endTime && item.endTime >= BT.endTime)))
                {
                    return true;
                }
            }
            return false;
        }

    }
}