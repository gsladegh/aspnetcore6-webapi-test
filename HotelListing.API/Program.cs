using HotelListing.API.Configurations;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. <-- SERVICES / anything that needs to be injected
// inversion of control - dependency injection stuff

var connectionString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");
builder.Services.AddDbContext<HotelListingDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

// IHostBuilder
// lc = logger configuration
// ctx - builder context (HostBuilderContext)
// ctx.Configuration references the settings files, like appsettings.json
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// add the Auto Mapper for injuection
builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build(); // by the time it hits this line it should have everything it needs

// Configure the HTTP request pipeline. <-- MIDDLEWARE
// affects the request pipeline
// if in prod, you may not want swagger
// this is the pipeline of do this, do this, do this, then run
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
