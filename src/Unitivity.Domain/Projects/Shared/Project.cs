namespace Unitivity.Domain.Projects.Shared;
public sealed class Project
{
    public Guid Id {get; init; }

    public string Title {get; private set; }
}
