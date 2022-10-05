using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using Devs.Application.Services.Repositories;
using Microsoft.AspNetCore.Http;

namespace Devs.Application.Features.Developers.Rules;

public class DeveloperBusinessRules
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDeveloperRepository _developerRepository;

    public DeveloperBusinessRules(IHttpContextAccessor httpContextAccessor, IDeveloperRepository developerRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _developerRepository = developerRepository;
    }

    public async Task<int> FindUserId()
    {
        int userId = _httpContextAccessor.HttpContext.User.GetUserId();

        if (userId == 0)
            throw new BusinessException("Please Login");

        return userId;
    }

    public async Task GithubAddressLimitControl(int userId)
    {
        var result = await _developerRepository.GetListAsync(u=>u.UserId == userId);
        if (result.Items.Count > 1)
        {
            throw new BusinessException("please add one github account ");
        }
    }
}