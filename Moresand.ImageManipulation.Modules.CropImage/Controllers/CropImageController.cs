using Microsoft.AspNetCore.Mvc;
using Moresand.ImageManipulation.Modules.CropImage.Dto.Request;
using Moresand.ImageManipulation.Modules.CropImage.Dto.Response;

namespace Moresand.ImageManipulation.Modules.CropImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CropImageController : ControllerBase
    {
        [HttpPost]
        public CropImageResponse CropImage(CropImageRequest request)
        {
            var response = CropImageSize(request);
            
            return response;
        }

        // Fake Implementation, returns same image without changing
        private static CropImageResponse CropImageSize(CropImageRequest request)
        {
            var response = new CropImageResponse();
            var ms = new MemoryStream();
            request.File.CopyTo(ms);
            response.File = ms.ToArray();

            return response;
        }
    }
}