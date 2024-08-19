using BillGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillGenerator.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bill> Biils { get; set; }
        public ICollection<BillDetails> BillDetails { get; set; }

    }
}
