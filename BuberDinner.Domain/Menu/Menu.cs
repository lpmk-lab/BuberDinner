
using SmartRMS.Domain.Menu.Entities;
using SmartRMS.Domain.Menu.ValueObjects;
using SmartRMS.Domain.Models;

namespace SmartRMS.Domain.Menu;
    public sealed class Menu: AggregateRoot<MenuId>
    {


    private readonly List<MenuSection> _sections = new();

    public Menu(MenuId tid) : base(tid)
    {
    }

    public string Name { get; set; }
    public string Description { get; set; } 

    public float AverageRating { get; set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
}

