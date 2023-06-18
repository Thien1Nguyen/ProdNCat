using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdNCat.Models;

namespace ProdNCat.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context; 

    public CategoryController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.allCategories = _context.Categories.ToList();
        return View();
    }

    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if(!ModelState.IsValid)
        {
            return View("Index");
        }
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult ShowCategory(int categoryId)
    {
        Category? category= _context.Categories.Include(aList => aList.AssociationsList).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == categoryId);
        ViewBag.allProducts = _context.Products.ToList();
        if(category == null)
        {
            return RedirectToAction("Index");
        }
        return View("ShowCategory", category);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
