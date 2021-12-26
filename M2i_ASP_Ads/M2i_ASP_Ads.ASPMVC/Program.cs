using M2i_ASP_Ads.ASPMVC.Services;
using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IRepository<Offer>, AdsRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<FavoriteService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "adsList",
    pattern: "offers/list",
    defaults: new { controller="Offer", action="List"});

app.MapControllerRoute(
    name: "adsNew",
    pattern: "offers/new",
    defaults: new {controller="Offer", action="New"});

app.MapControllerRoute(
    name: "adsDetails",
    pattern: "offers/details/{id}",
    defaults: new {controller="Offer", action="Details"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();