using System;
using System.Reflection;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using mvc3spike.Core.Extensions;

namespace mvc3spike.Core.IoC
{
    public static class WindsorExtensions
    {
        public static void Inject(this IWindsorContainer container, object target)
        {
            Inject(container.Kernel, target);
        }

        public static void Inject(this IKernel kernel, object target)
        {
            var type = target.GetType();

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanWrite || !kernel.HasComponent(property.PropertyType))
                {
                    continue;
                }
                
                var value = kernel.Resolve(property.PropertyType);

                try
                {
                    property.SetValue(target, value, null);
                }

                catch (Exception ex)
                {
                    var message = string.Format("Error setting property {0} on type {1}, See inner exception for more information.", property.Name, type.FullName);
                    throw new ComponentActivatorException(message, ex);
                }
            }
        }

        public static IWindsorContainer RegisterControllers(this IWindsorContainer container, params Type[] controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                if (type.IsController())
                {
                    container.RegisterController(type);
                }
            }

            return container;
        }

        public static void RegisterController(this IWindsorContainer container, Type type)
        {
            container.Register
            (
                Component.For(type)
                         .ImplementedBy(type)
                         .Named(type.Name.ToLowerInvariant())
                         .LifeStyle.Transient
            );
        }
    }
}