using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int FreeSpace { get; set; }
        public double Profit { get; set; }
      
    }
}
