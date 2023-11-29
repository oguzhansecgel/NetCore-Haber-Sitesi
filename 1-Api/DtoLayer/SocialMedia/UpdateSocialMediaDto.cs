using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SocialMedia
{
	public class UpdateSocialMediaDto
	{
		public int SocialMediaID { get; set; }
		public string InstagramURL { get; set; }
		public string TwitterURL { get; set; }
		public string FacebookURL { get; set; }
		public string YoutubeURL { get; set; }
	}
}
