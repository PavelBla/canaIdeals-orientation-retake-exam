// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mountaineering.Database;

namespace Mountaineering.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211126091331_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Mountaineering.Models.Entities.Climber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("CurrentAltitude")
                        .HasColumnType("int");

                    b.Property<bool>("IsInjured")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("MountainId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Nation")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MountainId");

                    b.ToTable("Climbers");
                });

            modelBuilder.Entity("Mountaineering.Models.Entities.Mountain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FirstClimb")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("Mountaineering.Models.Entities.Climber", b =>
                {
                    b.HasOne("Mountaineering.Models.Entities.Mountain", "Mountain")
                        .WithMany("CurrClimbers")
                        .HasForeignKey("MountainId");

                    b.Navigation("Mountain");
                });

            modelBuilder.Entity("Mountaineering.Models.Entities.Mountain", b =>
                {
                    b.Navigation("CurrClimbers");
                });
#pragma warning restore 612, 618
        }
    }
}
