using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myAppCors");


app.MapGet("/username", () =>
{
    var con = app.Configuration.GetConnectionString("DefaultConnection");
    string resss = string.Empty; 
    using (SqlConnection sqlConnection = new SqlConnection(con))
    {
        sqlConnection.Open();
        using (SqlCommand cmd = new SqlCommand("select * from users", sqlConnection))
        {
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                resss = result.GetValue(2).ToString();
            }

        }
    }
    return resss;
})
.WithName("GetUserName")
.WithOpenApi();



app.Run();
