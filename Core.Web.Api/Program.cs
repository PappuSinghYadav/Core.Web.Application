using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myAppCors");


app.MapGet("/username", () =>
{
    //Note: This will work without docker only
    var con = app.Configuration.GetConnectionString("DefaultConnection");
    //var conn2 = app.Configuration["ConnectionStrings:DefaultConnection"];
    string result = string.Empty; 
    using (SqlConnection sqlConnection = new SqlConnection(con))
    {
        sqlConnection.Open();
        using (SqlCommand cmd = new SqlCommand("select * from users", sqlConnection))
        {
            var queryData = cmd.ExecuteReader();
            while (queryData.Read())
            {
                result = queryData.GetValue(2).ToString();
            }

        }
    }
    return result;
})
.WithName("GetUserName")
.WithOpenApi();

app.Run();