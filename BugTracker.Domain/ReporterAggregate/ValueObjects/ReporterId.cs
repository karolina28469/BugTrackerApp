using BugTracker.Domain.Common.Models;

namespace BugTracker.Domain.ReporterAggregate.ValueObjects
{
    public sealed class ReporterId : ValueObject
    {
        public Guid Value { get; }

        private ReporterId(Guid value)
        {
            Value = value;
        }

        public static ReporterId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
