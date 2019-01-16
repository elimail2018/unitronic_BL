using System;
using System.Collections.Generic;
namespace ParkingSystem
{
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class RegularTicket : Ticket
    {
        private readonly string _ticketType;
        private int? _timeLimit;
        private int _cost;
        private Dimensions _dimensions;
        private string _lots;
        private List<VehicleClassType> _VehicleClassTypes;
        public RegularTicket(int? timeLimit, int cost, Dimensions dimensions, string lots, List<VehicleClassType> VehicleClassTypes)
        {
            _ticketType = "regular";
            _timeLimit = timeLimit;
            _cost = cost;
            _dimensions = dimensions;
            _lots = lots;
            _VehicleClassTypes = VehicleClassTypes;
        }
        public override string ticketType
        {
            get { return _ticketType; }
        }
        public override int? timeLimit
        {
            get { return _timeLimit; }
            set { _timeLimit = value; }
        }
        public override int cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public override string lots {
            get { return lots; }
            set { _lots = value; }
        }
        public override Dimensions maxDimensions {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        public override List<VehicleClassType> VehicleClassTypes
        {
            get { return _VehicleClassTypes; }
            set { VehicleClassTypes = value; }
        }
        public override ParkingSpot FindAvailableSpot(VehicleClassType carClass)
        {
            return this._parkingSpots.Find(p => p.IsAvailable && p.SpotLocation >= 31 && p.SpotLocation <= 60);
        }
    }
}
