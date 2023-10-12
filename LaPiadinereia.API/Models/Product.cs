namespace LaPiadinereia.API.Models
{
    public abstract class Product 
    {

        public enum ProductType
        {
            Piadina = 1,
            Drink = 2,
            Snack = 3,
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid Sku { get; set; }
        public abstract ProductType Type { get; }
    }
}
