using DataAccess.Abstratc;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarService : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarService()
        {
            _cars = new List<Car> 
            { 
                new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=10000,Description="Otoban faresi",ModelYear=2010},
                new Car {CarId=2,BrandId=1,ColorId=2,DailyPrice=15000,Description="Yer uçağı",ModelYear=2010},
                new Car {CarId=3,BrandId=2,ColorId=3,DailyPrice=12000,Description="Sorunsuz",ModelYear=2010},
                new Car {CarId=4,BrandId=2,ColorId=4,DailyPrice=13000,Description="Masrafsız",ModelYear=2010},
                new Car {CarId=5,BrandId=2,ColorId=2,DailyPrice=17000,Description="Yakıt cimrisi",ModelYear=2010}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.First(c=>c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.First(c => c.CarId == car.CarId);
            carToUpdate.CarId= car.CarId;
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            carToUpdate.Description=car.Description;
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.ModelYear=car.ModelYear;
        }
    }
}
