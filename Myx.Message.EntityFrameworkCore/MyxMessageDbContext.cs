using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Myx.Message.Core.Entities;
using System;

namespace Myx.Message.EntityFrameworkCore
{
    public class MyxMessageDbContext : DbContext
    {
        public DbSet<SmsRecord> SmsRecords { get; set; }
        public MyxMessageDbContext(DbContextOptions<MyxMessageDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var smsRecords = builder.Entity<SmsRecord>();
            smsRecords.HasKey(e => e.Id);
            smsRecords.Property(e => e.PhoneNumbers).HasMaxLength(15);
            smsRecords.Property(e => e.SignName).HasMaxLength(20);
            smsRecords.Property(e => e.Status).HasMaxLength(50);
            smsRecords.Property(e => e.TemplateCode).HasMaxLength(50);
            smsRecords.Property(e => e.TemplateParam).HasMaxLength(500);
            smsRecords.Property(e => e.Reason).HasMaxLength(500);

            smsRecords.HasIndex(e => e.SendTime);
        }
    }
}
