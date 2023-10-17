

using SmartRMS.Domain.Models;

namespace SmartRMS.Domain.Menu.ValueObjects;

public sealed class MenuSectionID : ValueObject
{
    public Guid Value {  get;  }

    private MenuSectionID(Guid value)
    {
        Value = value;

    }

    public static MenuSectionID CreateUnique()
    {
       return new(Guid.NewGuid()); 
    }

    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}

