// MyCompany.ERP.WinForms/Program.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Common.SharedInterfaces;
using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.ERP.WinForms.Forms.MainForm;
using MyCompany.ERP.WinForms.Services;
using MyCompany.ERP.WinForms.Services.Login;

namespace MyCompany.ERP.WinForms
{
    internal static class Program
    {
        private static ApiHostService _apiHost;

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Start API in background FIRST
                _apiHost = new ApiHostService();
                await _apiHost.StartAsync();

                // Setup configuration
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Setup DI container
                var services = new ServiceCollection();
                ConfigureServices(services, configuration);

                using var serviceProvider = services.BuildServiceProvider();

                // Handle application exit - IMPORTANT: folosește AppDomain.ProcessExit
                AppDomain.CurrentDomain.ProcessExit += async (s, e) => await CleanupAsync();
                Application.ApplicationExit += async (s, e) => await CleanupAsync();

                // Get login form and run
                var loginForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la pornirea aplicației: {ex.Message}", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await CleanupAsync();
            }
        }

        private static async Task CleanupAsync()
        {
            if (_apiHost != null)
            {
                try
                {
                    await _apiHost.StopAsync();
                    _apiHost.Dispose();
                    _apiHost = null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Cleanup error: {ex.Message}");
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            // Register configuration
            services.AddSingleton<IConfiguration>(configuration);

            // Register HttpClient
            services.AddHttpClient<IAuthApiClient, AuthApiClient>();

            // Register services
            services.AddScoped<IAuthApiClient, AuthApiClient>();
            services.AddScoped<IAuthService, WinFormsAuthService>();

            // Register forms
            services.AddTransient<frmLogin>();
            services.AddTransient<MainForm>();
        }
    }
}

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