﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.News
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
	}
}
