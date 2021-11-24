using Core.Commons.Types;
using Scrutor;

namespace Infrastructure.Extensions.Modules
{
    public static class RepositoriesModule
    {
        public static IImplementationTypeSelector AddRepositoriesModule(this IImplementationTypeSelector selector)
            => selector.AddClasses(x => x.AssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(x => x.AssignableTo<IInMemoryRepository>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
    }
}
