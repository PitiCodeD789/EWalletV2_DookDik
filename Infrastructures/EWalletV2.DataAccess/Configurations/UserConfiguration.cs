﻿using EWalletV2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWalletV2.DataAccess.Configurations
{
    class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> e)
        {
            base.Configure(e);

            e.ToTable("Users");

            e.Property(p => p.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(100);
            e.Property(p => p.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(100);
            e.Property(p => p.BirthDate)
                .HasColumnName("birthdate")
                .HasDefaultValue("01/01/0001")
                .HasMaxLength(100);
            e.Property(p => p.MobileNumber)
                .HasColumnName("mobile_number")
                .HasMaxLength(100);
            e.Property(p => p.Gender)
                .HasColumnName("gender");
            e.Property(p => p.Email)
                .HasColumnName("email")
                .HasMaxLength(100);
            e.HasAlternateKey(p => p.Email).HasName("EmailUser_AK");
            e.Property(p => p.Pin)
                .HasColumnName("pin")
                .HasMaxLength(100);
            e.Property(p => p.Salt)
                .HasColumnName("salt")
                .HasMaxLength(100);
            e.Property(p => p.Balance)
                .HasColumnName("balance");
            e.Property(p => p.Account)
                .HasColumnName("account")
                .HasMaxLength(100);
        }
    }
}
