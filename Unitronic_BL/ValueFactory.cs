using System.Collections.Generic;

namespace ParkingSystem
{
    class ValueFactory: TicketFactory
    {
        private int? _timeLimit;
        private int _cost;
        private Dimensions _dimensions;
        private string _lots;
        private List<VehicleClassType> _VehicleClassTypes;


        public ValueFactory(int? timeLimit, int cost, Dimensions dimensions, string lots, List<VehicleClassType> VehicleClassTypes )
        {
            _timeLimit = timeLimit;
            _cost = cost;
            _lots = lots;
            _dimensions = dimensions;
            _VehicleClassTypes = VehicleClassTypes;
        }

        public override Ticket GetTicket()
        {
            
            return new ValueTicket(_timeLimit, _cost, _dimensions, _lots , _VehicleClassTypes);
        }
    }
}
