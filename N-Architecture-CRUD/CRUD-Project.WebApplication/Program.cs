using Microsoft.EntityFrameworkCore;
using CRUD_Project.DAL.DataContext;
using CRUD_Project.DAL.Repositories;
using CRUD_Project.Models;
using CRUD_Project.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//conection to database
builder.Services.AddDbContext<DBCRUDTESTContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LinkSQL"));
});

builder.Services.AddScoped<IGenericRepository<Contact>, ContactRepository>();
//con esto indicamos que cualquier clase que intente utilizar la interfaz de Contact Repositories
//lo trabajara directamente con ContactRepositories
builder.Services.AddScoped<IContactServices, ContactServices>();
//aqui es lo mismo, inyectamos las dependencias para que contac services pueda ser llamado en cualquier parte del proyecto

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
