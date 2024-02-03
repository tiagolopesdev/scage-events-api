using Microsoft.OpenApi.Models;
using SCAGEEvents.Application.IServices;
using SCAGEEvents.Application.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add services to the container.
builder.Services.AddScoped<IYoutubeService, YoutubeServiceChannel>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "events API",
        Description = "Api builded using DDD pattern",
        Contact = new OpenApiContact
        {
            Name = "Tiago Lopes",
            Email = "saxtiago14@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/tiagolopesdev"),
        }
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(opt =>
{
    opt.RoutePrefix = string.Empty;
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();       
});

app.UseCors();

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
