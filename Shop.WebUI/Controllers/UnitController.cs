using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Units;
using Shop.Model.Units;

namespace Shop.WebUI.Controllers;

public class UnitController : Controller
{
    private readonly UnitService _unitService;

    public UnitController(UnitService unitService)
    {
        _unitService = unitService;
    }

    //.......................Read........................
    public IActionResult Index()
    {
        IEnumerable<Unit> UnitList = _unitService.GetAll();
        return View(UnitList);
    }

    //.......................Create........................
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Unit unit)
    {
        if (ModelState.IsValid)
        {
            _unitService.Add(unit);
            TempData["success"] = "محصول جدید با موفقیت اضافه شد";
            return RedirectToAction("Index");
        }
        return View(unit);
    }

    //.......................Update........................
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var unit = _unitService.GetFirstOrDefault(u => u.Id == id);
        if (unit == null)
        {
            return NotFound();
        }

        return View(unit);
    }
    [HttpPost]
    public IActionResult Edit(Unit unit)
    {
        if (ModelState.IsValid)
        {
            _unitService.Update(unit);
            TempData["success"] = "محصول با موفقیت ویرایش شد";
            return RedirectToAction("Index");
        }
        return View(unit);
    }

    //.......................Delete........................
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var unit = _unitService.GetFirstOrDefault(u => u.Id == id);
        if (unit == null)
        {
            return NotFound();
        }

        return View(unit);
    }
    [HttpPost]
    public IActionResult DeletePost(int? id)
    {
        var unit = _unitService.GetFirstOrDefault(u => u.Id == id);
        _unitService.Remove(unit);
        TempData["success"] = "محصول با موفقیت حذف شد";
        return RedirectToAction("Index");
    }
}