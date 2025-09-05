using TeamBicep.WebApp.Services;
using TeamBicep.WebApp.Services.Interface;
using TeamBicep.WebApp.UI.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<IToDo, ToDoService>();

var apiBaseUrl =
    builder.Configuration["ApiBaseUrl"]
    ?? throw new InvalidOperationException("ApiBaseUrl configuration is missing.");

builder.Services.AddHttpClient<IToDo, ToDoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseCors(policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
