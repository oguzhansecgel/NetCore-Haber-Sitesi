using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.NewsDtos
{
	public class CreateNewsDto
	{
        [Required(ErrorMessage = "Haber Başlığı Boş Geçilemez")]

        public string NewsTitle { get; set; }
        [Required(ErrorMessage = "Haber Açıklaması Boş Geçilemez")]
        public string NewsSummary { get; set; }
        [Required(ErrorMessage = "Haber İçeriği Boş Geçilemez")]
        public string NewsContent { get; set; }
		public bool EditorPick { get; set; }
		public DateTime NewsEnterTime { get; set; }
        public int CategoryID { get; set; }
	}
}
