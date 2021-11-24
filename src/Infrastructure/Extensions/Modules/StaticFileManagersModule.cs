using Application.Commons.Toolkits.Files;
using Scrutor;

namespace Infrastructure.Extensions.Modules
{
    public static class StaticFileManagersModule
    {
        public static IImplementationTypeSelector AddStaticFileManagersModule(this IImplementationTypeSelector selector)
           => selector.AddClasses(y => y.AssignableTo(typeof(IStaticFileManager<>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
    }
}
