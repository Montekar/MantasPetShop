using System;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Domain.IRepositories;
using Mantas.PetShop.Domain.Services;
using Mantas.PetShop.Infrastructure.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Mantas.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            serviceCollection.AddScoped<IMenu, MainMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainMenu = serviceProvider.GetRequiredService<IMenu>();
            
            mainMenu.Start();

        }
    }
}