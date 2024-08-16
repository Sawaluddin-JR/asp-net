﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMvcApp.Data;

#nullable disable

namespace MyMvcApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyMvcApp.Models.tblM_Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblM_Gender");
                });

            modelBuilder.Entity("MyMvcApp.Models.tblM_Hobi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblM_Hobi");
                });

            modelBuilder.Entity("MyMvcApp.Models.tblT_Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdGender")
                        .HasColumnType("int");

                    b.Property<int>("IdHobi")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Umur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdHobi");

                    b.ToTable("tblT_Personal");
                });

            modelBuilder.Entity("MyMvcApp.Models.tblT_Umur", b =>
                {
                    b.Property<int>("Umur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Umur"));

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Umur");

                    b.ToTable("tblT_Umur");
                });

            modelBuilder.Entity("MyMvcApp.Models.tblT_Personal", b =>
                {
                    b.HasOne("MyMvcApp.Models.tblM_Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMvcApp.Models.tblM_Hobi", "Hobi")
                        .WithMany()
                        .HasForeignKey("IdHobi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Hobi");
                });
#pragma warning restore 612, 618
        }
    }
}
