using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.Repository;
using WebApplicationAPI.Repository.Category;
using WebApplicationAPI.Repository.Product;
using WebApplicationAPI.Service.Category;
using WebApplicationAPI.Service.Product;
using WebApplicationAPI.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IProductService, ProductService>();

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

