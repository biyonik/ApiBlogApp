using ApiBlogApp.DataTransformationObjects.Abstract;

namespace ApiBlogApp.DataTransformationObjects.DTOs.Category
{
    public class CategoryAddDto: IDto
    {
        public string Name { get; set; }
    }
}