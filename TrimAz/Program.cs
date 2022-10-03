using Business.Auth;
using Business.Repositories;
using Business.Services;
using DAL.Abstracts;
using DAL.Context;
using DAL.Implementations;
using Entity.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrimAz.Commons.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });

    //cors error
    services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
        });
    });

    services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    // configure strongly typed settings object
    services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
    services.Configure<JWTConfig>(builder.Configuration.GetSection("JWT"));

    // configure DI for application services
    services.AddScoped<IProductService, ProductRepository>();
    services.AddScoped<IProductDAL, ProductRepositoryDAL>();

    services.AddScoped<IBarberService, BarberRepository>();

    services.AddScoped<IBarbershopService, BarbershopRepository>();
    services.AddScoped<IBarbershopDAL, BarbershopRepositoryDAL>();

    services.AddScoped<IServiceService, ServiceRepository>();
    services.AddScoped<IServiceDAL, ServiceRepositoryDAL>();

    services.AddScoped<IBlogService, BlogRepository>();
    services.AddScoped<IBlogDAL, BlogRepositoryDAL>();

    services.AddScoped<IImageService, ImageRepository>();
    services.AddScoped<IImageDAL, ImageRepositoryDAL>();

    services.AddScoped<IUserService, UserRepository>();
    services.AddScoped<IUserDAL, UserRepositoryDAL>();

    services.AddScoped<IJwtUtils, JwtUtils>();

    services.AddScoped<IEmailSender, EmailSender>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedEmail = false;
        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

    // JWT Authentication
    //builder.Services
    //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //    .AddJwtBearer(options =>
    //    {
    //        options.TokenValidationParameters = new TokenValidationParameters
    //        {
    //            ValidateIssuer = true,
    //            ValidateAudience = true,
    //            ValidateLifetime = true,
    //            ValidateIssuerSigningKey = true,
    //            ValidIssuer = builder.Configuration["JWT:Issuer"],
    //            ValidAudience = builder.Configuration["JWT:Audience"],
    //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    //        };
    //    });
}



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

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
