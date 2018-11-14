namespace AspNet.configuration.inside.unitTest
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class ConfigurationShould
    {
        [SetUp]
        public void Init()
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;
            OutputPath = $"{testDirectory}\\Configuration";
            ConfigurationRoot = ConfigurationHelperForTesting.GetApplicationConfigurationRoot(OutputPath);
        }

        [Test]
        public void Can_get_read_projection_version_value()
        {
            Check.That(ConfigurationRoot["ProjectionVersionFromConfig"]).IsEqualTo("v1");
        }

        [Test]
        public void Can_get_read_projection_version_value_from_strongly_typed_CaraibesConfig()
        {
            var readProjector = ConfigurationHelperForTesting.GetApplicationConfiguration(OutputPath);
            Check.That(readProjector.ReadProjector.ProjectionVersion).IsEqualTo("v2");
        }

        [Test]
        public void Can_get_config_from_options()
        {
            var services = new ServiceCollection();

            // IOption configuration injection
            services.AddOptions();

            var caraibesConfigs = new CaraibesConfigs();
            var configurationSection = ConfigurationRoot.GetSection("Weblog");

            services.Configure<CaraibesConfigs>(caConfigs => { configurationSection.Bind(caraibesConfigs); });

            // TODO: then what? What is the benefit of using ServiceCollection
        }

        protected internal IConfigurationRoot ConfigurationRoot;

        protected internal string OutputPath;
    }
}