using Hackathon_g12.Application.Infra.BlobAzure;
using Hackathon_g12.Application.Services;
using Hackathon_g12.Application.Services.Imagens;
using Hackathon_g12.Application.Services.Storage;
using Hackathon_g12.Application.Services.Videos;
using Hackathon_g12.Domain.Intefaces.Repositories;
using Hackathon_g12.Domain.Interfaces.Services;
using Hackathon_g12.Domain.Interfaces.Validation;
using Hackathon_g12.Domain.Services;
using Hackathon_g12.Domain.Services.Notificacoes;
using Hackathon_g12.Infra.Context;
using Hackathon_g12.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BdPosfiapContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<BdPosfiapContext>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IVideoApplicationService, VideoAplicationService>();
builder.Services.AddScoped<IValidador, Validador>();
builder.Services.AddScoped<IConteinerAzureConfigProvider, ConteinerAzureConfigProvider>();

builder.Services.Configure<ConteinerAzureConfig>(builder.Configuration.GetSection("ConteinerAzure"));

builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IImagemService, ImagemService>();


builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
	options.SuppressModelStateInvalidFilter = true;
}); ;
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
