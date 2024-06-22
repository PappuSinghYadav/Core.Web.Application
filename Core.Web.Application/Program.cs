using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

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

if (!app.Environment.IsDevelopment())
{
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



//Business class need to move out
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