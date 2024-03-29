﻿using EWalletV2.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWalletV2.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            TransactionCustomerEntities = new HashSet<TransactionEntity>();
            TransactionOtherEntities = new HashSet<TransactionEntity>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public EW_Enumerations.EW_GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string Salt { get;  set; }
        public decimal Balance { get; set; }
        public string Account { get; set; }

        public ICollection<TransactionEntity> TransactionCustomerEntities { get; set; }
        public ICollection<TransactionEntity> TransactionOtherEntities { get; set; }
    }
}
