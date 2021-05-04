using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ferienhaus.Klassen
{
    public class BookingTime
    {
        public BookingTime(DateTime? startTime, DateTime? endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public DateTime? startTime { get; set; }

        public DateTime? endTime { get; set; }
    }
}
