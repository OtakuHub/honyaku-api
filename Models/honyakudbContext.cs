using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace honyaku_api.Models
{
    public partial class honyakudbContext : DbContext
    {
        public honyakudbContext()
        {
        }

        public honyakudbContext(DbContextOptions<honyakudbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=honyaku-db;Username=postgres;Password=Momdad@23");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("comments_pkey");

                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.ForTitle).HasColumnName("for_title");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_author_fkey");

                entity.HasOne(d => d.ForTitleNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ForTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_for_title_fkey");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("genres_pkey");

                entity.ToTable("genres");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(50);

                entity.Property(e => e.WorkTitle).HasColumnName("work_title");

                entity.HasOne(d => d.WorkTitleNavigation)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.WorkTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genres_work_title_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("users_username_key")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirm_password")
                    .HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(120);

                entity.Property(e => e.IsTranslator).HasColumnName("is_translator");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PictureName).HasColumnName("picture_name");

                entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasKey(e => e.WorkId)
                    .HasName("works_pkey");

                entity.ToTable("works");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Translators).HasColumnName("translators");

                entity.HasOne(d => d.TranslatorsNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.Translators)
                    .HasConstraintName("works_translators_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
