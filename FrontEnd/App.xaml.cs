using FrontEnd.MVVM.Services;
using FrontEnd.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            base.OnStartup(e);
            var mainPage = ServiceProvider.GetRequiredService<MainWindow>();
            mainPage.Show();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Register ViewModels
            services.AddSingleton<MainViewModel>();

            //Register View
            services.AddSingleton<MainWindow>();

            //Register Service
            services.AddTransient<IMyService, FaizService>();
            
            

        }
        public App()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;


            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        
    }

}
