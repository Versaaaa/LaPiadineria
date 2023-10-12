namespace LaPiadinereia.API.Models
{
    public class Drink : Product
    {
        public override ProductType Type { get { return ProductType.Drink; } }
    }
}
