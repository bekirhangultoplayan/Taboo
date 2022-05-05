using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.Business.Abstract;
using Taboo.Business.Concrete;

namespace Taboo.Business.ServiceConfiguration
{
    public class DependencyConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        { 
            services.AddScoped<IWordService, WordManager>();
            services.AddScoped<IGameService, GameManager>();
        }
    }
}
