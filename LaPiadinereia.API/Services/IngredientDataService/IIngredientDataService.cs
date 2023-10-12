using LaPiadinereia.API.Dtos;
using LaPiadinereia.API.Models;

namespace LaPiadinereia.API.Services.IngredientDataService
{
    public interface IIngredientDataService
    {
        IEnumerable<Piadina.Ingredient> GetIngredients(int piadinaId);
        Piadina.Ingredient PostIngredient(int piadinaId, PiadinaDto.IngredientDto ingredient);
        bool PutIngredient(int piadinaId, int ingredientId , PiadinaDto.IngredientDto ingredient);
        bool DeleteIngredient(int piadinaId, int ingredientId);
    }
}
