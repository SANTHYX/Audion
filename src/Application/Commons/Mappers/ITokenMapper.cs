using Application.Dto.Identity;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface ITokenMapper : IMapper<GetJwtTokenDto, Token>
    {
    }
}
