using Microsoft.EntityFrameworkCore;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.Feature.Reposoratory;
using TraininingSystem.BLL.Mapping;
using TraininingSystem.DAL.Databae;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Enhancement ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
//AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new Mapp()));
//Dependancy Injection Add Scope
builder.Services.AddScoped<ITrackRepo, TrackRepo>();
builder.Services.AddScoped<ITraineeRepo, TraineeRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

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
    pattern: "{controller=Track}/{action=Index}/{id?}");

app.Run();
