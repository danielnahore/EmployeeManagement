using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Web.Models;
using Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebContextConnection") ?? throw new InvalidOperationException("Connection string 'WebContextConnection' not found.");

builder.Services.AddDbContext<WebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebContext>();

// Add services to the container.
builder.Services.AddAuthentication("Identity.Application").AddCookie();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddHttpClient<IEmloyeeService, EmployeeSevice>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7777/");
});
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7777/");
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
