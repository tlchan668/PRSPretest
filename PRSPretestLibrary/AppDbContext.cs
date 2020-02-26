using Microsoft.EntityFrameworkCore;
using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRSPretestLibrary {
    public class AppDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLine> Requestlines { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress; database=PRSPretest; trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(u => {
                u.ToTable("Users");
                u.HasKey(x => x.Id);
                u.Property(x => x.Username).HasMaxLength(30).IsRequired();
                u.HasIndex(x => x.Username).IsUnique();
                u.Property(x => x.Password).HasMaxLength(30).IsRequired();
                u.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                u.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                u.Property(x => x.Phone).HasMaxLength(12);
                u.Property(x => x.Email).HasMaxLength(255);
                u.Property(x => x.IsReviewer).IsRequired();
                u.Property(x => x.IsAdmin).IsRequired();
            });
            model.Entity<Vendor>(v => {
                v.ToTable("Vendors");
                v.HasKey(x => x.Id);
                v.Property(x => x.Code).HasMaxLength(30).IsRequired();
                v.HasIndex(x => x.Code).IsUnique();
                v.Property(x => x.Name).HasMaxLength(30).IsRequired();
                v.Property(x => x.Address).HasMaxLength(30).IsRequired();
                v.Property(x => x.City).HasMaxLength(30).IsRequired();
                v.Property(x => x.State).HasMaxLength(2).IsRequired();
                v.Property(x => x.Zip).HasMaxLength(5).IsRequired();
                v.Property(x => x.Phone).HasMaxLength(12);
                v.Property(x => x.Email).HasMaxLength(255);
            });
            model.Entity<Product>(p => {
                p.ToTable("Products");
                p.HasKey(x => x.Id);
                p.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                p.HasIndex(x => x.PartNbr).IsUnique();
                p.Property(x => x.Name).HasMaxLength(30).IsRequired();
                p.Property(x => x.Price).HasColumnType("decimal(11,2)").IsRequired();
                p.Property(x => x.Unit).HasMaxLength(30).IsRequired();
                p.Property(x => x.PhotoPath).HasMaxLength(255);
                p.Property(x => x.VendorId).IsRequired();

            });
            model.Entity<Request>(r => {
                r.ToTable("Requests");
                r.HasKey(x => x.Id);
                r.Property(x => x.Description).HasMaxLength(80).IsRequired();
                r.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                r.Property(x => x.RejectionReason).HasMaxLength(80);
                r.Property(x => x.DeliveryMode).HasDefaultValue(true);
                r.Property(x => x.DeliveryMode).HasMaxLength(20).IsRequired();
                r.Property(x => x.Status).HasMaxLength(10).IsRequired();
                r.Property(x => x.Total).HasColumnType("decimal(11,2)").IsRequired();
                r.Property(x => x.UserId).IsRequired();

            });
            model.Entity<RequestLine>(rl => {
                rl.ToTable("Requestlines");
                rl.HasKey(x => x.Id);
                //rl.property(x => x.requestid).isrequired();
                //rl.property(x => x.productid).isrequired();
                //rl.HasKey(x => x.Id);
                rl.HasOne(x => x.Product).WithMany(x => x.Requestlines)
                                        .HasForeignKey(x => x.ProductId)
                                        .OnDelete(DeleteBehavior.Restrict);
            });

            
        }
    }
}
