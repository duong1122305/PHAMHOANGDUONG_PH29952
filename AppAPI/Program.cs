using AppAPI.Context;
using AppAPI.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("con"))
);

builder.Services.AddScoped<ISinhVienRepo, SinhVienRepo>();
builder.Services.AddScoped<IUploadRepo, UploadRepo>();

builder.Services.AddCors(option =>
    option.AddPolicy("cor", otp =>
    otp.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
));
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
