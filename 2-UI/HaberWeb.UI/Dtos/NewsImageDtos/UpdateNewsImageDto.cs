﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberWeb.UI.Dtos.NewsImageDtos
{
	public class UpdateNewsImageDto
	{
		public int NewsImageID { get; set; }
		public string Path { get; set; }
		public bool ContentImage { get; set; }
		public int NewsID { get; set; }
	}
}
