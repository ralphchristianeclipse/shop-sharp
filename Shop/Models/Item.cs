namespace Shop.Models
{
  public class Item
  {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

  }
}