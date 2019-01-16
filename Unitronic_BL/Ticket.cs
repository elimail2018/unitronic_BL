using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    /// <summary>
    /// The 'Product' Abstract Class
    /// </summary>
    /// 
    abstract class Ticket: ITicket
    {
        public List<ParkingSpot> _parkingSpots { get; set; }//lots
        public abstract ParkingSpot FindAvailableSpot(VehicleClassType carClass);
        public abstract string ticketType { get; }
        public abstract int? timeLimit { get; set; }
        public abstract int cost { get; set; }
        public abstract Dimensions maxDimensions { get; set; }
        public abstract string lots { get; set; }
        public abstract List<VehicleClassType> VehicleClassTypes {get ; set;}
        
        int GetTotalSpots { get; set; }

        public Ticket()//initialize empty 60 lots 
        {
            _parkingSpots = new List<ParkingSpot>();
            for (int i = 0; i < 60; i++)
            {
                var p = new ParkingSpot(i);//cretae 60 empty spots
                _parkingSpots.Add(p);
            }

           

        }


        public int CompareTicketPrice(ITicket ticket)
        {

           // Math.Abs()
            return 0;
        }






        public int GetAvailableSpotsCount()
        {
            return this._parkingSpots.Count(p => p.IsAvailable);
        }
       
       

        int ITicket.GetTotalSpots()
        {
            return this._parkingSpots.Count;
        }

      
    }
}
