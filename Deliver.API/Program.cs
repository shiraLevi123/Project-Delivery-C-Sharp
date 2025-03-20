using Deliver.API.Mapping;
using Deliver.Core.Mapping;
using Deliver.Core.Repositories;
using Deliver.Core.Service;
using Deliver.Data;
using Deliver.Data.Repositories;
using Deliver.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Text;

using IGoogleMapsService = Deliver.Core.Service.IGoogleMapsService;


var myPolicy = "_policy";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://localhost:52066/")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();

        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat ="JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description ="Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
});


      options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
               {
               Id ="Bearer",
               Type = ReferenceType.SecurityScheme
                   }
               },
            new List<string>()
           }
         });
     });



//Delivery
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(LoginModelsMappingProfile));

//Order
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddHttpClient<IGoogleMapsService, GoogleMapsService>();

builder.Services.AddSingleton<IGoogleMapsService>
    (new GoogleMapsService("AIzaSyCFaRj-zY8b71AFA7XjLfK61GuFDxnp3pw"));
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(@"Server=DESKTOP-F6TEN9G;Database=Delivers1;TrustServerCertificate=True;Trusted_Connection=True"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new
        SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myPolicy);
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
