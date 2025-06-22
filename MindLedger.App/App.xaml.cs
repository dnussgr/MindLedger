using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MindLedger.AppLogic.ViewModels;
using MindLedger.Domain.Interfaces;
using MindLedger.Infrastructure.Persistence;
using MindLedger.Infrastructure.Repositories;
using System.IO;
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
                        options.UseSqlite("Data Source=" + Path.Combine(AppContext.BaseDirectory, "MindLedger.db")));

                    services.AddScoped<INoteRepository, SqliteNoteRepository>();
                    services.AddScoped<MainWindowViewModel>();
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<ITagRepository, SqliteTagRepository>();
                    services.AddScoped<ICampaignRepository, SqliteCampaignRepository>();
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
