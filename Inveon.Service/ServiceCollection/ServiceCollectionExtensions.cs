using Inveon.Data.Entity;
using Inveon.Data.Repository;
using Inveon.Service.Interfaces;
using Inveon.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Service.ServiceCollection
{
    public class ServiceCollectionExtensions
    {
        
        public static void AddCommonInfrastructure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository<Product>, Repository<Product>>();

            serviceCollection.AddTransient<IProductService, ProductService>();
        }
    }
}
