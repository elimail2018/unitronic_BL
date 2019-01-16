using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParkingSystem
{
    class ClassA : Vehicle
    {
        public override VehicleClassType VehicleClassType { get => VehicleClassType; set => this.VehicleClassType = VehicleClassType.ClassA;  }
        public override string ToString()
        {
            {
                return "ClassA" + base.ToString();
            }
        }
        public VehicleClassType getVehicleClass()
        {
            {
                return VehicleClassType.ClassA;
            }
        }
    }
    class ClassB : Vehicle
    {
        public override VehicleClassType VehicleClassType { get => VehicleClassType; set => this.VehicleClassType = VehicleClassType.ClassB; }
        public override string ToString()
        {
            {
                return "ClassB" + base.ToString();
            }
        }
        public VehicleClassType getVehicleClass()
        {
            {
                return VehicleClassType.ClassB;
            }
        }
    }
    class ClassC : Vehicle
    {
        public override VehicleClassType VehicleClassType { get => VehicleClassType; set => this.VehicleClassType = VehicleClassType.ClassC; }
        public override string ToString()
        {
            {
                return "classC" + base.ToString();
            }
        }
        public  VehicleClassType getVehicleClass()
        {
            {
                return VehicleClassType.ClassC;
            }
        }
    }
    class MotorCycle : ClassA {
    }
    class CrossOver : ClassA { }
    class PrivateCar : ClassA { }
    class SUV : ClassB { }
    class Van : ClassB { }
    class Truck : ClassC { }
    static class VehicleFactory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Vehicle Get(VehicleType VehicleType)
        {
            switch (VehicleType)
            {
                case VehicleType.SUV:
                    return new SUV();
                case VehicleType.Crossover:
                    return new CrossOver();
                case VehicleType.Private:
                    return new PrivateCar();
                case VehicleType.Van:
                    return new Van();
                default:
                    return null;
            }
        }
    }
}
