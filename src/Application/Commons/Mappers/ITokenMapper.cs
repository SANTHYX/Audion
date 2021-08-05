using Application.Dto.Identity;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface ITokenMapper : IBaseMapper<GetJwtTokenDto, Token>
    {
    }
}
