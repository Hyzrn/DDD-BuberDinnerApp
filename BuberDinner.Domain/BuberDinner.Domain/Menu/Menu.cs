using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    
    private readonly List<DinnerId> _dinners = new();
    
    private readonly List<MenuReviewId> _reviews = new();
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public AverageRating AverageRating { get; set; }
    
    public HostId HostId { get; }
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviews.AsReadOnly();
    
    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections,
        DateTime createdDate,
        DateTime updatedDate)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        CreatedDateTime = createdDate;
        UpdatedDateTime = updatedDate;
        AverageRating = AverageRating.CreateNew();
    }
    
    public static Menu Create(string name,
        string description,
        HostId hostId,
        List<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}