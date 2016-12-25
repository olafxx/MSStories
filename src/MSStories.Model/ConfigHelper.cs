using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MSStories.Model
{
    public static class ConfigHelper
    {

        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();//add config file with connection string
            return config.GetConnectionString("DefaultConnection");
        }
    }
}
