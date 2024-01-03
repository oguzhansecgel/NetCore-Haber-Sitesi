using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=mssql03.trwww.com;database=vatantvc_db1;user=vatantv;password=Ferdi19.#");

		}
        public DbSet<News> Newses { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<NewsImage> NewsImages{ get; set; }
		public DbSet<SocialMedia> SocialMedias{ get; set; }

	}
}
