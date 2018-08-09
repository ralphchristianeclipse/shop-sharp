using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
  public class Product
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    [Required]
    public double Price { get; set; }

    [Timestamp]
    public DateTime Timestamp { get; set; }

    public List<Item> Items { get; set; }
  }


}
