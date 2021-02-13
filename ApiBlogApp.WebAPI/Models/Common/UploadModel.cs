using ApiBlogApp.WebAPI.Enums;

namespace ApiBlogApp.WebAPI.Models.Common
{
    public class UploadModel
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }
    }
}