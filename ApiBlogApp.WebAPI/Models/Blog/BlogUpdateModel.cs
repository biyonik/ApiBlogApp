using ApiBlogApp.WebAPI.Models.Abstract;
using Microsoft.AspNetCore.Http;

namespace ApiBlogApp.WebAPI.Models.Blog
{
    public class BlogUpdateModel: IModel
    {
        // public int? Id { get; set; }
        // public int AppUserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}