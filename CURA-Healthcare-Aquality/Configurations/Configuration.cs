namespace CURA_Healthcare_Aquality.Configurations
{
    public static class Configuration
    {
        public static string WebUrl => Environment.CurrentEnvironment.GetValue<string>(".webUrl");
    }
}
