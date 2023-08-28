using Microsoft.EntityFrameworkCore;
using CRUD_Project.DAL.DataContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//conection to database
builder.Services.AddDbContext<DBCRUDTESTContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LinkSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
