namespace BugTracker.Contracts.Projects
{
    public record ProjectResponse(
        string Id,
        string Name,
        string Description,
        string ReporterId,
        List<string> TaskIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}
