using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.ApiClient.Abstract;
using Taboo.ApiClient.Concrete;


namespace Taboo.ApiClient.ServiceConfiguration
{
    public class DependencyConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientService, HttpClientManager>();
            services.AddSingleton<ISerializerService, NewtonsoftJsonSerializerManager>();
            services.AddScoped<IApiService, ApiManager>();
            services.AddScoped<IHttpUtilService, HttpUtilManager>();
        }
    }
    
}

