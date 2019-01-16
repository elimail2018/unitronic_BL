using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingSystem
{
    public class chekInResponse
    {
        public  bool tickeWasReplaced;
        public ITicket originalTicket { get; set; }
        public int originalCost { get; set; }
        public int costDifference { get; set; }
        public ITicket suitableTicket { get; set; }
        public int newCost { get; set; }


    }
}
