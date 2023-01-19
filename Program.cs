using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Suciu_Denisa_Camelia.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Suciu_Denisa_CameliaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suciu_Denisa_CameliaContext") ?? throw new InvalidOperationException("Connection string 'Suciu_Denisa_CameliaContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
