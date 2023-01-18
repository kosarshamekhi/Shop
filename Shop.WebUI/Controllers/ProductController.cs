using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Products;
using Shop.Model.Products;

namespace Shop.WebUI.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    //.......................Read........................
    public IActionResult Index()
    {
        IEnumerable<Product> ProductList = _productService.GetAll();
        return View(ProductList);
    }

    //.......................Create........................
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if(product.Name == product.Quantity.ToString())
        {
            ModelState.AddModelError("Name", "مقدار فیلد های نام و تعداد نمیتواند برابر باشد");
        }   

        if(ModelState.IsValid)
        {
            _productService.Add(product);
            TempData["success"] = "محصول جدید با موفقیت اضافه شد";
            return RedirectToAction("Index");
        }
        return View(product);
    }

    //.......................Update........................
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var product = _productService.GetFirstOrDefault(u => u.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (product.Name == product.Quantity.ToString())
        {
            ModelState.AddModelError("Name", "مقدار فیلد های نام و تعداد نمیتواند برابر باشد");
        }

        if (ModelState.IsValid)
        {
            _productService.Update(product);
            TempData["success"] = "محصول با موفقیت ویرایش شد";
            return RedirectToAction("Index");
        }
        return View(product);
    }

    //.......................Delete........................
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var product = _productService.GetFirstOrDefault(u => u.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [HttpPost]
    public IActionResult DeletePost(int? id)
    {
        var product = _productService.GetFirstOrDefault(u => u.Id == id);
        _productService.Remove(product);
        TempData["success"] = "محصول با موفقیت حذف شد";
        return RedirectToAction("Index");
    }
}
