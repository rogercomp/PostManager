using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PostManager.Application.Services;
using PostManager.Core.Repository;
using PostManager.Infrastructure.Persistence;
using PostManager.Infrastructure.Persistence.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<PostManagerDbContext>(options => options.UseInMemoryDatabase("PostManager"));

builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<IPostService, PostService>();  

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
