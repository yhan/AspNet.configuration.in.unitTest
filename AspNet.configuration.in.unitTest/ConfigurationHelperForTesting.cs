namespace AspNet.configuration.inside.unitTest
{
    using Microsoft.Extensions.Configuration;

    public class ConfigurationHelperForTesting
    {
        public static IConfigurationRoot GetApplicationConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder().SetBasePath(outputPath).AddJsonFile("appsettings.Tests.json", true).AddEnvironmentVariables().Build();
        }

        public static CaraibesConfigs GetApplicationConfiguration(string outputPath)
        {
            var configuration = new CaraibesConfigs();

            var iConfig = GetApplicationConfigurationRoot(outputPath);

            iConfig

                // .GetSection("ReadProjector")
                .Bind(configuration);

            return configuration;
        }
    }

    public class ReadProjector
    {
        public string ProjectionVersion { get; set; }
    }

    public class CaraibesConfigs
    {
        public ReadProjector ReadProjector { get; set; }
    }
}