namespace LaPiadinereia.API.Models
{
    public class Piadina : Product
    {

        public class Ingredient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public enum Shapes
        {
            Shape1,
            Shape2,
            Shape3,
            Shape4,
            Shape5,
        }

        public override ProductType Type { get { return ProductType.Piadina; } }
        public List<Ingredient> Ingredients { get; set; }
        public Shapes Shape { get; set; }

    }
}
