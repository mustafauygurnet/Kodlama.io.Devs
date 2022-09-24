using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Devs.Domain.Entities;

public class Developer : Entity
{
    public int UserId { get; set; }
    public string GithubAddress { get; set; }

    public virtual User User { get; set; }

    public Developer()
    {
        
    }

    public Developer(int id,int userId, string githubAddress):this()
    {
        Id = id;
        UserId = userId;
        GithubAddress = githubAddress;
    }
}