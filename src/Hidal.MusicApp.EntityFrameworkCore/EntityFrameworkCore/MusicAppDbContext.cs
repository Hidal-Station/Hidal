using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.DbMigrator.Categories;
using Hidal.MusicApp.DbMigrator.Comments;
using Hidal.MusicApp.DbMigrator.Favourites;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using Hidal.MusicApp.DbMigrator.Singers;
using Hidal.MusicApp.DbMigrator.Songs;
using Hidal.MusicApp.DbMigrator.AppUsers;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hidal.MusicApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MusicAppDbContext :
    AbpDbContext<MusicAppDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<PerformanceMusic> PerformanceMusics { get; set; }
    public DbSet<Singer> Singers { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<AppUser> appUsers { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MusicAppConsts.DbTablePrefix + "YourEntities", MusicAppConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Author>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Authors", MusicAppConsts.DbSchema);
            b.Property(x => x.Image).IsRequired(true).HasMaxLength(128);
            b.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            b.Property(x => x.Age).IsRequired(true);
            b.ConfigureByConvention();
        });

        builder.Entity<Category>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Categories", MusicAppConsts.DbSchema);
            b.Property(x => x.Description).IsRequired(true).HasMaxLength(250);
            b.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            b.ConfigureByConvention();
        });

        builder.Entity<Singer>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Singers", MusicAppConsts.DbSchema);
            b.Property(x => x.Image).IsRequired(false).HasMaxLength(50);
            b.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            b.Property(x => x.Story).IsRequired(false).HasMaxLength(300);
            b.ConfigureByConvention();
        });

        builder.Entity<AppUser>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "AppUsers", MusicAppConsts.DbSchema);
            b.Property(x => x.UserName).IsRequired(true).HasMaxLength(50);
            b.Property(x => x.Rule).IsRequired(true);
            b.Property(x => x.Email).IsRequired(false).HasMaxLength(50);
            b.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
            b.Property(x => x.Image).IsRequired(false);
            b.ConfigureByConvention();
        });

        builder.Entity<Song>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Songs", MusicAppConsts.DbSchema);
            b.Property(x => x.Description).IsRequired(false).HasMaxLength(250);
            b.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            b.HasOne(t => t.Author).WithMany(l => l.Songs).HasForeignKey(k => k.AuthorId).IsRequired(false);
            b.HasOne(t => t.Category).WithMany(l => l.Songs).HasForeignKey(k => k.CategoryId).IsRequired(false);
            b.ConfigureByConvention();
        });

        builder.Entity<Comment>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Comments", MusicAppConsts.DbSchema);
            b.Property(x => x.CommentString).IsRequired(true).HasMaxLength(300);
            b.Property(x => x.ParentId);
            b.HasOne(t => t.PerformanceMusic).WithMany(l => l.Comments).HasForeignKey(k => k.PerformanceMusicId);
            b.HasOne(t => t.AppUser).WithMany(l => l.Comments).HasForeignKey(k => k.AppUserId);
            b.ConfigureByConvention();
        });

        builder.Entity<Favourite>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "Favourites", MusicAppConsts.DbSchema);
            b.Property(x => x.Like).IsRequired(true);
            b.HasOne(t => t.PerformanceMusic).WithMany(l => l.Favourites).HasForeignKey(k => k.PerformanceMusicId);
            b.HasOne(t => t.AppUser).WithMany(l => l.Favourites).HasForeignKey(k => k.AppUserId);
            b.ConfigureByConvention();
        });

        builder.Entity<PerformanceMusic>(b =>
        {
            b.ToTable(MusicAppConsts.DbTablePrefix + "PerformanceMusics", MusicAppConsts.DbSchema);
            b.Property(x => x.SongName).IsRequired(false).HasMaxLength(300);
            b.Property(x => x.ratingAverage).IsRequired(true).HasDefaultValue(0);
            b.Property(x => x.NumberOfRating).IsRequired(true).HasDefaultValue(0);
            b.Property(x => x.Viewed).IsRequired(true).HasDefaultValue(0);
            b.Property(x => x.Image).IsRequired(false).HasMaxLength(50);
            b.Property(x => x.MusicFile).IsRequired(false);
            b.HasOne(t => t.Singer).WithMany(l => l.PerformanceMusics).HasForeignKey(k => k.SingerId);
            b.ConfigureByConvention();
        });


    }
}
