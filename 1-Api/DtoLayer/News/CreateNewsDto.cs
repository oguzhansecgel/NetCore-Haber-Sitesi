﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.News
{
	public class CreateNewsDto
	{
		public string NewsTitle { get; set; }
        public string? NewsContentTitle { get; set; }
        public string? NewsContentTitle2 { get; set; }
        public string NewsSummary { get; set; }
		public string NewsContent { get; set; }
        public string? NewsContent2 { get; set; }
        public string? NewsContent3 { get; set; }
        public bool EditorPick { get; set; }
		public DateTime NewsEnterTime { get; set; }
		public int CategoryID { get; set; }
	}
}
