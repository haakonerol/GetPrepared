using ProductAPI.Core;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



app.MapGet("/product", () =>
    {
        var products = new List<ProductEntity>
        {
            new ProductEntity { Id = 1, Name = "Apple", Price = "100" }
        };
        return products;
    })
    .WithName("GetProducts")
    .WithOpenApi();

app.Run();