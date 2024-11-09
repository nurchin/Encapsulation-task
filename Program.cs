using System;
using System.Collections.Generic;
using System.Linq;

namespace Encapsulation_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(1, "Porsche", 240);
            Car car2 = new Car(2, "Mazda", 180);
            Car car3 = new Car(3, "Mercedes", 220);

            Gallery gallery1 = new Gallery(1, "Cars Gallery");

            gallery1.AddCar(car1);
            gallery1.AddCar(car2);
            gallery1.AddCar(car3);

            gallery1.ShowAllCars();
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Speed { get; set; }
        public string CarCode { get;  set; }
        private static int carCount = 1000;

        public Car(int id, string name, int speed) { 
        
            Name = name;
            Id = id;
            Speed = speed;
            CarCode = $"{name.Substring(0, 2).ToUpper()}{++carCount}";
        }

        
    }

    public class Gallery
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private Car[] Cars { get; set; } = new Car[0];

        public Gallery(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddCar(Car car)
        {
            Array.Resize(ref Cars, Cars.Length + 1);
            Cars[Cars.Length - 1] = car;
        }

        public void ShowAllCars()
        {
            foreach (var car in Cars)
            {
                Console.WriteLine(car);
            }
        }

        // Find car by ID
        public Car FindCarById(int id)
        {
            foreach (var car in Cars)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }
            return null;
        }

        public Car FindCarByCarCode(string carCode)
        {
            foreach (var car in Cars)
            {
                if (car.CarCode == carCode)
                {
                    return car;
                }
            }
            return null;
        }

        public Car[] FindCarsBySpeedInterval(int minSpeed, int maxSpeed)
        {
            return Cars.Where(car => car.Speed >= minSpeed && car.Speed <= maxSpeed).ToArray();
        }
    }
}


