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
            //CarCrudTest();
            //BrandCrudTest();
            ColorCrudTest();
            //CarManagerTest();
            //GetAll, GetById, Insert, Update, Delete
            //CarDetails();
        }

        private static void ColorCrudTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("----Raw Data----");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
            }
            Console.WriteLine("------After Added-----");
            colorManager.Add(new Color {ColorId = 12, ColorName = "Pembe" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
            }

            Console.WriteLine("------After Deleted-----");
            colorManager.Delete(new Color {ColorId=8 });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
            }

            Console.WriteLine("------After Updated-----");
            colorManager.Update(new Color {ColorId = 9, ColorName = "Lila" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
            }
        }

        private static void BrandCrudTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("----Raw Data----");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId: {0} -- BrandName: {1} ",brand.BrandId,brand.BrandName);
            }
            Console.WriteLine("------After Added-----");            
            brandManager.Add(new Brand {BrandId=11, BrandName="SKODA" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
            }
            
            Console.WriteLine("------After Deleted-----");
            brandManager.Delete(new Brand {BrandId=10 });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("------After Updated-----");
            brandManager.Update(new Brand {BrandId=12, BrandName="SCANIA1" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
            }

        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "--" + car.CarName + "--" + car.BrandName + "--" + car.ColorName + "--" + car.DailyPrice);
            }
        }

        private static void CarCrudTest()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car { CarId = 8, BrandId = 1, ColorId = 3, ModelYear = 2001, Description = "Az kullanılmış", DailyPrice = 150 });
            
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-----all-----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + "Araç ismi: " + car.CarName + " --Marka: " + car.BrandId + " --Model: " + car.ModelYear + " --Rengi: " + car.ColorId +
                    " --Açıklama: " + car.Description + " --Günlük ücret: " + car.DailyPrice);
            }
            Console.WriteLine("------Brandid------");
            foreach (var car1 in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("ID: " + car1.CarId + "Araç ismi: " + car1.CarName + " --Marka: " + car1.BrandId + " --Model: " + car1.ModelYear + " --Rengi: " + car1.ColorId +
                    " --Açıklama: " + car1.Description + " --Günlük ücret: " + car1.DailyPrice);
            }

            Console.WriteLine("-------Colorid------");
            foreach (var car2 in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("ID: " + car2.CarId + "Araç ismi: " + car2.CarName + " --Marka: " + car2.BrandId + " --Model: " + car2.ModelYear + " --Rengi: " + car2.ColorId +
                    " --Açıklama: " + car2.Description + " --Günlük ücret: " + car2.DailyPrice);
            }
        }
    }
}
