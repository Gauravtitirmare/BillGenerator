using BillGenerator.Models;
using BillGenerator.Services;
using BillGenerator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace BillGenerator.Controllers
{
    public class BillsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;

        public BillsController(IItemService itemService, ICustomerService customerService,
            IBillService billService)
        {
            _itemService = itemService;
            _customerService = customerService;
            _billService = billService;
        }
        public IActionResult SaveItems(BillViewModel vm)
        {
            Customer customer = new Customer();
            customer.Name = vm.CustomerName;
            _customerService.AddCustomer(customer);

            List<BillDetails> billDetails = new List<BillDetails>();
            foreach (var item in vm.items)
            {
                billDetails.Add(new BillDetails()
                {
                    ItemId = item.itemId,
                    ItemName = item.itemName,
                    CustomerId = customer.Id,
                    Price = item.itemPrice,
                    Discount = item.itemDiscount,
                    Quantity = item.itemQuantity,
                    Total = item.itemTotal
                });
            }
            _billService.AddBillDetails(billDetails);

            Bill bill = new Bill();
            bill.CustomerId = customer.Id;
            bill.BillDate = DateTime.UtcNow;
            bill.TotalAmount = vm.GrandTotal;
            _billService.AddBill(bill);

            BillReceiptViewModel Billvm = new BillReceiptViewModel();

            Billvm.BillDetails = billDetails;
            Billvm.BillNumber = bill.Id;
            Billvm.FromAddress = "My Restaurant";
            Billvm.CustomerName = vm.CustomerName;
            Billvm.TotalAmount = vm.GrandTotal;
            return PartialView("_bill", Billvm);

        }

        public async Task<IActionResult> Create()
        {
            var Items = await _itemService.GetAll();
            ViewBag.ItemsList = new SelectList(Items, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> GetPrice(int id)
        {
            var item = await _itemService.GetById(id);
            var price = item.Price;
            return Json(price);
        }
    }
}
