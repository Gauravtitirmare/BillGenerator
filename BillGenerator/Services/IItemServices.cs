using BillGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillGenerator.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetById(int id);
        Task SaveItem(Item item);
        Task DeleteItem(int id);
        Task UpdateItem(Item item);

    }
}
