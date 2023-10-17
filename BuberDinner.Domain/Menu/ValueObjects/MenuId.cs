

using SmartRMS.Domain.Models;

namespace SmartRMS.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value {  get;  }

    private MenuId(Guid value)
    {
        Value = value;

    }

    public static MenuId CreateUnique()
    {
       return new(Guid.NewGuid()); 
    }

    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}

