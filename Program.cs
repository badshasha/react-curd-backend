using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using it.data;
using it.Services.Repo;

var builder = WebApplication.CreateBuilder(args);

// cors policy other wise React not working 
builder.Services.AddCors(options => {
    options.AddPolicy("CORPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000","https://azurestaticapp.net");
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("defaultConnection")
));

builder.Services.AddTransient<BloggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
