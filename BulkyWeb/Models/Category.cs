using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [MaxLength(30)]
    [Required]
    public string Name { get; set; }

    [Range(1, 100)]
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
  }
}