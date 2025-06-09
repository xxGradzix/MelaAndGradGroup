using System.Configuration;
using System.Data;
using System.Windows;
using Data.API.Entities;
using Data.dataContextImpl.database;
using Data.Factories;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Model;
using Presentation.Model.API;
using Presentation.View;
using Presentation.ViewModel;
using Microsoft.Extensions.Configuration;

namespace Presentation
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            
            base.OnStartup(e);

            var services = new ServiceCollection();
            
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IEventRepository, EventRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IEventService, EventService>();
            services.AddSingleton<IUserService, UserService>();
            
            services.AddSingleton<IEventFactory, EventFactory>();
            services.AddSingleton<IUserFactory, UserFactory>();
            
            services.AddSingleton<IModel, ModelData>();
            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton<MainWindow>();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));
            
            _serviceProvider = services.BuildServiceProvider();
            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
            }
            
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
