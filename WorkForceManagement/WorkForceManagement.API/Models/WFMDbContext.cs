using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.API.Models
{
    public class WFMDbContext : DbContext
    {
        public WFMDbContext(DbContextOptions options) : base(options)
        {



        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Softlocks> Softlocks { get; set; }
        public DbSet<Skillmaps> Skillmaps { get; set; }
        public DbSet<Profiles> Profiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);

        }
        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Users
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(x => x.username).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.password).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.name).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.role).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Users>().Property(x => x.email).HasMaxLength(30).HasColumnType("varchar");
            #endregion

            #region Entity: Skills
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.skillname).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            #endregion

            #region Entity: Employees
            modelBuilder.Entity<Employees>().ToTable("Employees");
            modelBuilder.Entity<Employees>().Property(x => x.employee_name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.status).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.wfm_manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.email).HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.lockstatus).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Employees>().HasOne(a => a.profiles).WithMany(b => b.employees).HasForeignKey(c => c.profile_id);
            #endregion

            #region Entity: Softlocks
            modelBuilder.Entity<Softlocks>().ToTable("Softlocks");
            modelBuilder.Entity<Softlocks>().Property(x => x.manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlocks>().Property(x => x.reqdate).HasColumnType("datetime");
            modelBuilder.Entity<Softlocks>().Property(x => x.status).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlocks>().Property(x => x.lastupdated).HasColumnType("datetime");
            modelBuilder.Entity<Softlocks>().Property(x => x.requestmessage).HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Softlocks>().Property(x => x.wfmremark).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlocks>().Property(x => x.managerstatus).HasMaxLength(30).HasColumnType("varchar").HasDefaultValue("awaiting_approval");
            modelBuilder.Entity<Softlocks>().Property(x => x.mgrstatuscomment).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Softlocks>().Property(x => x.mgrlastupdate).HasColumnType("datetime");
            modelBuilder.Entity<Softlocks>().HasOne(a => a.employees).WithMany(b => b.softlocks).HasForeignKey(c => c.employee_id);
            #endregion

            #region Entity: Skillmaps
            modelBuilder.Entity<Skillmaps>().ToTable("Skillmaps");
            modelBuilder.Entity<Skillmaps>().HasKey(c => new { c.employee_id, c.skillid });
            modelBuilder.Entity<Skillmaps>().HasOne(a => a.employees).WithMany(b => b.skillmaps).HasForeignKey(c => c.employee_id);
            modelBuilder.Entity<Skillmaps>().HasOne(a => a.skills).WithMany(b => b.skillmaps).HasForeignKey(c => c.skillid);
            #endregion

            #region Entity: Profiles
            modelBuilder.Entity<Profiles>().ToTable("Profiles");
            modelBuilder.Entity<Profiles>().Property(x => x.profile_name).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            #endregion
        }
    }
}
