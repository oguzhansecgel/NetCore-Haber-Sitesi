using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.CategoryDtos
{
	public class CreateCategoryDto
	{
		[Required(ErrorMessage = "Kategori Adı Boş Geçilemez")]
		public string CategoryName { get; set; }

	}
}
