using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingSystem
{
   
    
    public class ParkingLot
    {
        List<ParkingSpot> _parkingSpots;
       // Dictionary<string, ParkingSpot> usedSpot;
        public ParkingLot()
        {
           // usedSpot = new Dictionary<string, ParkingSpot>();
            _parkingSpots = new List<ParkingSpot>();
            // 10 parking spots; 2 free; 6 Regular Paid; 2 Handicapped Free
            //2 free
            for (int i = 0; i < 60; i++)
            {
                //IVehicle truck = new Truck();
                var p = new ParkingSpot(); //60 empty places
                //if (i < 30)
                //{
                //    truck.ID = i.ToString();
                //    var parkingSpot = p.Park(truck);
                //    usedSpot.Add(truck.ID, p);
                //}
               _parkingSpots.Add (p) ;
            }
        }
        public ParkingSpot FindAvailableSpot(VehicleClassType carClass)
        {
            return this._parkingSpots.Find(p => p.IsAvailable );
        }
        public ParkingSpot FindParkedSpot(string id)
        {
            return this._parkingSpots.Find(p => p.ParkedVehicle.ID==id);
        }
        //public void unParkSpot(string ID)
        //{
        //    ParkingSpot v = this.usedSpot[ID];//using direct access to all parked spots
        //    v.UnPark();
        //    this.usedSpot.Remove(ID);
        //}
        public int GetAvailableSpotsCount()
        {
            return this._parkingSpots.Count(p => p.IsAvailable);
        }
        public int GetTotalSpots()
        {
            return this._parkingSpots.Count;
        }
    }
    public class ParkingSpot
    {
        public int SpotLocation   { get; set; }
        public bool IsAvailable { get; set; }
        public IVehicle ParkedVehicle { get; set; }
         ITicket Ticket { get; set; }
        public ParkingMeter Meter { get; set; }
        public ParkingSpot Park(IVehicle vehicle)
        {
            if (this.ParkedVehicle == null)
            {
                this.ParkedVehicle = vehicle;
                this.IsAvailable = false;
                return this;
            }
            else
            {
                throw new Exception("Parking Spot is Taken. Cannot Park here!");
            }
        }
        public ParkingSpot UnPark()
        {
            if (this.ParkedVehicle != null)
            {
                this.ParkedVehicle = null;
                this.IsAvailable = true;
                return this;
            }
            else
            {
                throw new Exception("cant find the parking vehicle");
            }
        }
        public ParkingSpot()//empty parking
        {
            this.IsAvailable = true;
            //this.IsFree = true;
        }
        public ParkingSpot(int spotLocation)
        {
            this.SpotLocation = spotLocation; // 1-10,11-30,31-60
            this.IsAvailable = true;
            this.Meter = new ParkingMeter();
        }
    }
    public class ParkingMeter
    {
        public DateTime EndTime { get; set; }
        public int HoursRemaining
        {
            get
            {
                if (DateTime.Now >= EndTime)
                    return 0;
                else
                    return (EndTime - DateTime.Now).Hours;
            }
        }
        public int ParkingIntervalHours
        {
            get
            {
                return 1;
            }
        }
        public void Pay()
        {
            EndTime = DateTime.Now.AddHours( ParkingIntervalHours);
        }
    }
}
