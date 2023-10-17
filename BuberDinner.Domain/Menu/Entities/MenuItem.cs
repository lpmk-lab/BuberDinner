

using SmartRMS.Domain.Menu.ValueObjects;
using SmartRMS.Domain.Models;

namespace SmartRMS.Domain.Menu.Entities;
public sealed class MenuItem : Entity<MenuItemId>
{
   

    public string Name { get; set; }
    public string Description { get; set; }
    private MenuItem(MenuItemId menuItemId,string name,string description) : base(menuItemId)
    {

        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name,string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}

