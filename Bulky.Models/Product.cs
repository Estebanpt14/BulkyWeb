using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }

    [MaxLength(30)]
    [Required]
    public string Title { get; set; }


    [Required]
    public string Description { get; set; }

    [Required]
    public string ISBN { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    [Display(Name = "List Price")]
    [Range(1, 10000)]
    public double ListPrice { get; set; }

    [Required]
    [Display(Name = "Price for 1-50")]
    [Range(1, 10000)]
    public double Price { get; set; }

    [Required]
    [Display(Name = "Price for 50-100")]
    [Range(1, 10000)]
    public double Price50 { get; set; }

    [Required]
    [Display(Name = "List for 100+")]
    [Range(1, 10000)]
    public double Price100 { get; set; }
  }
}