using Business.Abstract;
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
            //CarTest();
            RentalTest();
        }
        public static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.ColorName + " / " + car.BrandName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        public static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental{ CarId = 1, CustomerId = 4, RentDate = DateTime.Now });
            foreach (var rent in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rent.RentalId + " / " + rent.CustomerId + " / " + rent.CarId + " / " + rent.RentDate);
            }
        }
    }
}
