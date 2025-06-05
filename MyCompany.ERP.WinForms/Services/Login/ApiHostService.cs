using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.ERP.API.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.ERP.WinForms.Services.Login;

public class ApiHostService : IDisposable
{
    private IHost _host;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public ApiHostService()
    {
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public async Task StartAsync()
    {
        try
        {
            var builder = WebApplication.CreateBuilder();

            // Configure services
            builder.Services.AddControllers();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowWinForms", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Configure to run without opening browser
            builder.WebHost.UseUrls("https://localhost:7001");

            var app = builder.Build();

            // Configure pipeline
            app.UseCors("AllowWinForms");
            app.UseRouting();
            app.MapControllers();

            _host = app;

            // Start the host in background
            await _host.StartAsync(_cancellationTokenSource.Token);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to start API: {ex.Message}", ex);
        }
    }

    public async Task StopAsync()
    {
        if (_host != null)
        {
            _cancellationTokenSource.Cancel();
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _host?.Dispose();
        _cancellationTokenSource?.Dispose();
    }
}
