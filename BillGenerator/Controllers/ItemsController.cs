using BillGenerator.Models;
using BillGenerator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BillGenerator.Services;


namespace BillGenerator.BillWeb.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            List<ItemViewModel> list = new List<ItemViewModel>();
            var items = await _itemService.GetAll();
            list.AddRange(items.Select(item => new ItemViewModel
            { Id = item.Id, Name = item.Name, Price = item.Price }));
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel vm)
        {
            var model = new Item
            {
                Name = vm.Name,
                Price = vm.Price

            };
            await _itemService.SaveItem(model);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemService.GetById(id);
            var vm = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel vm)
        {
            var model = new Item
            {
                Id = vm.Id,
                Name = vm.Name,
                Price = vm.Price

            };
            await _itemService.UpdateItem(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.DeleteItem(id);
            return RedirectToAction("Index");
        }

    }
}
