using AutoMapper;
using Loja.Config;
using Loja.Context;
using Loja.Dtos;
using Loja.Dtos.Mapping;
using Loja.Errors;
using Loja.Models;
using Loja.Repository;
using Loja.Repository.Interface;
using Loja.Service;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(ConnectionString,
    ServerVersion.AutoDetect(ConnectionString)));

//ativando o serviço do IdentityUser, porem personalizado, para as PK serem long
builder.Services.AddIdentity<IdentityUser<long>, IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


//ativando token Jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(opt =>
       opt.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidAudience = builder.Configuration["TokenConfig:Audience"],
           ValidIssuer = builder.Configuration["TokenConfig:Issuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))
       });


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var mapping = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapping.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ILoginService, LoginService>();

//CORS
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(c=> {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
}
);;
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
