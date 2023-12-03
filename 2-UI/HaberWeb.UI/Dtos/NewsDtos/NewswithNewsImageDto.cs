using HaberWeb.UI.Dtos.NewsImageDtos;

namespace HaberWeb.UI.Dtos.NewsDtos
{
	public class NewswithNewsImageDto
	{
		public ResultNewsDto News { get; set; }
		public List<ResultNewsImageDto> NewsImages { get; set; }
	}
}
