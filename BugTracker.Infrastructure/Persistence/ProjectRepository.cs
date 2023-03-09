using BugTracker.Application.Common.Interfaces.Persistence;
using BugTracker.Domain.ProjectAggregate;

namespace BugTracker.Infrastructure.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private static readonly List<Project> _projects = new();
        public void Add(Project project)
        {
            _projects.Add(project);
        }
    }
}
