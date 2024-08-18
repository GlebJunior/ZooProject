using Microsoft.EntityFrameworkCore;
using PetShopProject.Data;
using PetShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AnimalsRepository>();
builder.Services.AddScoped<CommentsRepository>();
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddDbContext<DataBase>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));});
builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", options =>
{
    options.Cookie.Name = "AuthCookie";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdministrator", policy => policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(options =>
{
    options.EnableEndpointRouting = false;
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStatusCodePages(context =>
    {
        if (context.HttpContext.Response.StatusCode == 404)
        {
            context.HttpContext.Response.Redirect("/Error");
        }
        return Task.CompletedTask;
    });
}
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<DataBase>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();    
app.MapRazorPages();
app.Run();
