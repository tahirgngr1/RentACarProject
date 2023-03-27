using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AddMethod();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }

        private static void AddMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { CarName = "A2", BrandId = 1, ColorId = 1, DailyPrice = 250000, Description = "asdf", ModelYear = 2000 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
        }
        
    }
}
