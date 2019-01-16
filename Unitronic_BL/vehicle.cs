using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingSystem
{
    abstract class Vehicle : IVehicle
    {
        public ITicket CurrentTicket { get; set; }
        public Dimensions VehicleDimensions { get; set; }
        public abstract VehicleClassType VehicleClassType { get; set; } //implemented by classA,classB,classC...
        public DateTime CheckInTime { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public string Phone { get; set; }
        public string ID { get; set; }
        //public bool checkIn(string name, string id, string phone, VehicleClassType VehicleType, int Vwidth, int Vheight, int Vlength, string ticketType)
        //{
        //    var dimensions = Dimensions.createDimension(Vwidth, Vheight, Vlength);
        //    var ticket = concreteTicketFactory.getConcreteTicket(ticketType);
        //    return this.CheckIn(name, id, phone, VehicleType, dimensions, ticket);
        //}
        public void replaceTicket(TicketType ticketType)
        {
            this.CurrentTicket = concreteTicketFactory.getConcreteTicket(ticketType);
        }
        public bool checkIn(string name, string id, string phone, VehicleType vehicleType,  Dimensions dimensions, ITicket ticket)
        {
            //chekin with ticket object
            this.CurrentTicket = ticket;
            bool validDimensions = (this.CurrentTicket.maxDimensions.IsInRange(this.VehicleDimensions)); //bool - dimension validation 
            //if (this.CurrentTicket.maxDimensions.isInRange(dimensions))
            //{
                this.OwnerName = name;
                this.ID = id;
                this.Phone = phone;
                //this.VehicleClassType = VehicleType;
                this.VehicleDimensions = dimensions;
                this.CurrentTicket = ticket;
            //}
            return validDimensions;
        }
    }
    //     public abstract string info { get; }
    //    public bool validateTicket()
    //    {
    //        if (CurrentTicket != null)
    //        {
    //            if (
    //                this.vehicleDimensions.isInRange(CurrentTicket.dimensions) &&
    //                CurrentTicket.VehicleClassTypes.Any(a => a.Equals(this.GetType().ToString().ToLower()))
    //              )
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    public bool findSuitableTicket()
    //    {
    //        if (CurrentTicket != null)
    //        {
    //            if (
    //                this.vehicleDimensions.isInRange(CurrentTicket.dimensions) &&
    //                CurrentTicket.VehicleClassTypes.Any(a => a.Equals(this.GetType().ToString().ToLower()))
    //              )
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    private ITicket _ticket;
    //    public void replaceCurrentTicket(string ticketType)
    //    {
    //        this.CurrentTicket = concreteTicketFactory.getConcreteTicket(ticketType);
    //    }
    //    public ITicket Ticket
    //    {
    //        get { return _ticket; }
    //        set { _ticket = value; }
    //    }
    //}
}
