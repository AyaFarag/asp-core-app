using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;
using WebApplicationAPI.Data;
using WebApplicationAPI.Extentions;
using WebApplicationAPI.Repository;
using WebApplicationAPI.Repository.Category;
using WebApplicationAPI.Repository.Product;
using WebApplicationAPI.Service.Auth;
using WebApplicationAPI.Service.Category;
using WebApplicationAPI.Service.Product;
using WebApplicationAPI.Validation;

var builder = WebApplication.CreateBuilder(args);


var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Key))

{
    throw new InvalidOperationException("JWT secret key is not configured.");
}

var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.ValidIssuer,
        ValidAudience = jwtSettings.ValidAudience,
        IssuerSigningKey = secretKey
    };
    o.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                message = "You are not authorized to access this resource. Please authenticate."
            });
            return context.Response.WriteAsync(result);
        },
    };
});


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "July Shop 2025", Version = "v1", Description = "Shop 2025 description" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid token in the following format: {your token here} do not add the word 'Bearer' before it."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();


builder.Services.AddAutoMapper(typeof(Program));

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();



// Add FluentValidation to MVC
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// -----------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// new middleware 
app.Run();



// GET - POST - PUT - DELETE
// DTO

// CRUD product
// Response
// CREATE - Repository [ string ] - Service [ string ] - Controller [ ok string ]
// Update - //         [ Product ] -  //    [ ProductResponsedto ] - controller [ ProductResponsedto ]


// GET All - Repository [ List<products> ] - service [ List<ProductDTO> ] - controller [ List<ProductDTO> ]
// GET By Id //         [ product ]  - service [ productDTO ] - Controller [ productDTO ]

// DELETE - Repository [ string ] - service [ string ] - controller  [ string ]


// FluentValidation - Package : Request xxxxxxx
// Automapper - Object - DTO [5]   
//              Product
//              
// Generic Repository : CRUD [once]
// User - product - brand - category - Reviews 


// Middleware Vs Filters 
// Logging - Exceptions 

// Authentication - Authorization 

