﻿// <auto-generated />
using Domain.IPL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20230206071829_species")]
    partial class species
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EukaryoteSequence");

            modelBuilder.Entity("Domain.DL.Models.LifeformModels.Eukaryote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [EukaryoteSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalObservationTimes")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Domain.DL.Models.MessageModels.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EukaryoteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EukaryoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.DL.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.DL.Models.LifeformModels.Animalia", b =>
                {
                    b.HasBaseType("Domain.DL.Models.LifeformModels.Eukaryote");

                    b.Property<bool>("IsBird")
                        .HasColumnType("bit");

                    b.Property<byte>("MaximumOffspringsPerMating")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MinimumOffspringsPerMating")
                        .HasColumnType("tinyint");

                    b.ToTable("Animalia");
                });

            modelBuilder.Entity("Domain.DL.Models.LifeformModels.Plantae", b =>
                {
                    b.HasBaseType("Domain.DL.Models.LifeformModels.Eukaryote");

                    b.Property<double>("MaximumHeight")
                        .HasColumnType("float");

                    b.ToTable("Plantae");
                });

            modelBuilder.Entity("Domain.DL.Models.MessageModels.Message", b =>
                {
                    b.HasOne("Domain.DL.Models.LifeformModels.Eukaryote", "Eukaryote")
                        .WithMany()
                        .HasForeignKey("EukaryoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DL.Models.UserModels.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Domain.DL.Models.MessageModels.Like", "Likes", b1 =>
                        {
                            b1.Property<int>("MessageId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.HasKey("MessageId", "Id");

                            b1.ToTable("Message_Likes", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.OwnsOne("Domain.DL.Models.MessageModels.ObservationTimeAndLocation", "Data", b1 =>
                        {
                            b1.Property<int>("MessageId")
                                .HasColumnType("int");

                            b1.HasKey("MessageId");

                            b1.ToTable("Messages");

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.Navigation("Data")
                        .IsRequired();

                    b.Navigation("Eukaryote");

                    b.Navigation("Likes");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.DL.Models.UserModels.User", b =>
                {
                    b.OwnsOne("Domain.DL.Models.UserModels.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.DL.Models.UserModels.User", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}