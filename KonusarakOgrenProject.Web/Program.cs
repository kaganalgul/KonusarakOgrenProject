using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.Business.Concrete;
using KonusarakOgrenProject.Core.CronJob;
using KonusarakOgrenProject.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connectionString));

//builder.Services.AddCronJob<MyCronJob>();
builder.Services.AddSession();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IGetArticleFromWebsiteService, GetArticleFromWebsiteManager>();
builder.Services.AddScoped<ICreateExamService, CreateExamManager>();
builder.Services.AddScoped<IDeleteExamService, DeleteExamManager>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSession();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");
app.MapRazorPages();

app.Run();
