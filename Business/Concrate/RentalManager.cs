using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            if(_carService.findCarStatus(rental.CarId))
            {
               _rentalDal.Add(rental);
                var res = _carService.getCarById(rental.CarId);
                if(res.Success == true)
                {
                    res.Data.carStatus = Entities.Enums.CarStatus.RENTED;
                    _carService.Update(res.Data);
                }
                
                return new SuccessResult();
            }
        
            return new ErrorResult(Messages.CurrentlyUnavailable);
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> FindFirstRentalCarByCarId(int id)
        {
            var result = _rentalDal.findRental(id);
            if (result != null) return new SuccessDataResult<Rental>(result);
            else return new ErrorDataResult<Rental>();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IResult handleReturnCar(string carLicance)
        {
          var car = _carService.GetCarByLicanse(carLicance);
            if(car.Success == true)
            {
                var result = _rentalDal.GetRentalCarIdOrderByDESCReturnDate(car.Data);
                result.ReturnDate = DateTime.Now;
                Update(result);
                return new SuccessResult();
            }
            return new ErrorResult(); 
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
