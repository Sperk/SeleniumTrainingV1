using Microsoft.Extensions.Configuration;

namespace SeleniumTraining
{
    internal class ConfigurationProvider
    {
        private static ConfigurationManager configuration;
        public static ConfigurationManager Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration
                        .AddJsonFile($"settings.json", optional: true, false);
                }
                return configuration;
            }
        }
    }
}