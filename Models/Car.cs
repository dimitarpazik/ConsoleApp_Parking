using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = ConsoleApp1.Enums.Color;

namespace ConsoleApp1.Models
{
    public abstract class Car
    {
        public int ID { get; set; }
        public String Model { get; set; }
        public String RegistrationPlate { get; set; }
        public int Seats { get; set; }
        public Color Color { get; set; }
        public Dimensions Dimensions { get; set; }       
        public String ParkedOn { get; set; }

    }
}
