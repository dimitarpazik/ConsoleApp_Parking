using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using ConsoleApp1.Enums;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    class CarProvider
    {
        public List<Car> Cars { get; set; }
        public String pathCars = @"C:\Users\User\Desktop\Parking_console\Cars.txt";

        public CarProvider()
        {
            Cars = ReadCars();
        }

        public List<Car> ReadCars()
        {
            Cars = new List<Car>();
            if (!File.Exists(pathCars))
            {
                return null;
            }
            else
            {
                using (StreamReader streamReader = File.OpenText(pathCars))
                {
                    String line = "";
                    line = streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] carProperties = line.Split('\t');
                        if (carProperties[1] == "Audi")
                        {
                            Audi audi = new Audi();
                            audi.ID = Convert.ToInt32(carProperties[0]);
                            audi.Model = carProperties[1];
                            audi.RegistrationPlate = carProperties[2];
                            audi.Seats = Convert.ToInt32(carProperties[3]);
                            audi.Color = (Color)Enum.Parse(typeof(Color), carProperties[4], true);
                            Point a = new Point(Convert.ToDouble(carProperties[5]), Convert.ToDouble(carProperties[6]));
                            Point b = new Point(Convert.ToDouble(carProperties[7]), Convert.ToDouble(carProperties[8]));
                            Dimensions dimensions = new Dimensions(a, b);
                            audi.Dimensions = dimensions;
                            audi.ParkedOn = carProperties[9];
                            audi.Hybrid = Convert.ToBoolean(carProperties[15]);

                            Cars.Add(audi);
                        }
                        else if (carProperties[1] == "BMW")
                        {
                            BMW bmw = new BMW();
                            bmw.ID = Convert.ToInt32(carProperties[0]);
                            bmw.Model = carProperties[1];
                            bmw.RegistrationPlate = carProperties[2];
                            bmw.Seats = Convert.ToInt32(carProperties[3]);
                            bmw.Color = (Color)Enum.Parse(typeof(Color), carProperties[4], true);
                            Point a = new Point(Convert.ToDouble(carProperties[5]), Convert.ToDouble(carProperties[6]));
                            Point b = new Point(Convert.ToDouble(carProperties[7]), Convert.ToDouble(carProperties[8]));
                            Dimensions dimensions = new Dimensions(a, b);
                            bmw.Dimensions = dimensions;
                            bmw.ParkedOn = carProperties[9];
                            bmw.HighDomainAirConditioner = Convert.ToBoolean(carProperties[10]);
                            bmw.DoubleBass = Convert.ToBoolean(carProperties[11]);
                            bmw.Speakers = Convert.ToInt32(carProperties[12]);

                            Cars.Add(bmw);
                        }
                        else
                        {
                            Mercedes mercedes = new Mercedes();
                            mercedes.ID = Convert.ToInt32(carProperties[0]);
                            mercedes.Model = carProperties[1];
                            mercedes.RegistrationPlate = carProperties[2];
                            mercedes.Seats = Convert.ToInt32(carProperties[3]);
                            mercedes.Color = (Color)Enum.Parse(typeof(Color), carProperties[4], true);
                            Point a = new Point(Convert.ToDouble(carProperties[5]), Convert.ToDouble(carProperties[6]));
                            Point b = new Point(Convert.ToDouble(carProperties[7]), Convert.ToDouble(carProperties[8]));
                            Dimensions dimensions = new Dimensions(a, b);
                            mercedes.Dimensions = dimensions;
                            mercedes.ParkedOn = carProperties[9];
                            mercedes.OxygenSystem = Convert.ToBoolean(carProperties[13]);
                            mercedes.BulletProofGlass = Convert.ToBoolean(carProperties[14]);

                            Cars.Add(mercedes);
                        }
                    }
                }
            }
            return Cars;
        }

        internal Car findCar(int carID)
        {           
            foreach (var car in Cars)
            {
                if (car.ID == carID)
                {
                    return car;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Your car is not in our system!");
            return null;
        }

        

        internal List<Car> NotParkedCars()
        {
            List<Car> cars = new List<Car>();
            foreach (var car in Cars)
            {
                if (car.ParkedOn == "X")
                {
                    cars.Add(car);
                }
                else
                {
                    continue;
                }
            }

            return cars;
        }

        public void WriteCar(Car car)
        {
            if (!File.Exists(pathCars))
            {
                using (StreamWriter streamWriter = File.CreateText(pathCars))
                {
                    streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}", "ID", "Model", "Registration Plate", "No. Seats", "Color", "Ax", "Ay", "Bx", "By", "Parked on", "HDAC", "Double Bass", "Speakers", "Oxygen System", "Bullet Proof Glass", "Hybrid");
                }
            }
            using (StreamWriter streamWriterAppend = File.AppendText(pathCars))
            {
                if (car.Model == "Audi")
                {
                    Audi audi = (Audi)car;
                    streamWriterAppend.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}", audi.ID, audi.Model, audi.RegistrationPlate, audi.Seats, audi.Color, audi.Dimensions.A.X, audi.Dimensions.A.Y, audi.Dimensions.B.X, audi.Dimensions.B.Y, "X", "", "", "", "", "", audi.Hybrid);

                }
                else if (car.Model == "BMW")
                {
                    BMW bmw = (BMW)car;
                    streamWriterAppend.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}", bmw.ID, bmw.Model, bmw.RegistrationPlate, bmw.Seats, bmw.Color, bmw.Dimensions.A.X, bmw.Dimensions.A.Y, bmw.Dimensions.B.X, bmw.Dimensions.B.Y, "X", bmw.HighDomainAirConditioner, bmw.DoubleBass, bmw.Speakers, "", "", "");

                }
                else
                {
                    Mercedes mercedes = (Mercedes)car;
                    streamWriterAppend.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}", mercedes.ID, mercedes.Model, mercedes.RegistrationPlate, mercedes.Seats, mercedes.Color, mercedes.Dimensions.A.X, mercedes.Dimensions.A.Y, mercedes.Dimensions.B.X, mercedes.Dimensions.B.Y, "X", "", "", "", mercedes.OxygenSystem, mercedes.BulletProofGlass, "");
                }

            }
        }

        public void WriteCars(List<Car> cars)
        {
            using (StreamWriter streamWriter = File.CreateText(pathCars))
            {
                streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}","ID", "Model", "Registration Plate", "No.Seats", "Color", "Ax", "Ay", "Bx", "By", "Parked on", "HDAC", "Double Bass", "Speakers", "Oxygen System", "Bullet Proof Glass", "Hybrid");
            }

            using (StreamWriter streamWriterAppend = File.AppendText(pathCars))
            {
                foreach (var car in cars)
                {

                    String line = String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t", car.ID, car.Model, car.RegistrationPlate, car.Seats, car.Color, car.Dimensions.A.X, car.Dimensions.A.Y, car.Dimensions.B.X, car.Dimensions.B.Y, car.ParkedOn);
                    if (car.Model == "Audi")
                    {
                        Audi carAudi = (Audi)car;
                        line += String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", "", "", "", "", "", carAudi.Hybrid);
                    }
                    else if (car.Model == "BMW")
                    {
                        BMW carBMW = (BMW)car;
                        line += String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", carBMW.HighDomainAirConditioner, carBMW.DoubleBass, carBMW.Speakers, "", "", "");
                    }
                    else
                    {
                        Mercedes carMercedes = (Mercedes)car;
                        line += String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", "", "", "", carMercedes.OxygenSystem, carMercedes.BulletProofGlass, "");
                    }
                    streamWriterAppend.WriteLine(line);
                }
            }

        }

        public void updateCarParking(Car car, Parking parking)
        {
            Car car1 = car;
            foreach(var carItem in Cars)
            {
                if (carItem.ID == car.ID)
                {
                    Cars.Remove(carItem);
                    break;
                }
            }
            
            car1.ParkedOn = parking.Name;
            Cars.Add(car1);
            WriteCars(Cars);
        }

        public List<Car> CarsOfParking(Parking parking)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in Cars)
            {
                if (car.ParkedOn == parking.Name)
                {
                    cars.Add(car);
                }
                else
                {
                    continue;
                }
            }

            return cars;
        }

        public void ListCars(List<Car> cars)
        {
            int countCars = 0;
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "ID", "Registration Plate", "Model", "No. of seats", "Color");
            foreach (var car in cars)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", car.ID, car.RegistrationPlate, car.Model, car.Seats, car.Color);
                countCars++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Here are {0} cars.", countCars);

        }

        

    }
}
