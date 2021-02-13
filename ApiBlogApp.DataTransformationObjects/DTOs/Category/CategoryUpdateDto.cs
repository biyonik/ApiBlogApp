using ApiBlogApp.DataTransformationObjects.Abstract;

namespace ApiBlogApp.DataTransformationObjects.DTOs.Category
{
    public class CategoryUpdateDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}