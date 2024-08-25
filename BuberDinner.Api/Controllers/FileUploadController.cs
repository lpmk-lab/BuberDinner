using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Menu;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Api.Controllers
{
    [Route("File")]
   
    public class FileUploadController:ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IMapper _mapper;
        public readonly IMenuHandler _IDMenuHandler;
        public FileUploadController(IWebHostEnvironment webHostEnvironment, IMenuHandler IDMenuHandler, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _IDMenuHandler = IDMenuHandler;
            _mapper = mapper;
        }

        [HttpPost("uploadFile")]
        public async Task<ActionResult> UploadImage()
        {

            bool Result = false;
            ErrorOr<MasMenu> returnValue = new MasMenu();
            try
            {
                var files = Request.Form.Files;
                foreach(IFormFile source in files) 
                {

                    string fileName = source.FileName;

                    string filePath=GetFilePath(fileName);
                    if(!System.IO.File.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(filePath);

                    }
                    string imagePath = filePath + "\\image.png";
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    using (FileStream stream=System.IO.File.Create(imagePath)) { 
                     await source.CopyToAsync(stream);
                        Result = true;
                    }
                    returnValue = _IDMenuHandler.Upload(GetImageByProduct(fileName), fileName);

                }
            }
            catch (Exception ex)
            {

            }
           var result= _mapper.Map<MasMenu>(returnValue.Value);
            return Ok(result);


        }

        [NonAction]
        private string GetFilePath(string MenuID)
        {
            return this._webHostEnvironment.WebRootPath + "\\File\\Menu\\" + MenuID;
        }

        private string GetImageByProduct(string MenuID)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:5189/";
            string FilePath = GetFilePath(MenuID);
            string ImagePath= FilePath + "\\image.png";
            if(!System.IO.File.Exists (ImagePath))
            {
                ImageUrl = HostUrl + "/File/common/noimage.png";
            }
            else
            {
                ImageUrl = HostUrl + "/File/Menu/" + MenuID + "/image.png";
            }

            return ImageUrl;


        }

        [HttpDelete("Remove/{MenuID}")]
        public  ActionResult RemoveImage(string MenuID)
        {
            string FilePath = GetFilePath(MenuID);
            string ImagePath = FilePath + "\\image.png";
            if (System.IO.File.Exists(ImagePath))
            {
                System.IO.File.Delete(ImagePath);
            }
            return  Ok();
        }
    }
}
