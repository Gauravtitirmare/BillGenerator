using BillGenerator.Data;
using BillGenerator.Models;
using BillGenerator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillGenerator.Services
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDBContext _context;

        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
