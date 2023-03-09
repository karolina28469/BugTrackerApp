using BugTracker.Domain.Common.Models;
using BugTracker.Domain.ProjectAggregate.ValueObjects;
using BugTracker.Domain.ReporterAggregate.ValueObjects;
using BugTracker.Domain.TaskAggregate.ValueObjects;

namespace BugTracker.Domain.ProjectAggregate
{
    public sealed class Project : AggregateRoot<ProjectId>
    {
        private readonly List<TaskId> _taskIds = new();
        public string Name { get; }
        public string Description { get; }
        public ReporterId ReporterId { get; }
        public IReadOnlyList<TaskId> TaskIds => _taskIds;
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Project(
            ProjectId projectId,
            string name,
            string description,
            ReporterId reporterId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(projectId)
        {
            Name = name;
            Description = description;
            ReporterId = reporterId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Project Create(string name, string description, ReporterId reporterId)
        {
            return new(
                ProjectId.CreateUnique(),
                name,
                description,
                reporterId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
