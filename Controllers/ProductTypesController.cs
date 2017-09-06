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
        private ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext ctx)
        {
            _context = ctx;
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
                Write LINQ statement to get requested product type
             */
            ProductType productType = await _context.ProductType
                .SingleOrDefaultAsync(t => t.ProductTypeId == type);

            // If product not found, return 404
            if (productType == null)
            {
                return NotFound();
            }

            /*
                Add corresponding products to the view model
             */
            return View();
        }
    }
}
