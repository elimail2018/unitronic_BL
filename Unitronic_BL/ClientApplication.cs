#define FullDebug

using System;
using System.Collections.Generic;

namespace ParkingSystem
{
    /// <summary>
    /// Factory Pattern Demo
    /// </summary>  
    public class ClientApplication
    {
        public static int testNumber;
        static void Main()
        {
            testing();
      
           
            Console.ReadKey();
        }

        static void testing()

        {
            //all params from web are primitive 
            parkingManager manager = new parkingManager();
            string userTicket;
            string shoudlBe;
            chekInResponse res;


            userTicket = "regular";
            shoudlBe = " shoud be regular ticket";
            //asked for regular ->dimension within regular ticket ->   shoud be regular ticket
             res = manager.checkIn("eli", "222", "053666444", "motorcycle", 1000, 1000, 1000, userTicket);
            
            // full CheckIn process details:
            // if ticket is valid - auto continue with completeCheckIn methhod.
            /// if ticket not valid - send question to the user to replace the ticket 
            /// save all checkin data on server cache- with the new suitable ticket 
            /// if the user agree - send back the userID only
            /// get back details from cache - and call checkInComplete method.
            /// 

            showResults(shoudlBe ,res);

            
            userTicket = "regular";
            shoudlBe = " replace ticket to value - cost diff = 50";
            //asked for regular ->dimension within value ticket ->   
             res = manager.checkIn("eli", "222", "053666444", "motorcycle", 2300, 2000, 1000, userTicket);
            showResults(shoudlBe ,res);


            userTicket = "regular";
            shoudlBe = "shoud replace to higher  VIP ticket(no dimension limit), cost diff = 150";
            //asked for regular -> car width 3000  ->
            res = manager.checkIn("eli", "222", "053666444", "motorcycle", 8000, 2000, 1000, userTicket);
            showResults(shoudlBe ,res);



            //////////valu ticket testing 
            ///
            userTicket = "value";
            shoudlBe = "  be Value ticket";
            //asked for value ticket  -> car width 2000  ->
            res = manager.checkIn("eli", "222", "053666444", "motorcycle", 2000, 2000, 1000, userTicket);
            showResults(shoudlBe ,res);

                 userTicket = "value";

            shoudlBe = " replace to higher  VIP ticket , cost dif =100";
            //asked for value ticket  -> car width 5000  ->
            res = manager.checkIn("eli", "222", "053666444", "motorcycle", 5000, 2000, 1000, userTicket);
            showResults(shoudlBe  ,res);
        }

        static void  showResults(string shoudlBeTitle  , chekInResponse res)
        {
            Console.WriteLine("\n=========== TEST NUMBER [" + (++testNumber).ToString() +  "  ] =============\n");
            string ticketStr;
            Console.WriteLine("should BE:==> " + shoudlBeTitle);
            ticketStr = (res.suitableTicket == null) ? "no suitable ticket" : res.suitableTicket.ToString();
            //Console.Write(ticketStr);
            Console.WriteLine("the user asked for :["
                + res.originalTicket.ticketType.ToString()
                + "] ticket. \n original cost:"
                + res.originalCost.ToString() 
                + " new ticket: [" +res.suitableTicket.ticketType.ToString() + "] "                + " new cost: [" 
                + res.newCost + "] cost differnece : ["
                + res.costDifference.ToString() + "]" 
                + "\n have to replace ticket : "
                + (res.tickeWasReplaced ? "not valid-need replace" :"was valid ticket")+ "\n");


        }
    }
}
