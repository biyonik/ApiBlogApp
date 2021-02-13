using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using ApiBlogApp.BusinessLogic.Abstract;
using ApiBlogApp.DataTransformationObjects.DTOs.Blog;
using ApiBlogApp.Entities.Concrete;
using ApiBlogApp.WebAPI.Enums;
using ApiBlogApp.WebAPI.Models.Blog;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlogApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController: BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _blogService.GetAllSortedByPostedTimeAsync();
            var blogList = _mapper.Map<List<BlogListDto>>(list);
            return Ok(blogList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _blogService.FindByIdAsync(id);
            var blog = _mapper.Map<BlogListDto>(entity);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");
            switch (uploadModel.UploadState)
            {
                case UploadState.Success:
                    blogAddModel.ImagePath = uploadModel.Name;
                    await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                    break;
                case UploadState.NotExist:
                    await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                    break;
                case UploadState.Error:
                    return BadRequest(uploadModel.ErrorMessage);
                default:
                    return BadRequest(uploadModel.ErrorMessage);
            }
            return Created("",blogAddModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            var updatedBlog = await _blogService.FindByIdAsync(id);
            if (updatedBlog == null)
            {
                return BadRequest("Geçersiz parametre!");
            }

            var oldImagePath = updatedBlog.ImagePath;
            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");
            switch (uploadModel.UploadState)
            {
                case UploadState.Success:
                    uploadModel.Name = blogUpdateModel.ImagePath ?? updatedBlog.ImagePath;
                    updatedBlog.ShortDescription = blogUpdateModel.ShortDescription ?? updatedBlog.ShortDescription;
                    updatedBlog.Content = blogUpdateModel.Content ?? updatedBlog.Content;
                    updatedBlog.Title = blogUpdateModel.Title ?? updatedBlog.Title;
                    if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/"+oldImagePath)))
                    {
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/"+oldImagePath));
                    }
                    await _blogService.UpdateAsync(updatedBlog);
                    break;
                case UploadState.NotExist:
                    updatedBlog.Title = blogUpdateModel.Title ?? updatedBlog.Title;
                    updatedBlog.ShortDescription = blogUpdateModel.ShortDescription ?? updatedBlog.ShortDescription;
                    updatedBlog.Content = blogUpdateModel.Content ?? updatedBlog.Content;
                    await _blogService.UpdateAsync(updatedBlog);
                    break;
                case UploadState.Error:
                    return BadRequest(uploadModel.ErrorMessage);
                default:
                    return BadRequest(uploadModel.ErrorMessage);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedBlog = await _blogService.FindByIdAsync(id);
            await _blogService.RemoveAsync(deletedBlog);
            return NoContent();
        }
    }
}