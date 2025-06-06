
namespace Domain.Entities;

public partial class Deck
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>();

    public virtual ICollection<StudySession> StudySessions { get; set; } = new List<StudySession>();

    public virtual User User { get; set; } = null!;
}
