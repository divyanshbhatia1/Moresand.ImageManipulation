using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace Moresand.ImageManipulation.Api
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Controllers and Modules
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddControllersCustom(this IServiceCollection services, ConfigurationManager configuration)
        {
            var mvcBuilder = services.AddControllers();
            
            // Load Module Assemblies
            var modules = LoadModules(configuration);
            
            // Remove all Application Parts
            mvcBuilder.PartManager.ApplicationParts.Clear();

            foreach (var module in modules)
            {
                AddApplicationPart(mvcBuilder, module);
            }
        }

        private static IEnumerable<Assembly> LoadModules(ConfigurationManager configuration)
        {
            var modules = configuration.GetSection("Modules").Get<string[]>();

            if (modules == null) yield break;

            foreach (var module in modules)
            {
                yield return Assembly.Load(new AssemblyName(module));
            }
        }

        private static void AddApplicationPart(IMvcBuilder mvcBuilder, Assembly assembly)
        {
            var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);

            // Register Application Parts from Assembly
            foreach (var part in partFactory.GetApplicationParts(assembly))
            {
                mvcBuilder.PartManager.ApplicationParts.Add(part);
            }

            var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(assembly, throwOnError: false);

            // Register Application Parts for each Related Assembly
            foreach (var relatedAssembly in relatedAssemblies)
            {
                partFactory = ApplicationPartFactory.GetApplicationPartFactory(relatedAssembly);

                foreach (var part in partFactory.GetApplicationParts(relatedAssembly))
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }
            }
        }
    }
}
