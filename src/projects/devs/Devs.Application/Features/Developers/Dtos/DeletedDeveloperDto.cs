namespace Devs.Application.Features.Developers.Dtos;

public class DeletedDeveloperDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string GithubAddress { get; set; }
}