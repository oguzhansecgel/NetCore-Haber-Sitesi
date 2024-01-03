using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
// Configure Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(500);
    options.LoginPath = "/Login/";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "Anasayfa",
		pattern: "",
		defaults: new { controller = "UIHomePage", action = "Index" }
	);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Haberler",
        pattern: "Haberler",
        defaults: new { controller = "HomePage", action = "Index" }
    );
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "HaberDetayi",
        pattern: "HaberDetayi",
        defaults: new { controller = "NewsDetails", action = "SingleContent" }
    );
});

//admin paneli
//kategori
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "AdminKategori",
		pattern: "AdminKategori",
		defaults: new { controller = "Category", action = "Index" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "kategoriekle",
		pattern: "kategoriekle",
		defaults: new { controller = "Category", action = "CreateCategory" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "kategorisil",
		pattern: "kategorisil{id}",
		defaults: new { controller = "Category", action = "DeleteCategory" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "kategoriguncelle",
		pattern: "kategoriguncelle/{id}",
		defaults: new { controller = "Category", action = "UpdateCategory" }
	);
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "AdminKategoriHaberler",
        pattern: "AdminKategoriHaberler/{id}",
        defaults: new { controller = "Category", action = "NewsWithCategory" }
    );
});

//haberler
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "AdminHaber",
		pattern: "AdminHaber",
		defaults: new { controller = "News", action = "Index" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "haberekle",
		pattern: "haberekle",
		defaults: new { controller = "News", action = "CreateNews" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "habersil",
		pattern: "habersil{id}",
		defaults: new { controller = "News", action = "DeleteNews" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "haberguncelle",
		pattern: "haberguncelle/{id}",
		defaults: new { controller = "News", action = "UpdateNews" }
	);
});

/*haber görselleri*/
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "Adminhabergorsel",
		pattern: "Adminhabergorsel",
		defaults: new { controller = "NewsImage", action = "Index" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "habergorselekle",
		pattern: "habergorselekle",
		defaults: new { controller = "NewsImage", action = "CreateNewsImage" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "habergorselsil",
		pattern: "habergorselsil{id}",
		defaults: new { controller = "NewsImage", action = "DeleteNewsImage" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "habergorselguncelle",
		pattern: "habergorselguncelle/{id}",
		defaults: new { controller = "NewsImage", action = "UpdateNewsImage" }
	);
});
/*sosyal medya*/
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "AdminSosyalMedya",
		pattern: "AdminSosyalMedya",
		defaults: new { controller = "SocialMedia", action = "Index" }
	);
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "sosyalmedyaguncelle",
		pattern: "sosyalmedyaguncelle/{id}",
		defaults: new { controller = "SocialMedia", action = "UpdateSocialMedia" }
	);
});

/*login */
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Login",
        pattern: "Login",
        defaults: new { controller = "AdminLogin", action = "Index" }
    );
});
app.Run();
