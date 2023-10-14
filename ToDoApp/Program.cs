using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ToDoApp.Data;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories;
using ToDoApp.Data.Repositories.Contracts;
using ToDoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Make a connection string
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "ToDo.db"));
XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);

// Inject additional services
builder.Services.AddSingleton(XpoDefault.DataLayer);
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<Repository<ToDoItem>>();
builder.Services.AddScoped<Repository<Category>>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ToDoService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
