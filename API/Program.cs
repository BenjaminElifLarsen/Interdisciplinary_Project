using API.Hubs;
using API.Middlewares;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DomainApiServices.Add(builder.Services, builder.Configuration.GetConnectionString("database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    DomainApiServices.Seed(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RoutingMiddleware>();

app.MapControllers();
app.MapHub<MessageHub>("/MessageHub");

app.Run();
