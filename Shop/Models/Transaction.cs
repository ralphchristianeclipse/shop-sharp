using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
  public class Transaction
  {
    public int Id { get; set; }
    public double Amount { get; set; }
    public List<Item> Items { get; set; }
  }
}