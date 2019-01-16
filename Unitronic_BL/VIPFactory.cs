using System.Collections.Generic;

namespace ParkingSystem
{
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class VipFactory : TicketFactory
    {
        private int? _timeLimit;
        private int _cost;
        private Dimensions _dimensions;
        private string _lots;
        private List<VehicleClassType> _VehicleClassTypes;

        public VipFactory()
        {
        }

        public VipFactory(int? timeLimit, int cost, Dimensions dimensions, string lots,  List<VehicleClassType> VehicleClassTypes)
        {
            _timeLimit = timeLimit;
            _cost = cost;
            _lots = lots;
            _dimensions = dimensions;
            _VehicleClassTypes = VehicleClassTypes;
        }

        public override Ticket GetTicket()
        {
            return new VIPTicket(_timeLimit, _cost, _dimensions, _lots, _VehicleClassTypes);
        }
    }
}
