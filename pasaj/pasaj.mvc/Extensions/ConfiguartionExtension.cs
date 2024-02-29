namespace pasaj.mvc.Extensions
{
    public static class ConfiguartionExtension
    {
        public static string? GetRabbitMQ(this ConfigurationManager configurationManager, string node)
        {

            return configurationManager.GetSection("RabbitMQ")[node];

        }
    }
}
