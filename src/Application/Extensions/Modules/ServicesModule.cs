using Application.Commons.Types;
using Scrutor;

namespace Application.Extensions.Modules
{
    public static class ServicesModule
    {
        public static IImplementationTypeSelector AddServices(this IImplementationTypeSelector selector)
            => selector.AddClasses(x => x.AssignableTo<IService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
    }
}
