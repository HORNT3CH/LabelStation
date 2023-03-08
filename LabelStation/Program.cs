using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LabelStation.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SkuCardsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SkuCardsContext") ?? throw new InvalidOperationException("Connection string 'SkuCardsContext' not found.")));
builder.Services.AddDbContext<FlowerPotsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlowerPotsContext") ?? throw new InvalidOperationException("Connection string 'FlowerPotsContext' not found.")));
builder.Services.AddDbContext<RailCarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RailCarContext") ?? throw new InvalidOperationException("Connection string 'RailCarContext' not found.")));
builder.Services.AddDbContext<KanbanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KanbanContext") ?? throw new InvalidOperationException("Connection string 'KanbanContext' not found.")));
builder.Services.AddDbContext<PWPLabelsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PWPLabelsContext") ?? throw new InvalidOperationException("Connection string 'PWPLabelsContext' not found.")));
builder.Services.AddDbContext<BULabelsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BULabelsContext") ?? throw new InvalidOperationException("Connection string 'BULabelsContext' not found.")));
builder.Services.AddDbContext<AssociatesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssociatesContext") ?? throw new InvalidOperationException("Connection string 'AssociatesContext' not found.")));
builder.Services.AddDbContext<ItemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ItemContext") ?? throw new InvalidOperationException("Connection string 'ItemContext' not found.")));
builder.Services.AddDbContext<HLabelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HLabelContext") ?? throw new InvalidOperationException("Connection string 'HLabelContext' not found.")));
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
builder.Services.AddCloudscribePagination();

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
