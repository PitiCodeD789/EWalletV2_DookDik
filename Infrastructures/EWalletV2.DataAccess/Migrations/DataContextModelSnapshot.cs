﻿// <auto-generated />
using System;
using EWalletV2.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EWalletV2.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EWalletV2.Domain.Entities.OtpEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("Otp")
                        .HasColumnName("otp")
                        .HasMaxLength(100);

                    b.Property<string>("Reference")
                        .HasColumnName("reference")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("EWalletV2.Domain.Entities.TokenEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("RefreshToken")
                        .HasColumnName("refresh_token")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("EWalletV2.Domain.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("CreateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<int?>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<int?>("OtherId")
                        .HasColumnName("other_id");

                    b.Property<bool>("Status");

                    b.Property<string>("TransactionReference");

                    b.Property<int>("TransactionType");

                    b.Property<DateTime>("UpdateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OtherId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("EWalletV2.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnName("account")
                        .HasMaxLength(100);

                    b.Property<decimal>("Balance")
                        .HasColumnName("balance");

                    b.Property<DateTime>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("birthdate")
                        .HasMaxLength(100)
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime>("CreateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasColumnName("firstname")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasColumnName("lastname")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNumber")
                        .HasColumnName("mobile_number")
                        .HasMaxLength(100);

                    b.Property<string>("Pin")
                        .HasColumnName("pin")
                        .HasMaxLength(100);

                    b.Property<string>("Salt")
                        .HasColumnName("salt")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("EmailUser_AK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EWalletV2.Domain.Entities.TransactionEntity", b =>
                {
                    b.HasOne("EWalletV2.Domain.Entities.UserEntity", "UserCustomerEntity")
                        .WithMany("TransactionCustomerEntities")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_UserCustomerEntity")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EWalletV2.Domain.Entities.UserEntity", "UserOtherEntity")
                        .WithMany("TransactionOtherEntities")
                        .HasForeignKey("OtherId")
                        .HasConstraintName("FK_UserOtherEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
