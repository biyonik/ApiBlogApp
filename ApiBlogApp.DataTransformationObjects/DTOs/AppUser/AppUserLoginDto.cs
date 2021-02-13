using ApiBlogApp.DataTransformationObjects.Abstract;

namespace ApiBlogApp.DataTransformationObjects.DTOs.AppUser
{
    public class AppUserLoginDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}