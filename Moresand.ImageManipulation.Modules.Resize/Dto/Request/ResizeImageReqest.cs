using Microsoft.AspNetCore.Http;

namespace Moresand.ImageManipulation.Modules.ResizeImage.Dto.Request
{
    public class ResizeImageReqest
    {
        public IFormFile File { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
