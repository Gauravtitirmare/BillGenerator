using BillGenerator.Data;
using BillGenerator.Models;
using BillGenerator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BillGenerator.BillWeb.Services
{
    public class BillService : IBillService
    {
        private ApplicationDBContext _context;

        public BillService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public void AddBillDetails(List<BillDetails> details)
        {
            _context.BillsDetails.AddRange(details);
            _context.SaveChanges();
        }
    }
}
