using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car { CarId = 8, BrandId = 1, ColorId = 3, ModelYear = 2001, Description = "Az kullanılmış", DailyPrice = 150 });
            Console.WriteLine("-----all-----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + " --Marka: " + car.BrandId + " --Model: " + car.ModelYear + " --Rengi: " + car.ColorId +
                    " --Açıklama: " + car.Description + " --Günlük ücret: " + car.DailyPrice);
            }
            Console.WriteLine("------Brandid------");
            foreach (var car1 in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("ID: " + car1.CarId + " --Marka: " + car1.BrandId + " --Model: " + car1.ModelYear + " --Rengi: " + car1.ColorId +
                    " --Açıklama: " + car1.Description + " --Günlük ücret: " + car1.DailyPrice);
            }

            Console.WriteLine("-------Colorid------");
            foreach (var car2 in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("ID: " + car2.CarId + " --Marka: " + car2.BrandId + " --Model: " + car2.ModelYear + " --Rengi: " + car2.ColorId +
                    " --Açıklama: " + car2.Description + " --Günlük ücret: " + car2.DailyPrice);
            }
        }
    }
}
