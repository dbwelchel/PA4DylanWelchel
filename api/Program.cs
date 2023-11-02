using PA4DWelchel;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Cors;


Database db = new Database();
using var con = new MySqlConnection(db.cs);
con.Open();
string stm = "SELECT * from exercise ORDER BY date asc";
using var cmd = new MySqlCommand(stm, con);
using MySqlDataReader rdr = cmd.ExecuteReader();
while (rdr.Read()) 
{ 
	Console.WriteLine($"{rdr.GetString(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)}"); 
}

con.Close();


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenPolicy",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("OpenPolicy");
app.MapControllers();

app.Run();
    
Console.WriteLine("Hello, World!");

