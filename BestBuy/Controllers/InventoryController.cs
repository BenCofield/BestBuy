using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BestBuy.Models;
using BestBuy.Models.ViewModels;
using BestBuy.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IProductRepository repo;

        public InventoryController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Products", new string(""));
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var vm = new ProductsListViewModel()
            {
                Products = await repo.GetAllProducts(),
                SearchTerms = string.Empty
            };
            return View("ProductsList", vm);
        }

        public async Task<IActionResult> SearchProducts(string searchTerms)
        {
            var vm = new ProductsListViewModel()
            {
                Products = await repo.SearchProducts(searchTerms),
                SearchTerms = searchTerms
            };
            return View("ProductsList", vm);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await repo.GetProduct(id);
            return View("EditProduct", product);
        }

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var errors = InputValidation.ValidateChanges(product);

            if (errors.Count != 0)
            {
                ViewBag.InvalidInput = errors;              
            }
            else {
                try
                {
                    var result = await repo.UpdateProduct(product);
                }
                catch (Exception e)
                {
                    ViewBag.SqlError = e.Message;
                }
            }

            var newProd = await repo.GetProduct(product.ProductID);

            return View("EditProduct", newProd);
        }

        public IActionResult CreateProduct()
        {
            var viewModel = new CreateProductViewModel() {

            };
            return View("CreateProduct", viewModel);
        }

        public async Task<IActionResult> AddProductToDatabase(Product product)
        {
            var errors = InputValidation.ValidateChanges(product);
            if (errors.Count > 0)
            {
                ViewBag.InvalidInput = errors;
                return View("CreateProduct", product);
            }
            var result = await repo.CreateProduct(product);
            return View("GetAllProducts");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await repo.DeleteProduct(id);
            return RedirectToAction("GetAllProducts");
        }
    }
}

