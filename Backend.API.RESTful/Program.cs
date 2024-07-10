using Goodbyes.Backend.Services.DB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPeoplesModel, PeoplesModel>();
builder.Services.AddScoped<IServicesModel, ServicesModel>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSAnyPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("CORSAnyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
