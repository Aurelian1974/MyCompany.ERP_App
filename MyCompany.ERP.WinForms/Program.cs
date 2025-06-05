using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.ERP.WinForms.Forms.MainForm;
using MyCompany.ERP.WinForms.Services.Login;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCompany.ERP.WinForms;

internal static class Program
{
    [STAThread]
    static async Task Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Configurare Host și DI Container
        var host = CreateHostBuilder().Build();

        // Pornește host-ul în background
         host.StartAsync();

        try
        {
            // Obține service-ul principal din DI container
            var authService = host.Services.GetRequiredService<IAuthService>();

            // Pornește aplicația cu dependency injection
            Application.Run(new frmLogin(authService)); // Sau forma ta principală
            //using (var loginForm = new frmLogin(authService))
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        // Deschide MainForm dacă login-ul a avut succes
            //        Application.Run(new MainForm());
            //    }
            //}
        }
        finally
        {
            host.StopAsync().Wait();
            host.Dispose();
        }
    }

    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                      .AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                // Configurare HttpClient cu certificate SSL ignore pentru development
                services.AddHttpClient<IAuthApiClient, AuthApiClient>(client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    var handler = new HttpClientHandler();
                    // Ignore SSL certificate errors în development
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                    return handler;
                });

                // Înregistrare servicii
                services.AddScoped<IAuthService, WinFormsAuthService>();

                // Alte servicii...
            });
}


//// MyCompany.ERP.WinForms/Program.cs
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using MyCompany.Common.SharedInterfaces;
//using MyCompany.Common.SharedInterfaces.Login;
//using MyCompany.ERP.WinForms.Forms.MainForm;
//using MyCompany.ERP.WinForms.Services;
//using MyCompany.ERP.WinForms.Services.Login;

//namespace MyCompany.ERP.WinForms
//{
//    internal static class Program
//    {
//        private static ApiHostService _apiHost;

//        [STAThread]
//        static async Task Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

//            try
//            {
//                // Start API in background FIRST
//                _apiHost = new ApiHostService();
//                await _apiHost.StartAsync();

//                // Setup configuration
//                var configuration = new ConfigurationBuilder()
//                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                    .Build();

//                // Setup DI container
//                var services = new ServiceCollection();
//                ConfigureServices(services, configuration);

//                using var serviceProvider = services.BuildServiceProvider();

//                // Handle application exit - IMPORTANT: folosește AppDomain.ProcessExit
//                AppDomain.CurrentDomain.ProcessExit += async (s, e) => await CleanupAsync();
//                Application.ApplicationExit += async (s, e) => await CleanupAsync();

//                // Get login form and run
//                var loginForm = serviceProvider.GetRequiredService<frmLogin>();
//                Application.Run(loginForm);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Eroare la pornirea aplicației: {ex.Message}", "Eroare",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                await CleanupAsync();
//            }
//        }

//        private static async Task CleanupAsync()
//        {
//            if (_apiHost != null)
//            {
//                try
//                {
//                    await _apiHost.StopAsync();
//                    _apiHost.Dispose();
//                    _apiHost = null;
//                }
//                catch (Exception ex)
//                {
//                    System.Diagnostics.Debug.WriteLine($"Cleanup error: {ex.Message}");
//                }
//            }
//        }

//        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
//        {
//            // Register configuration
//            services.AddSingleton<IConfiguration>(configuration);

//            // Register HttpClient
//            services.AddHttpClient<IAuthApiClient, AuthApiClient>();

//            // Register services
//            services.AddScoped<IAuthApiClient, AuthApiClient>();
//            services.AddScoped<IAuthService, WinFormsAuthService>();

//            // Register forms
//            services.AddTransient<frmLogin>();
//            services.AddTransient<MainForm>();
//        }
//    }
//}

//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using MyCompany.Common.SharedInterfaces.Login;
//using MyCompany.ERP.WinForms.Forms.MainForm;
//using MyCompany.ERP.WinForms.Services.Login;

//namespace MyCompany.ERP.WinForms;

//internal static class Program
//{
//    private static ApiHostService _apiHost;

//    [STAThread]
//    static async Task Main()
//    {
//        Application.EnableVisualStyles();
//        Application.SetCompatibleTextRenderingDefault(false);

//        try
//        {
//            // Start API in background
//            _apiHost = new ApiHostService();
//            await _apiHost.StartAsync();

//            // Setup configuration
//            var configuration = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();

//            // Setup DI container
//            var services = new ServiceCollection();
//            ConfigureServices(services, configuration);

//            using var serviceProvider = services.BuildServiceProvider();

//            // Handle application exit
//            Application.ApplicationExit += Application_ApplicationExit;

//            // Get login form and run
//            var loginForm = serviceProvider.GetRequiredService<frmLogin>();
//            Application.Run(loginForm);
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show($"Eroare la pornirea aplicației: {ex.Message}", "Eroare",
//                MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//        finally
//        {
//            await CleanupAsync();
//        }
//    }

//    private static async void Application_ApplicationExit(object sender, EventArgs e)
//    {
//        await CleanupAsync();
//    }

//    private static async Task CleanupAsync()
//    {
//        if (_apiHost != null)
//        {
//            await _apiHost.StopAsync();
//            _apiHost.Dispose();
//        }
//    }

//    private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
//    {
//        // Register configuration
//        services.AddSingleton<IConfiguration>(configuration);

//        // Register HttpClient
//        services.AddHttpClient<IAuthApiClient, AuthApiClient>();

//        // Register services
//        services.AddScoped<IAuthApiClient, AuthApiClient>();
//        services.AddScoped<IAuthService, WinFormsAuthService>();

//        // Register forms
//        services.AddTransient<frmLogin>();
//        services.AddTransient<MainForm>();
//    }
//}