

using SmartRMS.Domain.Menu.ValueObjects;
using SmartRMS.Domain.Models;

namespace SmartRMS.Domain.Menu.Entities;
    public sealed class MenuSection :Entity<MenuSectionID>
    {
    private readonly List<MenuItem> _items = new();
    public string Name { get; set; }
    public string Description { get; set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    private MenuSection(MenuSectionID menuSectionId, string name, string description) : base(menuSectionId)
    {

        Name = name;
        Description = description;
    }
    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionID.CreateUnique(), name, description);
    }
}

