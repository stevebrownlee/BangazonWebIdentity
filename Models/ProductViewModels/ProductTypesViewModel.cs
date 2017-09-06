using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;
using BangazonAuth.Models;

namespace Bangazon.Models.ProductViewModels
{
  public class ProductTypesViewModel
  {
    public IEnumerable<GroupedProducts> GroupedProducts { get; set; }
  }
}