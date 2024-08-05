﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.Infrastructure.Common.Persistence;

#nullable disable

namespace SGE.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240804192726_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProcessProcedure", b =>
                {
                    b.Property<string>("ProcedureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProcessId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProcedureId", "ProcessId");

                    b.HasIndex("ProcessId");

                    b.ToTable("ProcessProcedure");

                    b.HasData(
                        new
                        {
                            ProcedureId = "d9a6b405-d552-4792-8ec5-588647ee9b67",
                            ProcessId = "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe"
                        },
                        new
                        {
                            ProcedureId = "b106bb0d-d2ad-4b56-b644-8fa514c8d3b7",
                            ProcessId = "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe"
                        });
                });

            modelBuilder.Entity("SGE.Domain.ProcessAggregate.Entities.Procedure", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Procedures", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d9a6b405-d552-4792-8ec5-588647ee9b67",
                            Name = "Otorgamiento de frecuenias"
                        },
                        new
                        {
                            Id = "b106bb0d-d2ad-4b56-b644-8fa514c8d3b7",
                            Name = "Modificaciones de parametros técnicos"
                        });
                });

            modelBuilder.Entity("SGE.Domain.ProcessAggregate.Process", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Processes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "87bd871f-ab3c-46da-81c8-3f1e8dd27dfe",
                            IsDeleted = false,
                            Name = "Televisión"
                        });
                });

            modelBuilder.Entity("SGE.Domain.Reminders.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDismissed")
                        .HasColumnType("bit");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("SGE.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_dismissedReminderIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DismissedReminderIds");

                    b.Property<string>("_reminderIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReminderIds");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProcessProcedure", b =>
                {
                    b.HasOne("SGE.Domain.ProcessAggregate.Entities.Procedure", "Procedure")
                        .WithMany()
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGE.Domain.ProcessAggregate.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Procedure");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("SGE.Domain.Users.User", b =>
                {
                    b.OwnsOne("SGE.Domain.Subscriptions.Subscription", "Subscription", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("SubscriptionId");

                            b1.Property<string>("SubscriptionType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("SGE.Domain.Users.Calendar", "_calendar", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("_calendar")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CalendarDictionary");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Subscription")
                        .IsRequired();

                    b.Navigation("_calendar");
                });
#pragma warning restore 612, 618
        }
    }
}
