
namespace Domain.Entities;

public partial class FlashcardProgress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FlashcardId { get; set; }

    public int? CorrectCount { get; set; }

    public int? IncorrectCount { get; set; }

    public DateTime? LastReviewed { get; set; }

    public virtual Flashcard Flashcard { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
