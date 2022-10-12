using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Display(Name = "Display Order(for the book)")]
    public int DisaplayOrder { get; set; }
    
}