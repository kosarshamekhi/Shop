using Microsoft.AspNetCore.Mvc;
using Shop.DAL.DbContexts;
using Shop.Model.Products;

namespace Shop.WebUI.Controllers;

public class ProductController : Controller
{
    private readonly ShopDbContext _shopDbContext;

    public ProductController(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    //...........................................
    public IActionResult Index()
    {
        IEnumerable<Product> ProductList = _shopDbContext.Products.ToList();
        return View(ProductList);
    }

    //...............................................
    //Get
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //Post
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if(product.Name == product.Quantity.ToString())
        {
            ModelState.AddModelError("Name", "مقدار فیلد های نام و تعداد نمیتواند برابر باشد");
        }   

        if(ModelState.IsValid)
        {
            _shopDbContext.Add(product);
            _shopDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }
    //---------------------------------------------------------------
    //Get
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }

        var product = _shopDbContext.Products.Find(id);
        if(product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    //Post
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (product.Name == product.Quantity.ToString())
        {
            ModelState.AddModelError("Name", "مقدار فیلد های نام و تعداد نمیتواند برابر باشد");
        }

        if (ModelState.IsValid)
        {
            _shopDbContext.Update(product);
            _shopDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }
    //-----------------------------------------------------
    //Get
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var product = _shopDbContext.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    //Post
    [HttpPost]
    public IActionResult DeletePost(int? id)
    {
        var product = _shopDbContext.Products.Find(id);
        _shopDbContext.Remove(product);
        _shopDbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}
