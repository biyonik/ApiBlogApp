using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.DataTransformationObjects.DTOs.Category;
using ApiBlogApp.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlogApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = _mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllSortedByIdAsync());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = _mapper.Map<CategoryListDto>(await _categoryService.FindByIdAsync(id));
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            var x = _mapper.Map<Category>(categoryAddDto);
            await _categoryService.AddAsync(x);
            return Created("", x);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
            {
                return BadRequest("Geçersiz parametre");
            }

            var data = _mapper.Map<Category>(categoryUpdateDto);
            await _categoryService.UpdateAsync(data);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = await _categoryService.FindByIdAsync(id);
            if (deletedCategory == null)
            {
                return BadRequest("Geçersiz parametre");
            }

            await _categoryService.RemoveAsync(deletedCategory);
            return NoContent();
        }
    }
}