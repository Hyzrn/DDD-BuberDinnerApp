using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; set; }
    
    public string Description { get; set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    
    public MenuSection(MenuSectionId id,
        string name,
        string description,
        List<MenuItem> menuItems)
        : base(id)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }
    
    public static MenuSection Create(string name,
        string description,
        List<MenuItem> menuItems)
    {
        return new(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}