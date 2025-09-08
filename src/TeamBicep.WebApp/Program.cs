using TeamBicep.WebApp.Services;
using TeamBicep.WebApp.Services.Interface;
using TeamBicep.WebApp.UI.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// !: Services
builder.Services.AddScoped<ITodosService, TodosApiService>();

builder.Services.AddCors();

if (builder.Environment.IsDevelopment())
{
    var localApiUrl =
        builder.Configuration["ApiBaseUrl"]
        ?? throw new InvalidOperationException("ApiBaseUrl configuration is missing.");
    builder.Services.AddHttpClient<ITodosService, TodosApiService>(client =>
        client.BaseAddress = new Uri(localApiUrl)
    );
}
else
{
    var prodApiUrl =
        builder.Configuration["BackendApi"]
        ?? Environment.GetEnvironmentVariable("BackendApi")
        ?? throw new InvalidOperationException("API URL configuration is missing.");

    builder.Services.AddHttpClient<ITodosService, TodosApiService>(client =>
        client.BaseAddress = new Uri(prodApiUrl)
    );
}

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
    policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();