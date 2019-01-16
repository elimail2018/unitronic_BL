using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Dimensions

    {

        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private Dimensions(int width, int height, int length)//not allow to create this object outside
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public static Dimensions createDimension ( int width, int height, int length) //create the object
        {
            
            Dimensions d = new Dimensions(width, height, length);
            return d;
        }

        public bool IsInRange(Dimensions otherDimensions) //create the object
        {
            bool _isInRange = true;
            if (otherDimensions != null)
            {
                if (otherDimensions.Height > this.Height || otherDimensions.Width > this.Width || otherDimensions.Length > this.Length)
                    _isInRange = false;
            }
            else
            {
                //null - no dimension limitaion
                return true;
            }
           return _isInRange;
        }

        public override string ToString() {
            return  " width: " + Width + " height:" + Height + " length: "+ Length;
            }

    }
}
