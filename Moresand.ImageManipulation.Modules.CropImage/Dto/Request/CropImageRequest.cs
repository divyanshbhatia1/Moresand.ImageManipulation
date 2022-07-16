using Microsoft.AspNetCore.Http;

namespace Moresand.ImageManipulation.Modules.CropImage.Dto.Request
{
    public class CropImageRequest
    {
        public IFormFile File { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
