using BlazorWebApp.Client.Components;
using BlazorWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    // swith below lines to interactive or inter active assembly
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    
    // add below lines to use anything from DisplayTimeComponent in client project
    .AddAdditionalAssemblies(typeof(DisplayTimeComponent).Assembly);
app.Run();
