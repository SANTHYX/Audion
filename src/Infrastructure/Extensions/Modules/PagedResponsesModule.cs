using Core.Commons.Pagination;
using Scrutor;

namespace Infrastructure.Extensions.Modules
{
    public static class PagedResponsesModule
    {
        public static IImplementationTypeSelector AddPagedResponsesModule(this IImplementationTypeSelector selector)
            => selector.AddClasses(x => x.AssignableTo((typeof(IPagedResponse<>))))
                .AsImplementedInterfaces()
                .WithSingletonLifetime();        
    }
}
