using Serilog;
using Ubee.Data.Contexts;
using Ubee.Service.Mappers;
using Ubee.Web.Extensions;
using Ubee.Web.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomService();

// Database configuration
builder.Services.AddDbContext<AppDbContext>(option =>
				option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logger
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHanderMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
