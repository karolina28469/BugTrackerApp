using BugTracker.Domain.ProjectAggregate;
using ErrorOr;
using MediatR;

namespace BugTracker.Application.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(
        string ReporterId,
        string Name,
        string Description) : IRequest<ErrorOr<Project>>;
}
