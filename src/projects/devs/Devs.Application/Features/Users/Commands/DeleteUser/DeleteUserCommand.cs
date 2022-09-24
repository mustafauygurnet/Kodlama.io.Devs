using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeletedUserDto>
{
    public int Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,DeletedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User mappedUser = _mapper.Map<User>(request);


        User deletedUser = await _userRepository.DeleteAsync(mappedUser);

        DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);

        return deletedUserDto;
    }
}