using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace EF_WWT
{
    public interface IApiConfig
    {
        string EFWWTConnectionString { get; }
    }
    [ExcludeFromCodeCoverage]
    public class ApiConfig : IApiConfig
    {
        private readonly IConfiguration _configuration;

        public ApiConfig(string environment)
        {
            _configuration = GetConfiguration(environment);
        }

        private IConfigurationRoot GetConfiguration(string environment)
        {
            var basePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            if (environment.Equals("local", StringComparison.InvariantCultureIgnoreCase))
            {
                builder.AddJsonFile($"appsettings.{environment}.json", optional: true);
            }

            return builder.Build();
        }

        public string EFWWTConnectionString => _configuration.GetValue<string>("ConnectionStrings:EFWWTConnectionString");
    }
}
