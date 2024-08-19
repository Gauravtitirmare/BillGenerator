using BillGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillGenerator.Services
{
    public interface IBillService
    {
        void AddBillDetails(List<BillDetails> details);
        void AddBill(Bill bill);

    }
}
