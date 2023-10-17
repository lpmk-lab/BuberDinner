

namespace SmartRMS.Domain.Models;

internal class AggregateRoot<Tid> : Entity<Tid>
where Tid : notnull
{
    public AggregateRoot(Tid tid) : base(tid)
    {
    }
}

