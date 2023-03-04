using DrCost;
using DrCost.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IAppSystemProperties>(new AppSystemProperties());
builder.Services.AddSingleton<IAppDbFactory, AppDbFactory>();
builder.Services.AddTransient(typeof(BudgetRepo));
builder.Services.AddTransient(typeof(AppSettingsRepo));
builder.Services.AddTransient(typeof(MonthBudgetInstanceRepo));
builder.Services.AddTransient(typeof(StuffRepo));
builder.Services.AddTransient(typeof(KindOfTagsRepo));

builder.Services.Configure<RouteOptions>(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;
	options.AppendTrailingSlash = true;
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
