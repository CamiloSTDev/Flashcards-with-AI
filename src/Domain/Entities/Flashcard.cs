
namespace Domain.Entities;

public partial class Flashcard
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int DeckId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AIRecommendation> AIRecommendations { get; set; } = new List<AIRecommendation>();

    public virtual Deck Deck { get; set; } = null!;

    public virtual ICollection<FlashcardProgress> FlashcardProgresses { get; set; } = new List<FlashcardProgress>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
