using ConsoleApp1.Enums;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            CarProvider carProvider = new CarProvider();
            ParkingProvider parkingProvider = new ParkingProvider();

            ParkingSystem parkingSystem = new ParkingSystem();


            while (true)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("\tConsole Parking Application");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("--------------------------------------------------\n");

                Console.WriteLine("Choose one of the following menues:");
                Console.WriteLine("\t1) - Select Parking");
                Console.WriteLine("\t2) - Add Parking");
                Console.WriteLine("\t3) - Add Car");
                Console.WriteLine("\t -------------------");
                Console.Write("\tYour Option?");

                var choosenItem = Console.ReadLine();
                if (choosenItem == "1")
                {
                    carProvider.ReadCars();
                    parkingProvider.ReadParkings();
                    int flagToParkings = 1;
                    Parking neededParking = new Parking();
                    int parkingID;
                    while (true)
                    {
                        if (flagToParkings == 1)
                        {
                            parkingProvider.ListParkings(); //se zemaat site parkinzi i se printaat na konzola
                            parkingID = Convert.ToInt32(Console.ReadLine()); //se zema ID od parking
                            neededParking = parkingProvider.FindParking(parkingID);//se zema parkingot so vneseno id
                        }
                        Console.WriteLine("Choose one of the following options for choosen parking:");
                        Console.WriteLine("\t------------------");
                        Console.WriteLine("\t1) - List Cars");
                        Console.WriteLine("\t2) - Park car");
                        Console.WriteLine("\t3) - Profit");
                        Console.WriteLine("\t------------------");
                        Console.WriteLine("\t0) - Cancel");
                        Console.Write("Your Option?");
                        var choosenOption = Console.ReadLine();
                        if (choosenOption == "1")
                        {
                            List<Car> cars = carProvider.CarsOfParking(neededParking); //se zemaat site koli od toj parking
                            carProvider.ListCars(cars);
                            flagToParkings = 0;
                            continue;
                        }
                        else if (choosenOption == "2")
                        {
                            List<Car> cars = carProvider.NotParkedCars(); //se zemaat site koli od toj parking
                            carProvider.ListCars(cars);
                            Console.WriteLine("Choose ID of one car to park");
                            var carID = Convert.ToInt32(Console.ReadLine());
                            Car neededCar = carProvider.findCar(carID);
                            parkingProvider.parkCar(neededCar, neededParking);
                            flagToParkings = 0;
                        }
                        else if (choosenOption == "3")
                        {
                            parkingProvider.ParkingProfit(neededParking);
                            flagToParkings = 0;
                        }
                        else if (choosenOption == "0")
                        {
                            flagToParkings = 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong choise!");
                        }

                    }
                }
                else if (choosenItem == "2")
                {
                    Console.WriteLine("Insert ID for your parking");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Your parking name:");
                    String name = Console.ReadLine();
                    Console.WriteLine("Insert number of capacity for your parking:");
                    int capacity = Convert.ToInt32(Console.ReadLine());
                    List<Car> cars = new List<Car>();
                    Parking parking = new Parking();
                    parking.Id = id;
                    parking.Name = name;
                    parking.Capacity = capacity;
                    parking.Cars = cars;
                    parking.FreeSpace = capacity;
                    parking.Profit = 0;
                    parkingProvider.WriteParking(parking);

                }
                else if (choosenItem == "3")
                {
                    Console.WriteLine("Choose one of the next models:");
                    Console.WriteLine("\ta - Audi");
                    Console.WriteLine("\tb - BMW");
                    Console.WriteLine("\tm - Mercedes");
                    Console.WriteLine("\t------------------");
                    Console.WriteLine("\t0 - Cancel");
                    Console.Write("\tYour Option?");
                    var choosenModel = Console.ReadLine();

                    switch (choosenModel)
                    {
                        case "a":
                            Audi audi = new Audi();

                            audi.Model = "Audi";
                            Console.WriteLine("Write ID for your car");
                            audi.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your Registration Plate");
                            audi.RegistrationPlate = Console.ReadLine();
                            Console.WriteLine("Enter number of seats between 1-5");
                            audi.Seats = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Choose your car's color");
                            Console.WriteLine("\t0 - Blue");
                            Console.WriteLine("\t1 - Green");
                            Console.WriteLine("\t2 - Red");
                            Console.WriteLine("\t3 - Yellow");
                            String colA = Convert.ToString(Console.ReadLine());
                            audi.Color = (Color)Enum.Parse(typeof(Color), colA, true);

                            Console.WriteLine("Enter dimensions of your car");
                            Console.WriteLine("Insert X for first dimension");
                            double point1X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for first dimension");
                            double point1Y = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert X for second dimension");
                            double point2X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for second dimension");
                            double point2Y = Convert.ToDouble(Console.ReadLine());
                            Point a = new Point(point1X, point1Y);
                            Point b = new Point(point2X, point2Y);
                            Dimensions dimension = new Dimensions(a, b);
                            audi.Dimensions = dimension;
                            Console.WriteLine("Write true or false if your car is Hybrid");
                            audi.Hybrid = Convert.ToBoolean(Console.ReadLine());
                            carProvider.WriteCar(audi);

                            break;

                        case "b":
                            BMW bmw = new BMW();

                            bmw.Model = "BMW";
                            Console.WriteLine("Write ID for your car");
                            bmw.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your Registration Plate");
                            bmw.RegistrationPlate = Console.ReadLine();
                            Console.WriteLine("Enter number of seats between 1-5");
                            bmw.Seats = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Choose your car's color");
                            Console.WriteLine("\t0 - Blue");
                            Console.WriteLine("\t1 - Green");
                            Console.WriteLine("\t2 - Red");
                            Console.WriteLine("\t3 - Yellow");
                            String colB = Convert.ToString(Console.ReadLine());
                            bmw.Color = (Color)Enum.Parse(typeof(Color), colB, true);

                            Console.WriteLine("Enter dimensions of your car");
                            Console.WriteLine("Insert X for first dimension");
                            double p1X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for first dimension");
                            double p1Y = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert X for second dimension");
                            double p2X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for second dimension");
                            double p2Y = Convert.ToDouble(Console.ReadLine());
                            Point aa = new Point(p1X, p1Y);
                            Point bb = new Point(p2X, p2Y);
                            Dimensions dimension1 = new Dimensions(aa, bb);
                            bmw.Dimensions = dimension1;

                            Console.WriteLine("Write true or false if your car has High Domain Air Conditioner\n");
                            bmw.HighDomainAirConditioner = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("Write true or false if your car has Double Bass\n");
                            bmw.DoubleBass = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("How many speakers do you have?\n");
                            bmw.Speakers = Convert.ToInt32(Console.ReadLine());
                            carProvider.WriteCar(bmw);

                            break;

                        case "m":
                            Mercedes mercedes = new Mercedes();

                            mercedes.Model = "Mercedes";
                            Console.WriteLine("Write ID for your car");
                            mercedes.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter your Registration Plate");
                            mercedes.RegistrationPlate = Console.ReadLine();
                            Console.WriteLine("Enter number of seats between 1-5");
                            mercedes.Seats = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Choose your car's color");
                            Console.WriteLine("\t0 - Blue");
                            Console.WriteLine("\t1 - Green");
                            Console.WriteLine("\t2 - Red");
                            Console.WriteLine("\t3 - Yellow");
                            String colM = Convert.ToString(Console.ReadLine());
                            mercedes.Color = (Color)Enum.Parse(typeof(Color), colM, true);

                            Console.WriteLine("Enter dimensions of your car");
                            Console.WriteLine("Insert X for first dimension");
                            double po1X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for first dimension");
                            double po1Y = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert X for second dimension");
                            double po2X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Insert Y for second dimension");
                            double po2Y = Convert.ToDouble(Console.ReadLine());
                            Point aaa = new Point(po1X, po1Y);
                            Point bbb = new Point(po2X, po2Y);
                            Dimensions dimension2 = new Dimensions(aaa, bbb);
                            mercedes.Dimensions = dimension2;

                            Console.WriteLine("Write true or false if your car has Oxygen system!");
                            mercedes.OxygenSystem = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("Write true or false if your car has Bullet Proof Glass");
                            mercedes.BulletProofGlass = Convert.ToBoolean(Console.ReadLine());
                            carProvider.WriteCar(mercedes);

                            break;
                        case "0":
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choise!");

                }

            }

        }
    }
}
