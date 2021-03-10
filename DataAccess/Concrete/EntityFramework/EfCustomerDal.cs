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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from cus in context.Customers
                    join user in context.Users on cus.UserId equals user.UserId
                    select new CustomerDetailDto
                    {
                        CustomerId = cus.CustomerId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CompanyName = cus.CompanyName,
                        Email = user.Email,
                        Password = user.Password
                    };
                return result.ToList();
            }
        }
    }
}
