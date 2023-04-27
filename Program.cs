using cookEaseBackEnd.Services;
using cookEaseBackEnd.Services.Context;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<IngredientService>();
builder.Services.AddScoped<NutritionService>();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MyCookEaseString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options => {
    options.AddPolicy("ArticlePolicy", 
    builder => {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// void connectionString(SqlServerDbContextOptionsBuilder obj)
// {
//     throw new NotImplementedException();
// }

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("ArticlePolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
