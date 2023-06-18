#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ProdNCat.Models;

public class Category
{
    [Key]
    public int CategoryId {get;set;}
    [Required]
    public string Name {get;set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<ProdCatAssociation> AssociationsList  {get; set;} = new List<ProdCatAssociation>();
}