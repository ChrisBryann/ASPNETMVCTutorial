using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>(); // AddEntitFrameworkStores adds the identity tables (users, roles, etc), and RequiredConfirmAccount is to tell if the account should be confirmed or not
// inject the categoryRepository service
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// adding DI types - transient, scoped, singleton
// transient - new instance every time the transient service is requested, scoped - new instance once per request, singleton - new once per lifetime
// once defined, we can add the inject the service in any controller
//builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();
//builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();
//builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
