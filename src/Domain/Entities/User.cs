
namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AIRecommendation> AIRecommendations { get; set; } = new List<AIRecommendation>();

    public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();

    public virtual ICollection<FlashcardProgress> FlashcardProgresses { get; set; } = new List<FlashcardProgress>();

    public virtual ICollection<StudySession> StudySessions { get; set; } = new List<StudySession>();
}
