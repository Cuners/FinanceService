using Finance.Application.DependencyInjection;
using Finance.Application.UseCases;
using Finance.Application.UseCases.Accounts.CreateAccount.Request;
using Finance.Infrastructure.DependencyInjection;
using Finance.Infrastructure.Persistence;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddScoped<IUnitOfWork>(provider => (IUnitOfWork)provider.GetRequiredService<BudgetDbContext>());
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:8080");
        });
}
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseAuthorization();
//app.MapGet("get", () =>
//{
//    return Results.Ok("ok");
//});
app.MapControllers();

app.Run();
