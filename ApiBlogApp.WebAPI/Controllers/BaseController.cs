using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using ApiBlogApp.WebAPI.Enums;
using ApiBlogApp.WebAPI.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlogApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<UploadModel> UploadFileAsync(IFormFile file, string contentType)
        {
            var uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType == contentType)
                {
                    var fileName = Guid.NewGuid() + DateTime.Now.ToShortDateString() +
                                   Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.Name = fileName;
                    uploadModel.UploadState = UploadState.Success;
                }
                else
                {
                    uploadModel.UploadState = UploadState.Error;
                    uploadModel.ErrorMessage = "Geçersiz dosya türü!";
                } 
            }
            else
            {
                uploadModel.UploadState = UploadState.NotExist;
                uploadModel.ErrorMessage = "Yüklemek için bir dosya bulunamadı!";
            }
            return uploadModel;
        }
    }
}