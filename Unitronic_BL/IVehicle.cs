using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IVehicle
    {
        ITicket CurrentTicket { get; set; }

        Dimensions VehicleDimensions { get; set; }
        VehicleClassType VehicleClassType { get; set; }
        DateTime CheckInTime { get; set; }
        string OwnerName { get; set; }
        string OwnerPhone { get; set; }
        string Phone { get; set; }
        string ID { get; set; }


        bool checkIn(string name, string id, string phone, VehicleType vechileType, Dimensions dimensions, ITicket ticket);


    }
}
