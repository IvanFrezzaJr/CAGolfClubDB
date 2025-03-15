using CAGolfClubDB.Components;
using Microsoft.EntityFrameworkCore;
using CAGolfClubDB.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<CAGolfClubDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CAGolfClubDBContext") ?? throw new InvalidOperationException("Connection string 'CAGolfClubDBContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// dependencies injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<BookingRepository>();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
