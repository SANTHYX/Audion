using Core.Types;

namespace Application.Commons.Mappers
{
    public interface IBaseMapper<T, S>
    {
        T MapTo(S source);
    }
}
