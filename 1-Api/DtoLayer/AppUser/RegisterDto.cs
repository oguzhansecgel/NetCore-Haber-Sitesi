﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AppUser
{
	public class RegisterDto
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
	}
}
