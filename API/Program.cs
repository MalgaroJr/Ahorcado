using Microsoft.Net.Http.Headers;
using Azure.Identity;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using API.Errors;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("SQLVaultUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:7025", "https://localhost:7025")
                              .AllowAnyMethod().WithHeaders(HeaderNames.ContentType);
                          });
    });
}
if(builder.Environment.IsProduction())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.WithOrigins("https://ahorcadoagiles.azurewebsites.net")
                              .AllowAnyMethod().WithHeaders(HeaderNames.ContentType);
                          });
    });
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
            context.Response.ContentType = "application/json";

            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                var ex = error.Error;

                await context.Response.WriteAsync(new ErrorDto()
                {
                    Code = 500,
                    Message = ex.Message // or your custom message
                                         // other custom data
                }.ToString(), Encoding.UTF8);
            }
        });
    });
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
