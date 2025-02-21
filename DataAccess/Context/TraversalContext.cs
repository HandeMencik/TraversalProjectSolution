using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TraversalContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public TraversalContext()
        {

        }
        public TraversalContext(DbContextOptions<TraversalContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-44V5O40\SQLEXPRESS; Database=TraversalDb; Integrated Security=True; TrustServerCertificate=True;");
        //}

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureTwo> FeatureTwos { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser - Reservation ilişkilendirme
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.AppUser)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
