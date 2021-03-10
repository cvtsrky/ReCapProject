using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rent in context.Rentals
                    join car in context.Cars on rent.CarId equals car.CarId
                    join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                    join user in context.Users on cus.UserId equals user.UserId 
                    select new RentalDetailDto
                    {
                        RentalId = rent.RentalId,
                        CarName = car.CarName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CompanyName = cus.CompanyName,
                        RentDate = rent.RentDate,
                        ReturnDate = rent.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
