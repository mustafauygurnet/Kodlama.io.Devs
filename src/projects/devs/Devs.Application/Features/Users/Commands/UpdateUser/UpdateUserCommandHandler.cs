using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password is not null)
        {
            User? getUser = await _userRepository.GetAsync(u => u.Id == request.Id);

            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            getUser.PasswordHash = passwordHash;
            getUser.PasswordSalt = passwordSalt;

            User updatedUserWithPassword = await _userRepository.UpdateAsync(getUser);
            UpdatedUserDto updatedUserDtoWithPassword = _mapper.Map<UpdatedUserDto>(updatedUserWithPassword);
            return updatedUserDtoWithPassword;
        }

        User mappedUser = _mapper.Map<User>(request);

        User updatedUser = await _userRepository.UpdateAsync(mappedUser);

        UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);

        return updatedUserDto;
    }
}