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
            //ColorCrudTest();
            //CarManagerTest();            
            //CarDetails();
            RentalAdd();
            //UserAdd();
            //CustomerAdd();
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {CustomerId = 2,UserId = 2,CompanyName = "Turkcell"});
            Console.WriteLine(result.Message);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
                {UserId = 2, FirstName = "Yusuf", LastName = "Kaymaz", Email = "abc@gmail.com", Password = "abc123"});
            Console.WriteLine(result.Message);
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental{RentalId = 2,CarId = 2,CustomerId = 2,RentDate = DateTime.Now});
            Console.WriteLine(result.Message);
        }

        //private static void ColorCrudTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Console.WriteLine("----Raw Data----");
        //    var result = colorManager.GetAll();
        //    foreach (var color in result.Data)
        //    {
        //        Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
        //    }
        //    Console.WriteLine("------After Added-----");
        //    colorManager.Add(new Color {ColorId = 8, ColorName = "Pembe" });
        //    foreach (var color in result.Data)
        //    {
        //        Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
        //    }

        //    Console.WriteLine("------After Deleted-----");
        //    colorManager.Delete(new Color {ColorId=12 });
        //    foreach (var color in result.Data)
        //    {
        //        Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
        //    }

        //    Console.WriteLine("------After Updated-----");
        //    colorManager.Update(new Color {ColorId = 11, ColorName = "Lila" });
        //    foreach (var color in result.Data)
        //    {
        //        Console.WriteLine("ColorId: {0} -- ColorName: {1} ", color.ColorId, color.ColorName);
        //    }
        //}

        //private static void BrandCrudTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Console.WriteLine("----Raw Data----");
        //    var result = brandManager.GetAll();
        //    foreach (var brand in result.Data)
        //    {
        //        Console.WriteLine("BrandId: {0} -- BrandName: {1} ",brand.BrandId,brand.BrandName);
        //    }
        //    Console.WriteLine("------After Added-----");            
        //    brandManager.Add(new Brand {BrandId=11, BrandName="SKODA" });
        //    foreach (var brand in result.Data)
        //    {
        //        Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
        //    }

        //    Console.WriteLine("------After Deleted-----");
        //    brandManager.Delete(new Brand {BrandId=10 });
        //    foreach (var brand in result.Data)
        //    {
        //        Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
        //    }

        //    Console.WriteLine("------After Updated-----");
        //    brandManager.Update(new Brand {BrandId=12, BrandName="SCANIA1" });
        //    foreach (var brand in result.Data)
        //    {
        //        Console.WriteLine("BrandId: {0} -- BrandName: {1} ", brand.BrandId, brand.BrandName);
        //    }

        //}

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "--" + car.CarName + "--" + car.BrandName + "--" + car.ColorName + "--" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void CarCrudTest()
        //{
        //    CarManager carManager1 = new CarManager(new EfCarDal());
        //    carManager1.Add(new Car { CarId = 8, BrandId = 1, ColorId = 3, ModelYear = 2001, Description = "Az kullanılmış", DailyPrice = 150 });
            
        //}

        //private static void CarManagerTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var getall = carManager.GetAll();
        //    var getCarsByBrandId = carManager.GetCarsByBrandId(1);
        //    var getCarsByColorId = carManager.GetCarsByColorId(1);
        //    Console.WriteLine("-----all-----");
        //    foreach (var car in getall.Data)
        //    {
        //        Console.WriteLine("ID: " + car.CarId + "Araç ismi: " + car.CarName + " --Marka: " + car.BrandId + " --Model: " + car.ModelYear + " --Rengi: " + car.ColorId +
        //            " --Açıklama: " + car.Description + " --Günlük ücret: " + car.DailyPrice);
        //    }
        //    Console.WriteLine("------Brandid------");
        //    foreach (var car1 in getCarsByBrandId.Data)
        //    {
        //        Console.WriteLine("ID: " + car1.CarId + "Araç ismi: " + car1.CarName + " --Marka: " + car1.BrandId + " --Model: " + car1.ModelYear + " --Rengi: " + car1.ColorId +
        //            " --Açıklama: " + car1.Description + " --Günlük ücret: " + car1.DailyPrice);
        //    }

        //    Console.WriteLine("-------Colorid------");
        //    foreach (var car2 in getCarsByColorId.Data)
        //    {
        //        Console.WriteLine("ID: " + car2.CarId + "Araç ismi: " + car2.CarName + " --Marka: " + car2.BrandId + " --Model: " + car2.ModelYear + " --Rengi: " + car2.ColorId +
        //            " --Açıklama: " + car2.Description + " --Günlük ücret: " + car2.DailyPrice);
        //    }
        //}
    }
}
