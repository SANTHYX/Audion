namespace Application.Commons.Types
{
    public interface IMapper<TOutput, TInput>
    {
        TOutput MapTo<TOut>(TInput source) where TOut : TOutput;
    }
}
