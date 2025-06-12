using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MindLedger.AppLogic.ViewModels;
using MindLedger.Domain.Interfaces;
using MindLedger.Infrastructure.Persistence;
using MindLedger.Infrastructure.Repositories;
using System.Windows;

namespace MindLedger.App
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; } = null!;

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<MindLedgerDbContext>(options =>
                        options.UseSqlite("Data Source=notes.db"));

                    services.AddScoped<INoteRepository, SqliteNoteRepository>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
