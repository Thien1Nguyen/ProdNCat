#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ProdNCat.Models;

public class ProdCatAssociation
{
    [Key]
    public int AssociationId {get;set;}
    public int ProductId {get;set;}
    public int CategoryId {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Product? Product {get;set;}
    public Category? Category {get;set;}
}