
namespace Domain.Entities;

public partial class StudySession
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int DeckId { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? EndedAt { get; set; }

    public virtual Deck Deck { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
