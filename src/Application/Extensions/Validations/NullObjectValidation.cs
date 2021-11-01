using Application.Exceptions;
using Core.Commons.Types;

namespace Application.Extensions.Validations
{
    public static class NullObjectValidation
    {
        public static T NotNull<T>(this T entity) where T : class, IEntity
        {
            if (entity is null)
            {
                throw new NotFoundException($"Object not found");
            }

            return entity;
        }
        
    }
}
