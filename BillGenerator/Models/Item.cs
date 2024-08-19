using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillGenerator.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }

    }
}
