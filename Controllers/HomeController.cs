using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdNCat.Models;

namespace ProdNCat.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context; 

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {

        ViewBag.allProduct = _context.Products.ToList();
        return View("Index");
    }

    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if(!ModelState.IsValid)
        {
            return View("Index");
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [HttpGet("product/{productId}")]
    public IActionResult ShowProduct(int productId)
    {
        Product? product = _context.Products.Include(aList => aList.AssociationsList).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == productId);
        ViewBag.allCategories = _context.Categories.ToList();
        if(product == null)
        {
            return RedirectToAction("Index");
        }
        return View("ShowProduct", product);
    }
    
    [HttpPost("association/create")]
    public IActionResult CreateAssociation(ProdCatAssociation newAssociation)
    {
        int prodId = newAssociation.ProductId;

        if(!ModelState.IsValid)
        {
            return View("Index");
        }
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
    // [HttpGet("/allProduct")]
    // public IActionResult AllProduct()
    // {
        
    //     return View("_AllProduct", allProduct);
    // }

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
