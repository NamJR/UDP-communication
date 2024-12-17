using Microsoft.Extensions.DependencyInjection;
using UDP_data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UdpVideoServer>(provider =>
    new UdpVideoServer("127.0.0.1", 12345)); // Đặt IP và cổng nhận UDP
builder.Services.AddSingleton<VideoService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
