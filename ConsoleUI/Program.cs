using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(car.CarId);
            //}

            //CarManager carManager1 = new CarManager(new EfCarDal());
            //carManager1.Add(new Car { BrandId = 1, CarId = 20, ColorId = 4, DailyPrice = 0, Description = "Yer uçağı", ModelYear = 2018 });

            //foreach (var car in carManager1.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.CarId);
            //}



            CarManager carManager2 = new CarManager(new EfCarDal());

            foreach (var car in carManager2.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + "/" + car.DailyPrice);
            }



        }
    }
}