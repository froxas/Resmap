﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Resmap.API.Data;
using System;

namespace Resmap.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180526090715_addedRelationTypeEntity")]
    partial class addedRelationTypeEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resmap.API.Data.Address", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Resmap.API.Data.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Resmap.API.Data.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeID");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSubcontractor");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Resmap.API.Data.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("Resmap.API.Data.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Resmap.API.Data.Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("NoteId");

                    b.Property<string>("RelationId");

                    b.Property<Guid?>("RelationTypeId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NoteId");

                    b.HasIndex("RelationTypeId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Resmap.API.Data.RelationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("RelationType");
                });

            modelBuilder.Entity("Resmap.API.Data.Employee", b =>
                {
                    b.HasOne("Resmap.API.Data.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Resmap.API.Data.Relation", b =>
                {
                    b.HasOne("Resmap.API.Data.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Resmap.API.Data.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId");

                    b.HasOne("Resmap.API.Data.RelationType", "RelationType")
                        .WithMany()
                        .HasForeignKey("RelationTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
