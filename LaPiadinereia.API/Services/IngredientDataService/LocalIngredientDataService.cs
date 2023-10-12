using LaPiadinereia.API.Dtos;
using LaPiadinereia.API.Models;
using LaPiadinereia.API.Services.ProductDataService;

namespace LaPiadinereia.API.Services.IngredientDataService
{
    public class LocalIngredientDataService : IIngredientDataService
    {

        IProductDataService _productDataService;

        public LocalIngredientDataService(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public IEnumerable<Piadina.Ingredient> GetIngredients(int piadinaId)
        {
            return ((Piadina)_productDataService.GetProducts().Where(x => x is Piadina).First(x => x.Id == piadinaId)).Ingredients;
        }

        public Piadina.Ingredient PostIngredient(int piadinaId, PiadinaDto.IngredientDto ingredient)
        {

            var res = new Piadina.Ingredient() 
            { 
                Name = ingredient.Name,
                Price = ingredient.Price,
            };

            res.Id = _productDataService.GetProducts().Where(x => x is Piadina).SelectMany(x => ((Piadina)x).Ingredients).Max(x => x.Id) + 1;

            ((Piadina)_productDataService.GetProducts().Where(x => x is Piadina).First(x => x.Id == piadinaId)).Ingredients.Add(res);
            return res;
        }

        public bool PutIngredient(int piadinaId, int ingredientId, PiadinaDto.IngredientDto ingredient)
        {

            var res = ((Piadina)_productDataService.GetProducts().Where(x => x is Piadina).First(x => x.Id == piadinaId)).Ingredients.First(x => x.Id == ingredientId);

            res.Name = ingredient.Name;
            res.Price = ingredient.Price;

            return true;
        }

        public bool DeleteIngredient(int piadinaId, int ingredientId)
        {
            return ((Piadina)_productDataService.GetProducts().Where(x => x is Piadina).First(x => x.Id == piadinaId)).Ingredients.Remove(((Piadina)_productDataService.GetProducts().Where(x => x is Piadina).First(x => x.Id == piadinaId)).Ingredients.First(x => x.Id == ingredientId));
        }
    }
}
