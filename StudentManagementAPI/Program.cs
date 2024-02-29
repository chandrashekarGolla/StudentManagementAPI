using Microsoft.Data.SqlClient;
using SQLRepository;
//using MongodbRepository;
using StudentService;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudent, StudentServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding configuartion of sql connector json file
var configuration=new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("sqlconnection");

builder.Services.AddScoped<IDbConnection>(providee =>
{
    var connection = new SqlConnection(connectionString);
    return connection;
});
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
