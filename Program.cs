using CustomerService.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using demo_odata.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddOData(options =>
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<Book>("Books");
        odataBuilder.EntitySet<Address>("Addresses");
        odataBuilder.EntitySet<Press>("Presses");

        options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
            .AddRouteComponents("odata", odataBuilder.GetEdmModel());
    });

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
