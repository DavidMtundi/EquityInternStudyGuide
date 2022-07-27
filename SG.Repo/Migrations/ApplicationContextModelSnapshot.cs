﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SG.Repo;

#nullable disable

namespace SG.Repo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SG.Data.Entities.InternModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PFNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InternModels");
                });

            modelBuilder.Entity("SG.Data.Entities.LearningMaterialModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InternId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InternModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<Guid>("UploadModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InternModelId");

                    b.HasIndex("UploadModelId");

                    b.ToTable("LearningMaterialModels");
                });

            modelBuilder.Entity("SG.Data.Entities.SG.Data.Entities.ContentCreatorModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContentCreatorModels");
                });

            modelBuilder.Entity("SG.Data.Entities.UploadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ContentCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContentCreatorId");

                    b.ToTable("UploadModels");
                });

            modelBuilder.Entity("SG.Data.Entities.LearningMaterialModel", b =>
                {
                    b.HasOne("SG.Data.Entities.InternModel", "InternModel")
                        .WithMany()
                        .HasForeignKey("InternModelId");

                    b.HasOne("SG.Data.Entities.UploadModel", "Uploadmodel")
                        .WithMany()
                        .HasForeignKey("UploadModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InternModel");

                    b.Navigation("Uploadmodel");
                });

            modelBuilder.Entity("SG.Data.Entities.UploadModel", b =>
                {
                    b.HasOne("SG.Data.Entities.SG.Data.Entities.ContentCreatorModel", "ContentCreator")
                        .WithMany()
                        .HasForeignKey("ContentCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentCreator");
                });
#pragma warning restore 612, 618
        }
    }
}
