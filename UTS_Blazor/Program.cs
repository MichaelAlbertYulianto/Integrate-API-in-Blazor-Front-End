using UTS_Blazor.Components;
using UTS_Blazor.Services;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net") });

// Add your custom services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
