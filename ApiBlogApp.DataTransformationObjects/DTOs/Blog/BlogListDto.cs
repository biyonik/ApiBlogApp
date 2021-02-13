using System;
using ApiBlogApp.DataTransformationObjects.Abstract;

namespace ApiBlogApp.DataTransformationObjects.DTOs.Blog
{
    public class BlogListDto: IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
    }
}