﻿using EV.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EV.Merchant.ViewModels
{
    public class QRcodeViewModel : BaseViewModel
    {
        private string merchantAccount;

        public string MerchantAccount
        {
            get { return merchantAccount; }
            set
            {
                merchantAccount = value;

                OnPropertyCHanged();
            }
        }
        private string storeName;

        public string StoreName
        {
            get { return storeName; }
            set
            {
                storeName = value;
                OnPropertyCHanged();
            }
        }
        public ICommand BacktoPreviousCommand { get; set; }

        public QRcodeViewModel()
        {
            BacktoPreviousCommand = new Command(Goback);

        }
        private async void Goback()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
