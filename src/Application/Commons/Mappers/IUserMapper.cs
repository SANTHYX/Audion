﻿using Application.Dto.User;
using Core.Domain;

namespace Application.Commons.Mappers
{
    public interface IUserMapper : IBaseMapper<GetUserDto, User>
    {
    }
}