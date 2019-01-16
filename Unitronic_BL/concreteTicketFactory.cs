//#define FullDebug
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{

    public enum TicketType
    {
        Regular = 0,
        Value = 1,
        Vip = 2

    }
    class concreteTicketFactory
    {

       

        public static ITicket getConcreteTicket(TicketType ticketType)
        {
            
            TicketFactory factory = null;
            List<VehicleClassType> VehicleClassTypes = null;
           
            switch (ticketType)
            {
                case TicketType.Vip:
                    VehicleClassTypes = new List<VehicleClassType>();
                    VehicleClassTypes.Add(VehicleClassType.ClassA);
                    VehicleClassTypes.Add(VehicleClassType.ClassB);
                    
                    factory = new VipFactory(null, 200, null, "1-10", VehicleClassTypes);//no time limit//no dimension limit
                    break;
                case TicketType.Regular:

                    VehicleClassTypes = new List<VehicleClassType>();
                    VehicleClassTypes.Add(VehicleClassType.ClassA);
                    factory = new RegularFactory(24, 50, Dimensions.createDimension(2000, 2000, 3000), "31-60", VehicleClassTypes);
                    break;
                case TicketType.Value:
                    //VehicleClassTypes => null 



                    factory = new ValueFactory(72, 100, Dimensions.createDimension(2400, 2500, 5000), "11-30", VehicleClassTypes);
                    break;
                default:
                    break;
            }

            if (factory == null)
            {
                Console.WriteLine("not valid");
                Console.ReadKey();
                return null;
            }

           

            ITicket Ticket = factory.GetTicket();
            if (Ticket != null)
            {
               

                string VehicleClassTypesString = "none";
                string dimenssionString = "none";
                if (Ticket.maxDimensions != null)
                    dimenssionString = Ticket.maxDimensions.ToString();
                if (Ticket.VehicleClassTypes != null)
                    VehicleClassTypesString = string.Join(",", Ticket.VehicleClassTypes.ToArray());



#if (FullDebug)

                Console.WriteLine("\nYour ticket details are below : \n");
                Console.WriteLine("Type: {0}\ntime Limit: {1}\n cost: {2} \n classes:{3} \n dimensions:{4}",
                    Ticket.ticketType, Ticket.timeLimit, Ticket.cost, VehicleClassTypesString, dimenssionString);
#endif
                return Ticket;
            }
            else
            {
                Console.Write("not found");
                return null;
            }
        }

    }
}
