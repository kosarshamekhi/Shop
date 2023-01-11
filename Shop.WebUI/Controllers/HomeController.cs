using Microsoft.AspNetCore.Mvc;
using Shop.DAL.DbContexts;
using Shop.Model;
using Shop.Model.Products;
using System.Diagnostics;

namespace Shop.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ShopDbContext _shopDbContext;

    public HomeController(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    //private readonly ILogger<HomeController> _logger;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //------------------------------------

    [HttpGet]
    public IActionResult Search(string? name)
    {
        if (name == null)
        {
            return NotFound();
        }

        var product = _shopDbContext.Products.FirstOrDefault(u=>u.Name == name);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [HttpPost]
    public IActionResult Search(Product product)
    {
        IQueryable<Product> products = _shopDbContext.Products.AsQueryable();
        if (!string.IsNullOrEmpty(product.Name))
        {
            products = products.Where(t => t.Name.Contains(product.Name));
        }
        List<Product> result = products.Select(c => new Product
        {
            Name = c.Name,
            Quantity = c.Quantity
        }).ToList();

        return View(result);
        //return new List<Product>
        //{
        //    Result = new List<Product>(result) { }
        //};
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}