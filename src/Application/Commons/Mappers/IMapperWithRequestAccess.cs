using Microsoft.AspNetCore.Http;

namespace Application.Commons.Mappers
{
    public interface IMapperWithRequestAccess<T, S>
    {
        T MapTo(S source, HttpContext context);
    }
}
