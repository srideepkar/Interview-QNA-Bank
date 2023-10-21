using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InterviewFAQ.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InterviewFAQContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewFAQContext") ?? throw new InvalidOperationException("Connection string 'InterviewFAQContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corepolicy", build =>
    build.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
));

var app = builder.Build();

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseHttpsRedirection();

app.UseCors("corepolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
