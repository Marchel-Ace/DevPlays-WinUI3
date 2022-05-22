using DevPlays_WinUI3.Activation;
using DevPlays_WinUI3.Contracts.Services;
using DevPlays_WinUI3.Core.Contracts.Services;
using DevPlays_WinUI3.Core.Services;
using DevPlays_WinUI3.Helpers;
using DevPlays_WinUI3.Services;
using DevPlays_WinUI3.ViewModels;
using DevPlays_WinUI3.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace DevPlays_WinUI3
{
    public partial class App : Application
    {
        // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Default Activation Handler
                services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                // Other Activation Handlers

                // Services
                services.AddTransient<INavigationViewService, NavigationViewService>();

                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<IPageService, PageService>();
                services.AddSingleton<INavigationService, NavigationService>();

                // Core Services
                services.AddSingleton<ISampleDataService, SampleDataService>();
                services.AddSingleton<IFileService, FileService>();

                // Views and ViewModels
                services.AddTransient<HashGeneratorDetailViewModel>();
                services.AddTransient<HashGeneratorDetailPage>();
                services.AddTransient<HashGeneratorViewModel>();
                services.AddTransient<HashGeneratorPage>();
                services.AddTransient<RegexTesterDetailViewModel>();
                services.AddTransient<RegexTesterDetailPage>();
                services.AddTransient<RegexTesterViewModel>();
                services.AddTransient<RegexTesterPage>();
                services.AddTransient<TextDiffDetailViewModel>();
                services.AddTransient<TextDiffDetailPage>();
                services.AddTransient<TextDiffViewModel>();
                services.AddTransient<TextDiffPage>();
                services.AddTransient<JWTDecoderDetailViewModel>();
                services.AddTransient<JWTDecoderDetailPage>();
                services.AddTransient<JWTDecoderViewModel>();
                services.AddTransient<JWTDecoderPage>();
                services.AddTransient<GZIPConverterDetailViewModel>();
                services.AddTransient<GZIPConverterDetailPage>();
                services.AddTransient<GZIPConverterViewModel>();
                services.AddTransient<GZIPConverterPage>();
                services.AddTransient<Base64ConverterDetailViewModel>();
                services.AddTransient<Base64ConverterDetailPage>();
                services.AddTransient<Base64ConverterViewModel>();
                services.AddTransient<Base64ConverterPage>();
                services.AddTransient<JSONFormatterDetailViewModel>();
                services.AddTransient<JSONFormatterDetailPage>();
                services.AddTransient<JSONFormatterViewModel>();
                services.AddTransient<JSONFormatterPage>();
                services.AddTransient<XMLFormatterDetailViewModel>();
                services.AddTransient<XMLFormatterDetailPage>();
                services.AddTransient<XMLFormatterViewModel>();
                services.AddTransient<XMLFormatterPage>();
                services.AddTransient<SQLFormatterDetailViewModel>();
                services.AddTransient<SQLFormatterDetailPage>();
                services.AddTransient<SQLFormatterViewModel>();
                services.AddTransient<SQLFormatterPage>();
                services.AddTransient<NumberBaseDetailViewModel>();
                services.AddTransient<NumberBaseDetailPage>();
                services.AddTransient<NumberBaseViewModel>();
                services.AddTransient<NumberBasePage>();
                services.AddTransient<MainViewModel>();
                services.AddTransient<MainPage>();
                services.AddTransient<ShellPage>();
                services.AddTransient<ShellViewModel>();

                // Configuration
            })
            .Build();

        public static T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public static UIElement appTitlebar = null;

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO: Log and handle exceptions as appropriate.
            // For more details, see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs.
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = App.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }
    }
}
