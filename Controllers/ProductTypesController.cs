using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAuth.Models;
using BangazonAuth.Data;
using BangazonAuth.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BangazonAuth.Controllers
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
            ViewBag["types"] = from t in context.ProductType
                join p in context.Product
                on t.ProductTypeId equals p.ProductTypeId
                group new { t, p } by new { t.Label } into grouped
                select new {
                    TypeName = grouped.Key.Label,
                    ProductCount = grouped.Select(x => x.p.ProductId).Count()
                };

            return View();
        }

        public async Task<IActionResult> Detail([FromRoute]int? type)
        {

            // If no id was in the route, return 404
            if (type == null)
            {
                return NotFound();
            }

            var model = new ProductTypeDetailViewModel();

            var productType = await context.ProductType
                                .Where(t => t.ProductTypeId == type)
                                .SingleOrDefaultAsync();

            // If product not found, return 404
            if (productType == null)
            {
                return NotFound();
            }

            model.Products = await (from t in context.Product
                where t.ProductTypeId == type
                select t).ToListAsync();

            model.ProductType = productType;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }
    }
}
