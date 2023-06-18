#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ProdNCat.Models;

public class Product
{
    [Key]
    public int ProductId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    public float Price {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<ProdCatAssociation>? AssociationsList {get; set;} = new List<ProdCatAssociation>();
}