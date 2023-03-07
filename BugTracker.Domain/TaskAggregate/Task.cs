using BugTracker.Domain.Common.Models;
using BugTracker.Domain.ReporterAggregate.ValueObjects;
using BugTracker.Domain.TaskAggregate.ValueObjects;

namespace BugTracker.Domain.User
{
    public sealed class Task : AggregateRoot<TaskId>
    {
        public string Name { get; }
        public string Description { get; }
        public ReporterId ReporterId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Task(
            TaskId taskId, 
            string name, 
            string description, 
            ReporterId reporterId, 
            DateTime createdDateTime, 
            DateTime updatedDateTime)
            : base(taskId)
        {
            Name = name;
            Description = description;
            ReporterId = reporterId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;            
        }

        public static Task Create(string name, string description, ReporterId reporterId)
        {
            return new(
                TaskId.CreateUnique(),
                name,
                description,
                reporterId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
