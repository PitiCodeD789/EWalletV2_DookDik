﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EWalletV2.Api.ViewModels.Transaction
{
    public class GenerateTopupViewModel
    {
        public string ReferenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CheckSum { get; set; }
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
