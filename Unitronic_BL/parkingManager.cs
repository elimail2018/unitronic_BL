using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingSystem
{
    public class LoopTicketResponse  {
        public  bool ticketNeedToBeReplaced { get; set; }
        
        public ITicket res_ticket { get; set; }
    }
    //===>TODO - convert this manager to singelton instance pattern
    public class parkingManager
    {

        Queue<TicketType> availableTickets;
        ITicket validTicket = null;
        public bool ticketReplace { get; set; }
        public parkingManager()
        {
            // var allTicketTypes = Enum.GetValues(typeof(TicketType));
            //initailze all available tickets in the parking system
            //var stack = new Stack<string>();
            //foreach (string ticket in arr)
            //    stack.Push(ticket);
            // availableTickets.Add("");
        }

        public LoopTicketResponse LoopSuitableTicket(ITicket nextTicket, Dimensions vehicleDimensions)
        {

            TicketType nextTicketType;
            bool validDimensions;
            if (nextTicket.maxDimensions == null) //no dimension limits-ticket is valid
            {
                validDimensions = true;
                validTicket = nextTicket;
            }
            else {
                validDimensions = nextTicket.maxDimensions.IsInRange(vehicleDimensions); //bool - dimension validation 

            }
            if (validDimensions)
            {
                validTicket = nextTicket;
                //Console.WriteLine("valid dimensions for vehicle " + my_vehicle.ToString());
            }
            else {
                ticketReplace = true;//first ticket was invalid 

                try
                {
                    nextTicketType = availableTickets.Dequeue();
                }
                catch (Exception)
                {
                    //queue is empty - no suitable tickets found
                    // throw;
                    return null;
                }
                nextTicket = concreteTicketFactory.getConcreteTicket(nextTicketType);
                LoopSuitableTicket(nextTicket, vehicleDimensions);//recurse
            }

            LoopTicketResponse response = new LoopTicketResponse()
            { ticketNeedToBeReplaced = ticketReplace, res_ticket = validTicket };

            return response;
        }
        public void VehicleCheckin()
        {
            //if (my_vehicle.checkIn("eli", "5621", "6723462784", VehicleType.Crossover, dimensions, ticket))
            //{
            //    Console.WriteLine("tikcet is not in range ");
            //    //find another ticket with in the range TO DO ->
            //}
            //else
            //{
            //    //find parking lot
            //    ParkingSpot spot = ticket.FindAvailableSpot(my_vehicle.VehicleClassType);
            //    if (spot == null)// couldnt find spot according to  ticket reserved  LOTS
            //    {   //regular, value , vip  - try to find suitable ticket
            //        ITicket ticket2 = concreteTicketFactory.getConcreteTicket(TicketType.regular);
            //    }
            //    else
            //    {
            //        spot.Park(my_vehicle);
            //    }
            //}
        }

        private LoopTicketResponse GetSuitableTicket(ITicket ticket, Dimensions dimensions)
        {
            //Convert tickettypes enum to Queue - for scanning all tickets 
            var list = Enum.GetValues(typeof(TicketType))
           .Cast<TicketType>()
           .Select(x => x);
            var filteredList = list.Where(w => w.ToString() != TicketType.Regular.ToString());
            availableTickets = new Queue<TicketType>(filteredList);//replace ticket options
            LoopTicketResponse loopResponse = LoopSuitableTicket(ticket, dimensions);
            Debug.WriteLine("found type :" + loopResponse.res_ticket.ticketType.ToString() + " cost:" + loopResponse.res_ticket.cost);
            return loopResponse;
        }
        private chekInResponse checkIn(string name, string id, string phone, VehicleType vehicleType, Dimensions dimensions, ITicket ticket) {
            chekInResponse response = new chekInResponse();
            var my_vehicle = VehicleFactory.Get(vehicleType);
            var userTicket = ticket;
            //create ticket list without the current ticket to find suitable ticket

            LoopTicketResponse loopResponse = GetSuitableTicket(ticket, dimensions);

            ITicket foundTicket = loopResponse.res_ticket;

            if (foundTicket != null)
            {
                int cost = foundTicket.cost - userTicket.cost;
                response.costDifference = cost;
                response.originalCost = userTicket.cost;
                response.newCost = foundTicket.cost;
                response.originalTicket = userTicket;
                response.suitableTicket = foundTicket;
                response.tickeWasReplaced = loopResponse.ticketNeedToBeReplaced;
            }


            //   //tesing
            //Debug.WriteLine (queue.Dequeue() ==TicketType.Regular);//true
            //Debug.WriteLine (queue.Dequeue() == TicketType.Regular);//false
            //Debug.WriteLine (queue.Dequeue() == TicketType.Regular);//false
            //Debug.WriteLine (queue.Dequeue() == TicketType.Regular);//que empty
            // VehicleType VehicleType = VehicleType.Crossover;
            // checkInVehicle(strig name, id, phone, VehicleType, dimensions, ticket);
            //Dimensions d1 = Dimensions.createDimension(100, 100, 100);
            //Dimensions d1 = Dimensions.createDimension(100, 100, 100);
            //Dimensions d2 = Dimensions.createDimension(100, 100, 200);
            //Console.WriteLine("in range = " + d1.isInRange(d2).ToString());
            //  ParkingLot pl = new Tick();
            // var freespots = pl.FindAvailableSpot();
            // var vehicle = VehicleFactory.Get(VehicleType.Crossover);
            // ITicket ticket = concreteTicketFactory.getConcreteTicket(TicketType.Regular);
            // Dimensions dimensions = Dimensions.createDimension(100, 300, 400);
            /// == > TODO
            /// convert FindAvailableSpot to recursive -==> findSutableTicket with list of 
            // car.validateDimensi
            //t3.ID = "moshe-truck";
            //  ITicket tik = concreteTicketFactory.getConcreteTicket("Regular");
            //  tik.validateDimensions(t1);
            //  avl1.Park(t1);
            //  ITicket vip = concreteTicketFactory.getConcreteTicket("vip");
            //  var avl2 = vip.FindAvailableSpot();
            //  avl2.Park(t2);
            //  ITicket val = concreteTicketFactory.getConcreteTicket("value");
            //  var avl3 = val.FindAvailableSpot();
            //  avl3.Park(t3);//locating class c empty space
            // int total = val.GetTotalSpots();
            //            testApp();
            //   Console.ReadKey();
            return response;
        }

        //if ticket was replace - the user should complete check out here after answer
        public bool completeCheckIn(string ID)
        {
            //save checkout details to user 

            return true;
        }


        public int checkOut(string ID , DateTime checkOutTime)
        {
            //get user row from DB - checkIn Date - and calculate
            return 0;
        }


        public  chekInResponse checkIn(string name, string id, string phone, string pVehicleType, int width, int height, int length, string pTicketType)
        {
             
            ///////if the ticket is not good for parking - the method will find another suitable ticket 
            ///and return it - for asking the user , the method will return the different cost .
            #region null checks  
            if (String.IsNullOrEmpty(name) )
            {
                throw new ArgumentNullException("name cannot be null.");
            }
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id cannot be null.");
            }
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be null.");
            }
            if (String.IsNullOrEmpty(pVehicleType))
            {
                throw new ArgumentNullException("VehicleType cannot be null.");
            }
            if (String.IsNullOrEmpty(pTicketType))
            {
                throw new ArgumentNullException("ticketType cannot be null.");
            }
            if (width ==0 || height ==0 || length == 0 )
            {
                throw new ArgumentNullException("vehicle dimensions cannot be 0.");
            }
            #endregion
            #region convert to complex types  
            TicketType ticketType = TicketType.Regular;
            /// primitive values from http get request -> convert to complex types
            /// 
            VehicleType VehicleType =VehicleType.Crossover;
            switch (pVehicleType)
            {
                case "moto":
                    VehicleType = VehicleType.Motorcycle;
                    break;
                case "suv":
                    VehicleType = VehicleType.SUV;
                    break;
                case "crossover":
                    VehicleType = VehicleType.Crossover;
                    break;
            }
            switch (pTicketType)
            {
                case "vip":
                    ticketType = TicketType.Vip;
                    break;
                case "Regular":
                    ticketType = TicketType.Regular;
                    break;
                case "value":
                    ticketType = TicketType.Value;
                    break;
            }
            #endregion
             Dimensions dimensions = Dimensions.createDimension(width,height,length);
            ITicket ticket = concreteTicketFactory.getConcreteTicket(ticketType);
            ITicket my_ticket = concreteTicketFactory.getConcreteTicket(ticketType);
            ///call the complex method
            return checkIn(name, id, phone, VehicleType, dimensions, my_ticket);
            }
            static void testing ()
        {
            //   Vehicle v = VehicleFactory.;
            // v.checkIn("eli", "222", "053666444", VehicleClassType.ClassA, 4000, 2000, 1000,"value");
            // var valid = v.validateTicket();
            //if (valid)
            //{
            //    Console.WriteLine("is valid ticket");
            //} else {
            //    Console.WriteLine("not  valid tikcet");
            //   v.replaceCurrentTicket("vip");
            // var valid2 =  v.validateTicket(); 
            //}
        }
    }
}
