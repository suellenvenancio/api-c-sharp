using LibraryApplication.Middleware;
using LibraryInfraIOK;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer(); 
 builder.Services.AddSwaggerGen(options =>
  { options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
   {
     Type = SecuritySchemeType.Http,
      Scheme = "bearer",
       BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
   });
     options.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
          {
               new OpenApiSecurityScheme
               {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
               },
               new string[] { }
          }
     });
    });
 
 var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
