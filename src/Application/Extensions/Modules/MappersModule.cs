using Application.Commons.Types;
using Scrutor;

namespace Application.Extensions.Modules
{
    public static class MappersModule
    {
        public static IImplementationTypeSelector AddMappers(this IImplementationTypeSelector selector)
            => selector.AddClasses(x => x.AssignableTo(typeof(IMapper<,>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
    }
}
