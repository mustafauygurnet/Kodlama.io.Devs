using Core.Persistence.Repositories;

namespace Devs.Domain.Entities;

public class Language : Entity
{
    public string Name { get; set; }

    public Language()
    {
        
    }

    public Language(int id,string name) : this()
    {
        Id = id;
        Name = name;
    }
}