using System;
using honyaku_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace honyaku_api.Data.EFCore
{
    public partial class honyakuapiContext : DbContext
    {
        public honyakuapiContext()
        {
        }

        public honyakuapiContext(DbContextOptions<honyakuapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Work> Work { get; set; }
        public virtual DbSet<WorkGenre> WorkGenre { get; set; }
        public virtual DbSet<WorkTranslator> WorkTranslator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DotNetEnv.Env.GetString("DATABASE_URL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_author_comment");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_work_comment");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.HasIndex(e => e.Value)
                    .HasName("token_value_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.IpAddress).HasColumnName("ip_address");

                entity.Property(e => e.UserAgent).HasColumnName("user_agent");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_token");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("user_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("user_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.IsTranslator).HasColumnName("is_translator");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("work");

                entity.HasIndex(e => e.Category)
                    .HasName("work_category_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<WorkGenre>(entity =>
            {
                entity.ToTable("work_genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.WorkGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_genre_work");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.WorkGenre)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_work_genre");
            });

            modelBuilder.Entity<WorkTranslator>(entity =>
            {
                entity.ToTable("work_translator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TranslatorId).HasColumnName("translator_id");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.HasOne(d => d.Translator)
                    .WithMany(p => p.WorkTranslator)
                    .HasForeignKey(d => d.TranslatorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_translator_work");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.WorkTranslator)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_work_translator");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
