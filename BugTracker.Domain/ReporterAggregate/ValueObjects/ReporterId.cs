using BugTracker.Domain.Common.Models;

namespace BugTracker.Domain.ReporterAggregate.ValueObjects
{
    public sealed class ReporterId : ValueObject
    {
        public string reporterId { get; } //TODO

        public Guid Value { get; }

        private ReporterId(Guid value)
        {
            Value = value;
        }

        public ReporterId(string reporterId) //TODO
        {
            this.reporterId = reporterId;
        }

        public static ReporterId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ReporterId Create(string reporterId) //TODO
        {
            return new(reporterId);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
