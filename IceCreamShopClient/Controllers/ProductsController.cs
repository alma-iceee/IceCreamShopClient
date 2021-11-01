using Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace IceCreamShopClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductsController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var goods = _context.Goods.Where(g => g.GoodsStatusId == 2).ToList();

            var productIds = goods.GroupBy(g => g.ProductId).Select(g => new { ProductId = g.Key, Count = g.Count() });

            var products = _context.Products.Where(p => productIds.Select(pI => pI.ProductId).Contains(p.Id)).ToList();

            return View(goods);
        }
    }
}
