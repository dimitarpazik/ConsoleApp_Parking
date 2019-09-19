using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Dimensions
    {
        public  Point A { get;  }
        public Point B { get; private set; }
        
        public Dimensions(Point a,Point b)
        {
            A = a;
            B = b;
        }

        public double Area
        {
            get
            {
                return (B.X - A.X) * (A.Y - B.Y);
            }
        }     

    }
}
