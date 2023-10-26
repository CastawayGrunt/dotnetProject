using DotnetProjectApi.API.Data;
using MediatR;

// using DotnetProjectApi.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(type =>
            {
                var tempName = type.FullName!.Replace("+", "");
                return string.Join("_", tempName.Split(".").TakeLast(2));
            }); ;
    });

builder.Services.AddDbContext<DotnetProjectDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration["ConnectionStrings:DotnetProjectDBConnectionString"]));

// builder.Services.AddScoped<IBooksRepository, BooksRepository>();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();

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
