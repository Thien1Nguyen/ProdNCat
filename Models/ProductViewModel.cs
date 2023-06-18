#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ProdNCat.Models;

public class ProductViewModel
{
    public Product NewProduct {get;set; }
    public List<Product>? ListOfAllProducts {get; set;} = new List<Product>();
}