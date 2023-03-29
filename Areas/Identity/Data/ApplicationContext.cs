using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using System.Reflection.Emit;

namespace Movie_Hunter_FinalProject.Areas.Identity.Data;

public class ApplicationContext : IdentityDbContext<SystemUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Movies> movies { get; set; }

    public DbSet<Series> series { get; set; }

    public DbSet<LookUpTable> lookUpTables { get; set; }

    public DbSet<LookUpValues> lookUpValues { get; set; }

    public DbSet<Episodes> episodes { get; set; }

    public DbSet<UserMovies> userMovies { get; set; }

    public DbSet<UserSeries> userSeries { get; set; }

    public DbSet<UserEpisodes> userEpisodes { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<UserSeries>()
     .HasKey(us => new { us.id, us.SeriesId });

        builder.Entity<UserSeries>()
            .HasOne(us => us.systemUser)
            .WithMany(u => u.userSeries)
            .HasForeignKey(us => us.user_id)
            .OnDelete(DeleteBehavior.Restrict); // Set OnDelete to restrict cascading deletes

        builder.Entity<UserSeries>()
            .HasOne(us => us.series)
            .WithMany(s => s.userSeries)
            .HasForeignKey(us => us.SeriesId)
            .OnDelete(DeleteBehavior.Restrict); // Set OnDelete to restrict cascading deletes


        builder.Entity<SystemUser>()
            .HasOne(s => s.lookUpValues)
            .WithMany(s => s.Users)
            .HasForeignKey(s=>s.Plan_Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SystemUser>()
            .HasOne(s => s.lookUpValues)
            .WithMany(s => s.Users)
            .HasForeignKey(s => s.PaymentMethod_Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SystemUser>()
            .HasOne(s => s.lookUpValues)
            .WithMany(s => s.Users)
            .HasForeignKey(s => s.Category_Id)
            .OnDelete(DeleteBehavior.Restrict);





        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
