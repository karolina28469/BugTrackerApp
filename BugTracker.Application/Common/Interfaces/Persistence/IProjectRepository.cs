using BugTracker.Domain.ProjectAggregate;

namespace BugTracker.Application.Common.Interfaces.Persistence
{
    public interface IProjectRepository
    {
        void Add(Project project);
    }
}
