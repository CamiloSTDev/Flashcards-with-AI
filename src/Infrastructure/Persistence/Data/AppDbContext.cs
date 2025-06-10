using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AIRecommendation> AIRecommendations { get; set; }

    public virtual DbSet<Deck> Decks { get; set; }

    public virtual DbSet<Flashcard> Flashcards { get; set; }

    public virtual DbSet<FlashcardProgress> FlashcardProgresses { get; set; }

    public virtual DbSet<StudySession> StudySessions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AIRecommendation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AIRecomm__3214EC0747F0FB40");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.Flashcard).WithMany(p => p.AIRecommendations)
                .HasForeignKey(d => d.FlashcardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AIRecomme__Flash__6A30C649");

            entity.HasOne(d => d.User).WithMany(p => p.AIRecommendations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AIRecomme__UserI__693CA210");
        });

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Decks__3214EC07D9D2899C");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Decks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Decks__UserId__4F7CD00D");
        });

        modelBuilder.Entity<Flashcard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flashcar__3214EC07C4DEDACA");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Deck).WithMany(p => p.Flashcards)
                .HasForeignKey(d => d.DeckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Flashcard__DeckI__534D60F1");

            entity.HasMany(d => d.Tags).WithMany(p => p.Flashcards)
                .UsingEntity<Dictionary<string, object>>(
                    "FlashcardTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Flashcard__TagId__59FA5E80"),
                    l => l.HasOne<Flashcard>().WithMany()
                        .HasForeignKey("FlashcardId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Flashcard__Flash__59063A47"),
                    j =>
                    {
                        j.HasKey("FlashcardId", "TagId").HasName("PK__Flashcar__05384AE84601EBCD");
                        j.ToTable("FlashcardTags");
                    });
        });

        modelBuilder.Entity<FlashcardProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flashcar__3214EC07CB56F548");

            entity.ToTable("FlashcardProgress");

            entity.HasIndex(e => new { e.UserId, e.FlashcardId }, "UQ_UserFlashcard").IsUnique();

            entity.Property(e => e.CorrectCount).HasDefaultValue(0);
            entity.Property(e => e.IncorrectCount).HasDefaultValue(0);
            entity.Property(e => e.LastReviewed).HasColumnType("datetime");

            entity.HasOne(d => d.Flashcard).WithMany(p => p.FlashcardProgresses)
                .HasForeignKey(d => d.FlashcardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Flashcard__Flash__656C112C");

            entity.HasOne(d => d.User).WithMany(p => p.FlashcardProgresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Flashcard__UserI__6477ECF3");
        });

        modelBuilder.Entity<StudySession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudySes__3214EC0796169189");

            entity.Property(e => e.EndedAt).HasColumnType("datetime");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Deck).WithMany(p => p.StudySessions)
                .HasForeignKey(d => d.DeckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudySess__DeckI__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.StudySessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudySess__UserI__5DCAEF64");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tags__3214EC07C42E07D7");

            entity.HasIndex(e => e.Name, "UQ__Tags__737584F6363DCA47").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D2436808");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E45D1A98E3").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AB8B908E").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
