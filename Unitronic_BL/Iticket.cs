using System.Collections.Generic;

namespace ParkingSystem
{
     public interface ITicket
    {
        
        List<ParkingSpot> _parkingSpots { get; set; }//lots
        ParkingSpot FindAvailableSpot(VehicleClassType carClass);
       // ParkingSpot AddAvailableTicketType(TicketType ticketType);
        int CompareTicketPrice(ITicket ticket);
        int GetTotalSpots();
        string ticketType { get; }
          int? timeLimit { get; set; }
          int cost { get; set; }
          Dimensions maxDimensions { get; set; }
          string lots { get; set; }

          
          List<VehicleClassType> VehicleClassTypes { get; set; }


    }
}