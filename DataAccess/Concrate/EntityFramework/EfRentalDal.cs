using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public Rental findRental(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var lastRecord = context.Rentals.Where<Rental>(i => i.CarId == id).OrderByDescending(x => x.ReturnDate).FirstOrDefault();
                return lastRecord;
            }
        }

        public Rental GetRentalCarIdOrderByDESCReturnDate(Car Car)
        {
            
            using (RentACarContext context = new RentACarContext())
            {
                var result = context.Rentals.Where(i => i.CarId == Car.CarId).OrderByDescending(x => x.RentDate).FirstOrDefault();
                return result; 
            }
        }
    }
}
