using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
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

builder.Services.AddMvc(a =>
{
    a.RespectBrowserAcceptHeader = true;
    a.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("myAppCors");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();









using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("API Base URL");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    var result = await client.DeleteAsync("/");

    var result1 = await client.GetAsync("/");

    var content = new StringContent(JsonConvert.SerializeObject("content"));

    var result2 = await client.PostAsync("/", content);

    bool output = false;
    if(result.IsSuccessStatusCode)
    {
        output = true;
    }
    else
    {
        output = false;
    }
}



List<Thread> threads = new List<Thread>();
for (int i = 0; i < 10; i++)
{
    int temp = i;
    Thread t = new Thread(() => Console.WriteLine(temp));
    t.Start();
    threads.Add(t);
}

foreach (Thread t in threads)
{
    t.Join(); // Used to wait till thread ends
}

//Note: this supports in dotnet 3.5 version

Task task = Task.Run(() => Console.WriteLine());

Task task1 = Task.Factory.StartNew(() => Console.WriteLine());

Task task2 = Task.Factory.StartNew(() => Console.WriteLine());

Task.WaitAll(task,task1,task2);




var conn1 = app.Configuration.GetConnectionString("DefaultConnection");
//OR
var conn2 = app.Configuration["ConnectionStrings:DefaultConnection"];

using(SqlConnection scon = new SqlConnection(conn1))
{
    scon.Open();
    using(SqlCommand cmd = scon.CreateCommand())
    {
        var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Console.WriteLine(rdr.GetString(0));
        }
    }
    scon.Close();
}

//Note: This will work without docker only