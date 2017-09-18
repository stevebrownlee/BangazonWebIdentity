using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.ViewComponents
{
    public class OrderCountViewModel
    {
        public int OrderCount { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
    }

    /*
        ViewComponent for displaying the shopping cart link & count in 
        the navigation bar.
     */
    public class OrderCountViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
 
        public OrderCountViewComponent(ApplicationDbContext c, UserManager<ApplicationUser> userManager)
        {
            _context = c;
            _userManager = userManager;
        }
 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Get the current, authenticated user
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            // Instantiate view model
            OrderCountViewModel model = new OrderCountViewModel();

            /*
                Since I'm just getting the count of line items in this
                order, there's no need for a custom type. Just put the 
                integer in ViewData.
             */
            var order = await _context.Order
                .Include("LineItems.Product")
                .SingleOrDefaultAsync(o => o.User == user && o.PaymentType == null)
                ;

            if (order != null)
            {
                model.LineItems = order.LineItems;
                model.OrderCount = order.LineItems.Count;
            } else {
                model.LineItems = new List<LineItem>();
                model.OrderCount = 0;
            }
            return View(model);
        }
    }
}