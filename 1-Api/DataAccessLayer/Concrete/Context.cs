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
			optionsBuilder.UseSqlServer("server=DESKTOP-3QG9GTV;initial catalog = CorumHaber; integrated security=true");
		}
		public DbSet<News> Newses { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<NewsImage> NewsImages{ get; set; }
		public DbSet<SocialMedia> SocialMedias{ get; set; }

	}
}
