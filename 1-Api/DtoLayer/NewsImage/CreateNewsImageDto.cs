using Microsoft.AspNetCore.Http;

namespace DtoLayer.NewsImage
{
	public class CreateNewsImageDto
	{
		public int NewsID { get; set; }

		public IFormFile UploadedImage { get; set; }
	}
}
