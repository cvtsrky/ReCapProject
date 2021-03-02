using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car {CarId=1, BrandId="Toyota", ColorId="Beyaz", DailyPrice=150, Description="Hasarsız", ModelYear=2003},
                new Car {CarId=2, BrandId="Ferrari", ColorId="Kırmızı", DailyPrice=15000, Description="Az hasarlı", ModelYear=2013},
                new Car {CarId=3, BrandId="Jaguar", ColorId="Siyah", DailyPrice=13000, Description="Çiziksiz", ModelYear=2011},
                new Car {CarId=4, BrandId="Seat", ColorId="Yeşil", DailyPrice=1500, Description="Değişeni var", ModelYear=2009},
                new Car {CarId=5, BrandId="Audi", ColorId="Gri", DailyPrice=2000, Description="Hasar kayıtlı", ModelYear=2021}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c=>c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c=> c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
