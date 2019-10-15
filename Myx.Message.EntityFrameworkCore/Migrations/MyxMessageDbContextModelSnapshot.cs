﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myx.Message.EntityFrameworkCore;

namespace Myx.Message.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(MyxMessageDbContext))]
    partial class MyxMessageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Myx.Message.Core.Entities.SmsRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumbers")
                        .HasMaxLength(15);

                    b.Property<string>("Reason")
                        .HasMaxLength(500);

                    b.Property<DateTime>("SendTime");

                    b.Property<string>("SignName")
                        .HasMaxLength(20);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<string>("TemplateCode")
                        .HasMaxLength(50);

                    b.Property<string>("TemplateParam")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("SendTime");

                    b.ToTable("SmsRecords");
                });
#pragma warning restore 612, 618
        }
    }
}