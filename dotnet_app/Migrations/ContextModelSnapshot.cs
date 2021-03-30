﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_app.Data;

namespace dotnet_app.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnet_app.Models.Command", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("howTo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CommandsContext");
                });

            modelBuilder.Entity("dotnet_app.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("dadId")
                        .HasColumnType("int");

                    b.Property<int?>("momId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("id");

                    b.HasIndex("dadId")
                        .IsUnique()
                        .HasFilter("[dadId] IS NOT NULL");

                    b.HasIndex("momId")
                        .IsUnique()
                        .HasFilter("[momId] IS NOT NULL");

                    b.ToTable("PersonContext");
                });

            modelBuilder.Entity("dotnet_app.Models.Person", b =>
                {
                    b.HasOne("dotnet_app.Models.Person", "dad")
                        .WithOne()
                        .HasForeignKey("dotnet_app.Models.Person", "dadId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dotnet_app.Models.Person", "mom")
                        .WithOne()
                        .HasForeignKey("dotnet_app.Models.Person", "momId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("dad");

                    b.Navigation("mom");
                });
#pragma warning restore 612, 618
        }
    }
}
