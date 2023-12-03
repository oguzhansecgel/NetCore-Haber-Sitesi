using EntityLayer.Concrete;
using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.NewsDtos
{
	public class ResultNewsDto
	{
		public int NewsID { get; set; }
		public string NewsTitle { get; set; }
		public string NewsSummary { get; set; }
		public string NewsContent { get; set; }
		public bool EditorPick { get; set; }
		public DateTime NewsEnterTime { get; set; }
		public int CategoryID { get; set; }

		public List<ResultNewsImageDto> NewsImage { get; set; }
		public List<ResultCategoryDto> Category{ get; set; }
	}
}
