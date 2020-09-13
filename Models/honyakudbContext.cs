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
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkGenre> WorkGenre { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=honyaku-db;Username=user;Password=pass");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('comments_comment_id_seq'::regclass)");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Work).HasColumnName("work");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_author_fkey");

                entity.HasOne(d => d.WorkNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Work)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_for_title_fkey");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('genres_genre_id_seq'::regclass)");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(20);

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("token_user_id_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("user_email")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("user_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('users_user_id_seq'::regclass)");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirm_password")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(120);

                entity.Property(e => e.IsTranslator).HasColumnName("is_translator");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("profile_picture")
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<WorkGenre>(entity =>
            {
                entity.HasKey(e => new { e.WorkId, e.GenreId })
                    .HasName("work_genre_pkey");

                entity.ToTable("work_genre");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.WorkGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("work_genre_genre_id_fkey");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.WorkGenre)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("work_genre_work_id_fkey");
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.ToTable("works");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('works_work_id_seq'::regclass)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasMaxLength(500);

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
