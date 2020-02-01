namespace EasyComTech.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EasyDbContext : DbContext
    {
        public EasyDbContext()
            : base("name=EasyDbContext")
        {
        }

        public virtual DbSet<DayTimeSetup> DayTimeSetups { get; set; }
        public virtual DbSet<DevDayTime> DevDayTimes { get; set; }
        public virtual DbSet<DevDetail> DevDetails { get; set; }
        public virtual DbSet<DevHour> DevHours { get; set; }
        public virtual DbSet<DevSkill> DevSkills { get; set; }
        public virtual DbSet<HoursSetup> HoursSetups { get; set; }
        public virtual DbSet<SkillsSetup> SkillsSetups { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DayTimeSetup>()
                .HasMany(e => e.DevDayTimes)
                .WithOptional(e => e.DayTimeSetup)
                .HasForeignKey(e => e.DayTimeId);

            modelBuilder.Entity<DevDetail>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DevDetail>()
                .HasMany(e => e.DevDayTimes)
                .WithOptional(e => e.DevDetail)
                .HasForeignKey(e => e.DevId);

            modelBuilder.Entity<DevDetail>()
                .HasMany(e => e.DevHours)
                .WithOptional(e => e.DevDetail)
                .HasForeignKey(e => e.DevId);

            modelBuilder.Entity<DevDetail>()
                .HasMany(e => e.DevSkills)
                .WithOptional(e => e.DevDetail)
                .HasForeignKey(e => e.DevId);

            modelBuilder.Entity<HoursSetup>()
                .HasMany(e => e.DevHours)
                .WithOptional(e => e.HoursSetup)
                .HasForeignKey(e => e.HourId);

            modelBuilder.Entity<SkillsSetup>()
                .HasMany(e => e.DevSkills)
                .WithRequired(e => e.SkillsSetup)
                .HasForeignKey(e => e.SkillId)
                .WillCascadeOnDelete(false);
        }
    }
}
