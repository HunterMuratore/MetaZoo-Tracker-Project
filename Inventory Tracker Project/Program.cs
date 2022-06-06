using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args); //Create new web app

// Add services to the container.

builder.Services.AddControllersWithViews();

//Assigns the MongoDB keys from appsettings.json as strings
var mongoHost = builder.Configuration.GetValue<string>("MongoDB:Host");
var mongoPort = builder.Configuration.GetValue<string>("MongoDB:Port");
var mongoDatabaseName = builder.Configuration.GetValue<string>("MongoDB:DatabaseName");
/* Create a new instance of the MongoClient class and assign it to a variable to allow connection to the MongoClient Database.
Immediately connects to our server in appsettings.json using mongodb://*/
var mongoClient = new MongoClient($"mongodb://{mongoHost}:{mongoPort}"); // Find MongoClient class by control+click (sends you to MongoDB.Driver which was installed)
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
builder.Services.AddSingleton(mongoDatabase);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run(); //Run the app
