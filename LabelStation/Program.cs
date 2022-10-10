using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LabelStation.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BULabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BULabelContext") ?? throw new InvalidOperationException("Connection string 'BULabelContext' not found.")));
builder.Services.AddDbContext<ReprintContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReprintContext") ?? throw new InvalidOperationException("Connection string 'ReprintContext' not found.")));
builder.Services.AddDbContext<JlabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JlabelContext") ?? throw new InvalidOperationException("Connection string 'JlabelContext' not found.")));
builder.Services.AddDbContext<RWlabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RWlabelContext") ?? throw new InvalidOperationException("Connection string 'RWlabelContext' not found.")));
builder.Services.AddDbContext<WlabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WlabelContext") ?? throw new InvalidOperationException("Connection string 'WlabelContext' not found.")));
builder.Services.AddDbContext<PlabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PlabelContext") ?? throw new InvalidOperationException("Connection string 'PlabelContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
