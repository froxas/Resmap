﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resmap.Data;

namespace Resmap.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resmap.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Flat");

                    b.Property<string>("House");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Resmap.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Model");

                    b.Property<string>("NumberPlate");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Resmap.Domain.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactPerson");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PhoneNumber");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Resmap.Domain.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("ContactId");

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeID");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSubcontractor");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("NoteId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.HasIndex("NoteId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Resmap.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("Resource");

                    b.Property<DateTime>("Start");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Event");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");
                });

            modelBuilder.Entity("Resmap.Domain.LabelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("TenantId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("LabelEntity");
                });

            modelBuilder.Entity("Resmap.Domain.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("TenantId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Resmap.Domain.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Manager");

                    b.Property<Guid?>("NoteId");

                    b.Property<string>("ProjectId");

                    b.Property<Guid>("TenantId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NoteId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Resmap.Domain.ProjectTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("TagId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectTag");
                });

            modelBuilder.Entity("Resmap.Domain.Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("ContactId");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("NoteId");

                    b.Property<string>("RelationId");

                    b.Property<int>("RelationType");

                    b.Property<Guid>("TenantId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.HasIndex("NoteId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Resmap.Domain.RelationTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("RelationId");

                    b.Property<Guid>("TagId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("RelationId");

                    b.HasIndex("TagId");

                    b.ToTable("RelationTag");
                });

            modelBuilder.Entity("Resmap.Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Level");

                    b.Property<int>("TagType");

                    b.Property<Guid>("TenantId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Resmap.Domain.CarEvent", b =>
                {
                    b.HasBaseType("Resmap.Domain.Event");


                    b.ToTable("CarEvent");

                    b.HasDiscriminator().HasValue("CarEvent");
                });

            modelBuilder.Entity("Resmap.Domain.EmployeeEvent", b =>
                {
                    b.HasBaseType("Resmap.Domain.Event");

                    b.Property<Guid?>("ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeEvent");

                    b.HasDiscriminator().HasValue("EmployeeEvent");
                });

            modelBuilder.Entity("Resmap.Domain.Employee", b =>
                {
                    b.HasOne("Resmap.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Resmap.Domain.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Resmap.Domain.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("Resmap.Domain.Project", b =>
                {
                    b.HasOne("Resmap.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Resmap.Domain.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("Resmap.Domain.ProjectTag", b =>
                {
                    b.HasOne("Resmap.Domain.Project", "Project")
                        .WithMany("ProjectTags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Resmap.Domain.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resmap.Domain.Relation", b =>
                {
                    b.HasOne("Resmap.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Resmap.Domain.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Resmap.Domain.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("Resmap.Domain.RelationTag", b =>
                {
                    b.HasOne("Resmap.Domain.Relation", "Relation")
                        .WithMany("RelationTags")
                        .HasForeignKey("RelationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Resmap.Domain.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resmap.Domain.EmployeeEvent", b =>
                {
                    b.HasOne("Resmap.Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
