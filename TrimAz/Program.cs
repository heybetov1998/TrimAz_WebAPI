using Business.Auth;
using Business.Repositories;
using Business.Services;
using DAL.Abstracts;
using DAL.Context;
using DAL.Implementations;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cors error

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//builder.Services.AddAutoMapper(n => n.AddProfile(new Mapper()));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IProductService, ProductRepository>();
builder.Services.AddScoped<IProductDAL, ProductRepositoryDAL>();

builder.Services.AddScoped<IBarberService, BarberRepository>();
builder.Services.AddScoped<IUserDAL, UserRepositoryDAL>();

builder.Services.AddScoped<IBarbershopService, BarbershopRepository>();
builder.Services.AddScoped<IBarbershopDAL, BarbershopRepositoryDAL>();

builder.Services.AddScoped<IServiceService, ServiceRepository>();
builder.Services.AddScoped<IServiceDAL, ServiceRepositoryDAL>();

builder.Services.AddScoped<IBlogService, BlogRepository>();
builder.Services.AddScoped<IBlogDAL, BlogRepositoryDAL>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddScoped<IEmailSender, EmailSender>();


var app = builder.Build();


app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/img"
});

app.MapControllers();

app.Run();
