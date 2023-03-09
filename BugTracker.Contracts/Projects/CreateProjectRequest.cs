namespace BugTracker.Contracts.Projects
{
    public record CreateProjectRequest(
        string Name,
        string Description);
}
