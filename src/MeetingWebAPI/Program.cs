using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Meeting_DAL.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeetingDbContext") ?? throw new InvalidOperationException("Connection string 'EmployeeManagementApiContext' not found.")));

// Add services to the container.
builder.Services.AddDbContext<Meeting_DAL.Data.AppDbContext>();

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
