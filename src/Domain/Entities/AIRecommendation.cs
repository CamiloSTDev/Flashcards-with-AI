
namespace Domain.Entities;

public partial class AIRecommendation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FlashcardId { get; set; }

    public double? Score { get; set; }

    public string? Reason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Flashcard Flashcard { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
