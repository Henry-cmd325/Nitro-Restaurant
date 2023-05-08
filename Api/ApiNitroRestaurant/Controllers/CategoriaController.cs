using ApiNitroRestaurant.Models.Request;
using ApiNitroRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult CategoriaGetAll()
        {
            var response = _categoryService.GetAll();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}", Name = "CategoriaGet")]
        public IActionResult CategoriaGet(int id)
        {
            var response = _categoryService.GetCategory(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CategoriaPost(CategoriaRequest model)
        {
            var response = _categoryService.PostCategory(model);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult CategoriaDelete(int id)
        {
            var response = _categoryService.DeleteCategory(id);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult CategoriaPut(int id, CategoriaRequest model)
        {
            var response = _categoryService.PutCategory(id, model);

            if (!response.Success) return BadRequest(response);
            
            return NoContent();
        }
    }
}
