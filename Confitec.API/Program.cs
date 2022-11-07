using Confitec.API.Context;
using Confitec.API.Domain.Contracts;
using Confitec.API.Domain.Handlers;
using Confitec.API.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers().AddFluentValidation(c =>
c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder
            .WithOrigins("http://localhost:4200")
            .WithMethods("GET", "POST", "DELETE", "PUT")
            .WithHeaders() // <--- list the allowed headers here
            .AllowCredentials()
            .WithExposedHeaders("X-Pagination");
        });

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddTransient<UserHandler>();
builder.Services.AddTransient<IUserHandler, UserHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllOrigins");
app.UseEndpoints(endpoints =>{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
