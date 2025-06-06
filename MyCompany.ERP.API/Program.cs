using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.ERP.API.Services.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MyCompany ERP API", Version = "v1" });
});

// Register custom services
builder.Services.AddScoped<IAuthService, AuthService>();

// Add CORS - configurare pentru WinForms și alte clienti
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

// Configure host options pentru shutdown graceful
builder.Services.Configure<HostOptions>(opts =>
{
    opts.ShutdownTimeout = TimeSpan.FromSeconds(5);
});

// Configure Kestrel pentru a asculta pe porturile dorite
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5002); // HTTP
    serverOptions.ListenLocalhost(7002, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCompany ERP API V1");
        c.RoutePrefix = "swagger"; // Swagger la /swagger
    });

    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Health check endpoint
app.MapGet("/health", () => new { Status = "Healthy", Timestamp = DateTime.UtcNow });

// Root endpoint
app.MapGet("/", () => "MyCompany ERP API is running!");

// Logging pentru startup
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Starting MyCompany ERP API...");
logger.LogInformation("API will be available at:");
logger.LogInformation("- HTTPS: https://localhost:7002");
logger.LogInformation("- HTTP: http://localhost:5002");
logger.LogInformation("- Swagger: https://localhost:7002/swagger");

// Pentru debugging în Visual Studio - se oprește automat când debugging se oprește
if (app.Environment.IsDevelopment())
{
    await app.RunAsync();
}
else
{
    await app.RunAsync();
}
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using MyCompany.Common.SharedInterfaces.Login;
//using MyCompany.ERP.API.Services.Login;
//using System.Diagnostics;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "MyCompany ERP API", Version = "v1" });
//});

//// Register custom services
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Add CORS - configurare pentru WinForms și alte clienti
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

//// Add logging
//builder.Services.AddLogging(logging =>
//{
//    logging.AddConsole();
//    logging.AddDebug();
//});

//// Configure host options pentru shutdown graceful
//builder.Services.Configure<HostOptions>(opts =>
//{
//    opts.ShutdownTimeout = TimeSpan.FromSeconds(5);
//});

//// Configure Kestrel pentru a asculta pe porturile dorite
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenLocalhost(5002); // HTTP
//    serverOptions.ListenLocalhost(7002, listenOptions =>
//    {
//        listenOptions.UseHttps(); // HTTPS
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCompany ERP API V1");
//        c.RoutePrefix = "swagger"; // Swagger la /swagger
//    });

//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

//// Middleware pipeline
//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseRouting();
//app.UseAuthorization();

//// Map controllers
//app.MapControllers();

//// Health check endpoint
//app.MapGet("/health", () => new { Status = "Healthy", Timestamp = DateTime.UtcNow });

//// Root endpoint
//app.MapGet("/", () => "MyCompany ERP API is running!");

//// Logging pentru startup
//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation("Starting MyCompany ERP API...");
//logger.LogInformation("API will be available at:");
//logger.LogInformation("- HTTPS: https://localhost:7002");
//logger.LogInformation("- HTTP: http://localhost:5002");
//logger.LogInformation("- Swagger: https://localhost:7002/swagger");

//// Configurare pentru graceful shutdown
//var cts = new CancellationTokenSource();

//// Handle Ctrl+C și alte semnale de oprire
//Console.CancelKeyPress += (sender, e) =>
//{
//    logger.LogInformation("Application shutdown requested...");
//    e.Cancel = true;
//    cts.Cancel();
//};

//// Handle SIGTERM (pentru debugging în VS)
//AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
//{
//    logger.LogInformation("Application is shutting down...");
//    cts.Cancel();
//};

//// Detectează când debugger-ul se detașează (doar pentru debugging)
//if (Debugger.IsAttached)
//{
//    Task.Run(async () =>
//    {
//        while (Debugger.IsAttached && !cts.Token.IsCancellationRequested)
//        {
//            await Task.Delay(1000, cts.Token);
//        }

//        if (!Debugger.IsAttached)
//        {
//            logger.LogInformation("Debugger detached, shutting down application...");
//            cts.Cancel();
//        }
//    }, cts.Token);
//}

//try
//{
//    logger.LogInformation("Application started successfully");
//    await app.RunAsync(cts.Token);
//}
//catch (OperationCanceledException)
//{
//    logger.LogInformation("Application shutdown completed");
//}
//catch (Exception ex)
//{
//    logger.LogError(ex, "An error occurred while running the application");
//    throw;
//}
//finally
//{
//    logger.LogInformation("Application cleanup completed");
//    await app.DisposeAsync();
//}

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using MyCompany.Common.SharedInterfaces.Login;
//using MyCompany.ERP.API.Services.Login;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "MyCompany ERP API", Version = "v1" });
//});

//// Register custom services
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Add CORS - configurare pentru WinForms și alte clienti
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

//// Add logging
//builder.Services.AddLogging(logging =>
//{
//    logging.AddConsole();
//    logging.AddDebug();
//});

//// Configure Kestrel pentru a asculta pe porturile dorite
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenLocalhost(5002); // HTTP
//    serverOptions.ListenLocalhost(7002, listenOptions =>
//    {
//        listenOptions.UseHttps(); // HTTPS
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCompany ERP API V1");
//        c.RoutePrefix = "swagger"; // Swagger la /swagger
//    });

//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

//// Middleware pipeline
//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseRouting();
//app.UseAuthorization();

//// Map controllers
//app.MapControllers();

//// Health check endpoint
//app.MapGet("/health", () => new { Status = "Healthy", Timestamp = DateTime.UtcNow });

//// Root endpoint
//app.MapGet("/", () => "MyCompany ERP API is running!");

//// Logging pentru startup
//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation("Starting MyCompany ERP API...");
//logger.LogInformation("API will be available at:");
//logger.LogInformation("- HTTPS: https://localhost:7002");
//logger.LogInformation("- HTTP: http://localhost:5002");
//logger.LogInformation("- Swagger: https://localhost:7002/swagger");

//// Configurare pentru graceful shutdown
//var cts = new CancellationTokenSource();

//// Handle Ctrl+C și alte semnale de oprire
//Console.CancelKeyPress += (sender, e) =>
//{
//    logger.LogInformation("Application shutdown requested...");
//    e.Cancel = true;
//    cts.Cancel();
//};

//// Handle SIGTERM (pentru debugging în VS)
//AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
//{
//    logger.LogInformation("Application is shutting down...");
//    cts.Cancel();
//};

//try
//{
//    logger.LogInformation("Application started successfully");
//    await app.RunAsync(cts.Token);
//}
//catch (OperationCanceledException)
//{
//    logger.LogInformation("Application shutdown completed");
//}
//catch (Exception ex)
//{
//    logger.LogError(ex, "An error occurred while running the application");
//    throw;
//}
//finally
//{
//    logger.LogInformation("Application cleanup completed");
//    await app.DisposeAsync();
//}

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using MyCompany.Common.SharedInterfaces.Login;
//using MyCompany.ERP.API.Services.Login;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "MyCompany ERP API", Version = "v1" });
//});

//// Register custom services
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Add CORS - configurare pentru WinForms și alte clienti
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

//// Add logging
//builder.Services.AddLogging(logging =>
//{
//    logging.AddConsole();
//    logging.AddDebug();
//});

//// Configure Kestrel pentru a asculta pe porturile dorite
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenLocalhost(5002); // HTTP
//    serverOptions.ListenLocalhost(7002, listenOptions =>
//    {
//        listenOptions.UseHttps(); // HTTPS
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCompany ERP API V1");
//        c.RoutePrefix = "swagger"; // Swagger la /swagger
//    });

//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

//// Middleware pipeline
//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseRouting();
//app.UseAuthorization();

//// Map controllers
//app.MapControllers();

//// Health check endpoint
//app.MapGet("/health", () => new { Status = "Healthy", Timestamp = DateTime.UtcNow });

//// Root endpoint
//app.MapGet("/", () => "MyCompany ERP API is running!");

//// Logging pentru startup
//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation("Starting MyCompany ERP API...");
//logger.LogInformation("API will be available at:");
//logger.LogInformation("- HTTPS: https://localhost:7002");
//logger.LogInformation("- HTTP: http://localhost:5002");
//logger.LogInformation("- Swagger: https://localhost:7002/swagger");

//try
//{
//    await app.RunAsync();
//}
//catch (Exception ex)
//{
//    logger.LogError(ex, "An error occurred while starting the application");
//    throw;
//}