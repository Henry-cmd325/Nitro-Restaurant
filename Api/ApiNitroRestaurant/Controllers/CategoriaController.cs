using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNitroRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriaController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}", Name = "CategoriaGet")]
        public IActionResult CategoriaGet(int id)
        {
            var response = _categoryService.GetCategory(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CategoriaPost([FromBody] CategoriaRequest model)
        {
            var response = _categoryService.PostCategory(model);

            if (!response.Success) return BadRequest(response);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult CategoriaDelete(int id)
        {
            var response = _categoryService.DeleteCategory(id);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
