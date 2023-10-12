using LaPiadinereia.API.Dtos;
using LaPiadinereia.API.Models;
using LaPiadinereia.API.Services;
using LaPiadinereia.API.Services.IngredientDataService;
using Microsoft.AspNetCore.Mvc;
using static LaPiadinereia.API.Models.Piadina;

namespace LaPiadinereia.API.Controllers
{
    [ApiController]
    [Route("api/Piadina/{piadinaId}/[controller]")]
    public class IngredientController : ControllerBase
    {

        IIngredientDataService _ingredientDataService;

        public IngredientController(IIngredientDataService ingredientDataService)
        {
            _ingredientDataService = ingredientDataService;
        }

        [HttpGet]
        public IActionResult GetIngredients(int piadinaId)
        {
            try
            {
                return Ok(_ingredientDataService.GetIngredients(piadinaId));
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("{ingredientId:int}", Name = nameof(GetIngredient))]
        public IActionResult GetIngredient(int piadinaId, int ingredientId)
        {
            try
            {
                return Ok(_ingredientDataService.GetIngredients(piadinaId).First(x => x.Id == ingredientId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostIngredient(int piadinaId, [FromBody]PiadinaDto.IngredientDto ingredient)
        {
            try
            {
                var res = _ingredientDataService.PostIngredient(piadinaId, ingredient);
                return CreatedAtRoute(nameof(GetIngredient), new {piadinaId = piadinaId, ingredientId = res.Id}, res);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("ingredientId:int")]
        public IActionResult PutIngredient(int piadinaId, int ingredientId, [FromBody] PiadinaDto.IngredientDto ingredient)
        {
            try
            {
                _ingredientDataService.PutIngredient(piadinaId, ingredientId, ingredient);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("ingredientId:int")]
        public IActionResult DeleteIngredient(int piadinaId, int ingredientId)
        {
            try
            {
                _ingredientDataService.DeleteIngredient(piadinaId, ingredientId);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
