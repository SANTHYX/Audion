namespace Application.Commons.Mappers
{
    public interface IMapper<T, S>
    {
        T MapTo(S source);
    }
}
