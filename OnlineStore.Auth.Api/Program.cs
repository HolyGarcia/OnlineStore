using OnlineStore.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// mis dependencias 

builder.Services.AddContextDependency(builder.Configuration.GetConnectionString("SalesContext"));
builder.Services.AddSecurityDependency();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();