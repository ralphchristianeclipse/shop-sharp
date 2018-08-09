using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    public readonly AppDbContext _context;
    public ProductsController(AppDbContext context)
    {
      _context = context;

      Seed();

    }
    public void Seed()
    {
      if (_context.Products.Count() == 0)
      {
        var random = new Random();
        var products = Enumerable.Range(0, 100000).Select(index => new Product() { Name = $"Item #{index}", Price = index * 1 });
        var items = Enumerable.Range(0, 5000).Select(index => new Item() { ProductId = random.Next(0, 1000), Quantity = random.Next(0, index), TransactionId = random.Next(0, 1000) });
        // var transactions = Enumerable.Range(0, 1000).Select(index => new Transaction() { Amount = index * random.Next(0, index) });

        _context.Products.AddRange(products);
        _context.Items.AddRange(items);
        // _context.Transactions.AddRange(transactions);
        _context.SaveChanges();
      }
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
      return await _context.Products.Include(p => p.Items).ToAsyncEnumerable<Product>().ToList();
    }

    [HttpGet("latest", Name = "Latest")]
    public async Task<ActionResult<IEnumerable<Product>>> GetLatest([FromQuery] int count = 5)
    {
      return await _context.Products.Include(p => p.Items).ToAsyncEnumerable<Product>().TakeLast(count).ToList();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product value)
    {
      await _context.Products.AddAsync(value);
      await _context.SaveChangesAsync();

      return value;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Put(int id, [FromBody] Product value)
    {
      var product = await _context.Products.FindAsync(id);

      product = value;

      await _context.SaveChangesAsync();
      return product;
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
      var product = await _context.Products.FindAsync(id);
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return product;
    }
  }
}
