using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1.Services
{
    public class ParkingSystem
    {
        private ParkingProvider _parkingProvider; //site dr objekti so se servisi da bidat private i posle vo konstruktor se inicijalizirat na new
        private CarProvider _carProvider;

        private List<Parking> _parkings;
        private List<Car> _cars;

        public Parking SelectedParking { get; private set; }

        public ParkingSystem()
        {
            _parkingProvider = new ParkingProvider();
            _carProvider = new CarProvider();

            _parkings = _parkingProvider.ReadParkings() ?? new List<Parking>();
            _cars = _carProvider.ReadCars() ?? new List<Car>();
        }

        //public void SelectParking(int id)
        //{
        //    foreach(var parking in _parkings)
        //    {
        //        if (parking.Id == id)
        //        {
        //            SelectedParking = parking;
        //        }
        //    }

        //    if (SelectedParking == null)
        //    {
        //       // throw new Exception("Parking was not found")
        //    }
        //}
        
    }
}
