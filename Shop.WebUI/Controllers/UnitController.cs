using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Framework;
using Shop.Model.Units;

namespace Shop.WebUI.Controllers;

public class UnitController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //.......................Read........................
    public IActionResult Index()
    {
        IEnumerable<Unit> UnitList = _unitOfWork.Unit.GetAll();
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
            _unitOfWork.Unit.Add(unit);
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

        var unit = _unitOfWork.Unit.GetFirstOrDefault(u => u.Id == id);
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
            _unitOfWork.Unit.Update(unit);
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

        var unit = _unitOfWork.Unit.GetFirstOrDefault(u => u.Id == id);
        if (unit == null)
        {
            return NotFound();
        }

        return View(unit);
    }
    [HttpPost]
    public IActionResult DeletePost(int? id)
    {
        var unit = _unitOfWork.Unit.GetFirstOrDefault(u => u.Id == id);
        _unitOfWork.Unit.Remove(unit);
        TempData["success"] = "محصول با موفقیت حذف شد";
        return RedirectToAction("Index");
    }
}