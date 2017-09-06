using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Models;
using Bangazon.Data;
using Bangazon.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext context;

        public ProductTypesController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Detail([FromRoute]int? type)
        {

            // If no id was in the route, return 404
            if (type == null)
            {
                return NotFound();
            }

            /*
                Create instance of view model
             */
            // ProductTypeDetailViewModel model;

            /*
                Write LINQ statement to get requested product type
             */
            IQueryable<ProductType> productType;

            // If product not found, return 404
            if (productType == null)
            {
                return NotFound();
            }

            /*
                Add corresponding products to the view model
             */
            // model.Products = ???

            // Add the product type to the view model
            model.ProductType = productType;

            return View(model);
        }
    }
}
