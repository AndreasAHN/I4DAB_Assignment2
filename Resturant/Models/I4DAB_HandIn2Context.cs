using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Resturant.Models
{
    public partial class I4DAB_HandIn2Context : DbContext
    {
        public I4DAB_HandIn2Context()
        {
        }

        public I4DAB_HandIn2Context(DbContextOptions<I4DAB_HandIn2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<GuestDish> GuestDish { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantDish> RestaurantDish { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<TableIns> TableIns { get; set; }
        public virtual DbSet<Waiter> Waiter { get; set; }
        public virtual DbSet<WaiterTableIns> WaiterTableIns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=84.238.88.212;uid=I4DAB_HandIn2;pwd=I4DaB1234;database=I4DAB_HandIn2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasIndex(e => e.FkPersonId)
                    .HasName("UQ__Guest__FE913B9F1415EBD3")
                    .IsUnique();

                entity.Property(e => e.GuestId).HasColumnName("guest_id");

                entity.Property(e => e.FkPersonId).HasColumnName("fk_person_id");

                entity.Property(e => e.Reservation)
                    .HasColumnName("reservation")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.FkPerson)
                    .WithOne(p => p.Guest)
                    .HasForeignKey<Guest>(d => d.FkPersonId)
                    .HasConstraintName("FK__Guest__fk_person__0559BDD1");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guest__review_id__0371755F");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guest__table_id__04659998");
            });

            modelBuilder.Entity<GuestDish>(entity =>
            {
                entity.HasKey(e => new { e.GuestId, e.DishId });

                entity.Property(e => e.GuestId).HasColumnName("guest_id");

                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.GuestDish)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GuestDish__dish___092A4EB5");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.GuestDish)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GuestDish__guest__08362A7C");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Address);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantDish>(entity =>
            {
                entity.HasKey(e => new { e.Addresse, e.DishId });

                entity.Property(e => e.Addresse)
                    .HasColumnName("addresse")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.HasOne(d => d.AddresseNavigation)
                    .WithMany(p => p.RestaurantDish)
                    .HasForeignKey(d => d.Addresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__addre__0C06BB60");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.RestaurantDish)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__dish___0CFADF99");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.Addresse)
                    .IsRequired()
                    .HasColumnName("addresse")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.Property(e => e.Stars)
                    .HasColumnName("stars")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddresseNavigation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.Addresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__addresse__7246E95D");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__Review__dish_id__733B0D96");
            });

            modelBuilder.Entity<TableIns>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.Property(e => e.Addresse)
                    .IsRequired()
                    .HasColumnName("addresse")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.AddresseNavigation)
                    .WithMany(p => p.TableIns)
                    .HasForeignKey(d => d.Addresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TableIns__addres__76177A41");
            });

            modelBuilder.Entity<Waiter>(entity =>
            {
                entity.HasIndex(e => e.PersonId)
                    .HasName("UQ__Waiter__543848DE359D21B2")
                    .IsUnique();

                entity.Property(e => e.WaiterId).HasColumnName("waiter_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Waiter)
                    .HasForeignKey<Waiter>(d => d.PersonId)
                    .HasConstraintName("FK__Waiter__person_i__7BD05397");
            });

            modelBuilder.Entity<WaiterTableIns>(entity =>
            {
                entity.HasKey(e => new { e.WaiterId, e.TableId });

                entity.Property(e => e.WaiterId).HasColumnName("waiter_id");

                entity.Property(e => e.TableId).HasColumnName("Table_id");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.WaiterTableIns)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WaiterTab__Table__7FA0E47B");

                entity.HasOne(d => d.Waiter)
                    .WithMany(p => p.WaiterTableIns)
                    .HasForeignKey(d => d.WaiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WaiterTab__waite__7EACC042");
            });
        }
    }
}
