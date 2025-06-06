
namespace Domain.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
}
