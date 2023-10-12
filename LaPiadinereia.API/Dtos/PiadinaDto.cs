using LaPiadinereia.API.Models;

namespace LaPiadinereia.API.Dtos
{
    public class PiadinaDto : ProductDto
    {
        public class IngredientDto
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public List<IngredientDto> Ingredients { get; set; }
        public Piadina.Shapes Shape { get; set; }

    }
}
