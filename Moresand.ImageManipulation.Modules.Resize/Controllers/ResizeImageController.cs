using Microsoft.AspNetCore.Mvc;
using Moresand.ImageManipulation.Modules.ResizeImage.Dto.Request;
using Moresand.ImageManipulation.Modules.ResizeImage.Dto.Response;

namespace Moresand.ImageManipulation.Modules.ResizeImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResizeImageController : ControllerBase
    {
        [HttpPost]
        public ResizeImageResponse ResizeImage(ResizeImageReqest request)
        {
            var response = ResizeImageSize(request);

            return response;
        }

        // Fake Implementation, returns same image without changing
        private static ResizeImageResponse ResizeImageSize(ResizeImageReqest request)
        {
            var response = new ResizeImageResponse();
            var ms = new MemoryStream();
            request.File.CopyTo(ms);
            response.File = ms.ToArray();

            return response;
        }
    }
}
