using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.NewsImageDtos
{
	public class CreateNewsImageDto
	{
		public int NewsID { get; set; }
		public IFormFile FileImage { get; set; }
		public bool ContentImage { get; set; }

	}
}
