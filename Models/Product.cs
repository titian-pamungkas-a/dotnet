namespace EmptyProject.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

    }
}
