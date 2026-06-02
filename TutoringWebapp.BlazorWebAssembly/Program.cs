using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TutoringWebapp.BlazorWebAssembly;
using TutoringWebapp.BlazorWebAssembly.Services;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient for WebAPI
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7129") });

// Services
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

// Radzen
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
