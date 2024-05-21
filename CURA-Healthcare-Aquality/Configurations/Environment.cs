using System.Reflection;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace CURA_Healthcare_Aquality.Configurations
{
    internal class Environment
    {
        public static ISettingsFile CurrentEnvironment
        {
            get
            {
                var pathToConfigFile = $"Resources.configData.json";
                return new JsonSettingsFile(pathToConfigFile, Assembly.GetExecutingAssembly());
                //return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
            }
        }
    }
}
