using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    class ParkingProvider
    {
        public List<Parking> Parkings { get; set; }
        public string pathParkings = @"C:\Users\User\Desktop\Parking_console\Parkings.txt";

        public ParkingProvider()
        {
            Parkings = ReadParkings();
        }


        public List<Parking> ReadParkings()
        {
            Parkings = new List<Parking>();
            if (!File.Exists(pathParkings))
            {
                return null;
            }
            else
            {
                using (StreamReader streamReader = File.OpenText(pathParkings))
                {
                    String line = "";

                    line = streamReader.ReadLine();//da se skokne naslovot
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] parkingProperties = line.Split('\t');
                        Parking parking = new Parking();
                        parking.Id = Convert.ToInt32(parkingProperties[0]);
                        parking.Name = parkingProperties[1];
                        parking.Capacity = Convert.ToInt32(parkingProperties[2]);
                        parking.FreeSpace = Convert.ToInt32(parkingProperties[3]);
                        parking.Profit = Convert.ToDouble(parkingProperties[4]);
                        parking.Cars = new List<Car>();
                        Parkings.Add(parking);

                    }
                }
            }
            return Parkings;
        }

        public void WriteParking(Parking parking)
        {
            if (!File.Exists(pathParkings))
            {
                using (StreamWriter streamWriter = File.CreateText(pathParkings))
                {
                    streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "ID", "Name", "Capacity", "Free Space", "Profit");
                }
            }
            using (StreamWriter streamWriterAppend = File.AppendText(pathParkings))
            {
                streamWriterAppend.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}", parking.Id, parking.Name, parking.Capacity, parking.FreeSpace, parking.Profit));
            }
        }

        public void WriteParkings(List<Parking> parkings)
        {
            using (StreamWriter streamWriter = File.CreateText(pathParkings))
            {
                streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "ID","Name", "Capacity", "Free Space", "Profit");

            }
            using (StreamWriter streamWriterAppend = File.AppendText(pathParkings))
            {
                foreach (var parking in parkings)
                {

                    streamWriterAppend.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",parking.Id, parking.Name, parking.Capacity, parking.FreeSpace, parking.Profit);

                }
            }
        }

        public void ListParkings()
        {
            int i = 1;
            Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}", "ID", "Name", "Capacity", "Free Space", "Profit"));

            foreach (var parking in Parkings)
            {
                Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}", parking.Id, parking.Name, parking.Capacity, parking.FreeSpace, parking.Profit));
            }
            Console.WriteLine("Choose the ID of wanted parking");
        }

        internal void ParkingProfit(Parking parking)
        {
            Console.WriteLine("The total profit for parking: {0} is {1} MKD", parking.Name, parking.Profit);
        }

        public Parking FindParking(int id)
        {
            Parking parkingNeeded = new Parking();
            foreach (var parking in Parkings)
            {
                if (parking.Id == id)
                {
                    parkingNeeded = parking;
                    break;
                }
            }
            return parkingNeeded;
        }

        public void ChangeParkingCapacity(Parking parking)
        {
            parking.FreeSpace -= 1;
        }
        public void ChangeParkingProfit(Parking parking, double profit)
        {
            parking.Profit += profit;
        }

        public void parkCar(Car car, Parking parking)
        {
            CarProvider carProvider = new CarProvider();
            carProvider.updateCarParking(car, parking);
            double price = PriceForCar(car);
            ChangeParkingProfit(parking, price);
            ChangeParkingCapacity(parking);
            Parking changedParking = parking;
            foreach (var parkingItem in Parkings)
            {
                if (parkingItem.Id == parking.Id)
                {
                    Parkings.Remove(parkingItem);
                    break;
                }
            }
            Parkings.Add(changedParking);
            WriteParkings(Parkings);
            Console.WriteLine("Your parking costs: {0} MKD", price);
            Console.WriteLine("You can park your car");

        }       

        public double PriceForCar(Car car)
        {
            double basePrice = 20.0, price = 0;
            int seats = car.Seats;
            double area = car.Dimensions.Area;
            price += basePrice;
            price *= seats;

            if (area <= 2)
            {
                price += 5;
            }
            else if (area > 2)
            {
                price += 10;
            }

            return price;
        }
    }
}
