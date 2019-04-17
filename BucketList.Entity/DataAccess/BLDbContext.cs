using BucketList.Common.StaticConstants;
using BucketList.Entity.BaseEntities;
using BucketList.Entity.Model.Auth;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Entity.Model.DemoModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BucketList.Entity.DataAccess
{
    public class BLDbContext : IdentityDbContext<AppUser>
    {
        public BLDbContext()
        {

        }
        public BLDbContext(DbContextOptions<BLDbContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //stagging
            //optionsBuilder.UseSqlServer(Constants.BLConnectionString);

            //local
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB10;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SaveAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SaveAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void SaveAuditInfo()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<AuditInfoBaseEntity>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.DateModified = DateTimeOffset.UtcNow;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.DateCreated = DateTimeOffset.UtcNow;
                    }
                    else
                    {
                        auditableEntity.Property(p => p.DateCreated).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
                if (auditableEntity.Entity.IsDeleted)
                {
                    auditableEntity.Entity.DateDeleted = DateTimeOffset.UtcNow;
                }
            }
        }

        public DbSet<DemoModel> DemoModel { get; set; }
        public DbSet<BucketItem> BucketItem { get; set; }

    }
}
