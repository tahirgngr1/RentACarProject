using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Entities.Concrate;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public Car GetCarByLicanse(string carLicence)
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = context.Cars.SingleOrDefault(x => x.CarLicence.Equals(carLicence));
                return result;
            }
        }
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             join k in context.Colors
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 ColorName = k.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName
                             };
                return result.ToList();
            }
        }
    }
}
