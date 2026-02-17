using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App, MainWindow, MainPage>()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                   });

            builder.Services.AddSingleton(SemanticScreenReader.Default);
            builder.Services.AddSingleton<MainViewModel>();
            //builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if WINDOWS
            // Launch the app window maximized on Windows
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(app =>
                {
                    app.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = false;

                        if (window.AppWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter presenter)
                        {
                            //presenter.SetBorderAndTitleBar(false, false);
                            presenter.Maximize();
                        }
                    });
                });
            });
#endif

            return builder.Build();
        }
    }
}
