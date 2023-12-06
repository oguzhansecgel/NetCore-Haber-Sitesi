using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.CategoryDtos
{
	public class UpdateCategoryDto
	{
		public int CategoryID { get; set; }

        [Required(ErrorMessage = "Kategori Adı Boş Geçilemez")]
        public string CategoryName { get; set; }
	}
}
