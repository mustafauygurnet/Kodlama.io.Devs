using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserForRegisterDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserForRegisterDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreatedUserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        User createdUser = await _userRepository.AddAsync(user);
        

        CreatedUserForRegisterDto createdUserForRegisterDto = _mapper.Map<CreatedUserForRegisterDto>(createdUser);

        return createdUserForRegisterDto;
    }
}