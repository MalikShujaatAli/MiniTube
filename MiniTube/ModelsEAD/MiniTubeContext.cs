using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiniTube.ModelsEAD;

public partial class MiniTubeContext : DbContext
{
    public MiniTubeContext()
    {
    }

    public MiniTubeContext(DbContextOptions<MiniTubeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I6UBJ5U\\SQLEXPRESS;Database=MiniTube;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAA566188D7");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateCommentsCount"));

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CommentText).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VideoId).HasColumnName("VideoID");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserID__2739D489");

            entity.HasOne(d => d.Video).WithMany(p => p.Comments)
                .HasForeignKey(d => d.VideoId)
                .HasConstraintName("FK__Comments__VideoI__2645B050");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK__Likes__A2922CF4724F8431");

            entity.Property(e => e.LikeId).HasColumnName("LikeID");
            entity.Property(e => e.LikedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VideoId).HasColumnName("VideoID");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__UserID__2BFE89A6");

            entity.HasOne(d => d.Video).WithMany(p => p.Likes)
                .HasForeignKey(d => d.VideoId)
                .HasConstraintName("FK__Likes__VideoID__2B0A656D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF61C8A04");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Videos__BAE5124A82202BE8");

            entity.Property(e => e.VideoId).HasColumnName("VideoID");
            entity.Property(e => e.CommentsCount).HasDefaultValue(0);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Keyword1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Keyword2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Keyword3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LikesCount).HasDefaultValue(0);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Videos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Videos__UserID__1DB06A4F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
