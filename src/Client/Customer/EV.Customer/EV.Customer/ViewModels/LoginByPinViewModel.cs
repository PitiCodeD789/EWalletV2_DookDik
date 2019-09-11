﻿using EV.Customer.Helper;
using EV.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EV.Customer.ViewModels
{
    public class LoginByPinViewModel : INotifyPropertyChanged
    {
        private readonly PinService _pinService = new PinService();
        public LoginByPinViewModel()
        {
            title = "";
            image = "";
            blackDetail = "ใส่รหัสผ่าน";
            grayDetail = "ใส่รหัสผ่านของคุณ";
            referenceText = "";
            referenceVisible = false;
            orangeText = "ลืมรหัสผ่าน";
            orangeVisible = true;
            warningText = "";
            warningVisible = false;
            backVisible = false;
            pin = "";
            countLogin = 0;
            email = SecureStorage.GetAsync("Email").Result;
            bool isExistEmail = Unities.CheckEmailFormat(email);
            if (!isExistEmail)
            {
                ForceLogout();
            }
            try
            {
                countLogin =  Int32.Parse(SecureStorage.GetAsync("CountLogin").Result);
            }
            catch(Exception e)
            {
                countLogin = 0;
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string blackDetail;
        public string BlackDetail
        {
            get { return blackDetail; }
            set { blackDetail = value; }
        }

        private string grayDetail;
        public string GrayDetail
        {
            get { return grayDetail; }
            set { grayDetail = value; }
        }

        private string referenceText;
        public string ReferenceText
        {
            get { return referenceText; }
            set { referenceText = value; }
        }

        private bool referenceVisible;
        public bool ReferenceVisible
        {
            get { return referenceVisible; }
            set { referenceVisible = value; }
        }

        private string orangeText;
        public string OrangeText
        {
            get { return orangeText; }
            set { orangeText = value; }
        }

        private bool orangeVisible;
        public bool OrangeVisible
        {
            get { return orangeVisible; }
            set { orangeVisible = value; }
        }

        private string warningText;
        public string WarningText
        {
            get
            {
                return warningText;
            }
            set
            {
                warningText = value;
                OnPropertyChanged(nameof(WarningText));
            }
        }

        private bool warningVisible;
        public bool WarningVisible
        {
            get
            {
                return warningVisible;
            }
            set
            {
                warningVisible = value;
                OnPropertyChanged(nameof(WarningVisible));
            }
        }

        private bool backVisible;
        public bool BackVisible
        {
            get { return backVisible; }
            set { backVisible = value; }
        }

        private string email;

        private string pin;

        private int countLogin;

        public ICommand OrangeTextTab { get; set; }
        //TODO : Input Name Page;
        public async void GoToForgotPasswordPage()
        {
            //await Application.Current.MainPage.Navigation(new Page());
        }

        public ICommand InputPin { get; set; }
        //TODO : Input Name Page;
        public async void LoginByPin(string value)
        {
            if (value == "Delete")
            {
                pin = pin.Remove(pin.Length - 1);
                int countPin = pin.Length;
                HintColorChange(countPin);
            }
            else
            {
                bool isExistvalue = Unities.CheckDigitaAndLength(value, 1);
                if (!isExistvalue)
                {
                    WarningText = "ค่าที่ใส่ไม่ใช่ตัวเลข";
                    WarningVisible = true;
                    try
                    {
                        Vibration.Vibrate();
                        var duration = TimeSpan.FromSeconds(1);
                        Vibration.Vibrate(duration);
                    }
                    catch (FeatureNotSupportedException ex)
                    {
                    }
                    catch (Exception ex)
                    {
                    }
                }
                pin += value;
                int countPin = pin.Length;
                HintColorChange(countPin);
                if (countPin == 6)
                {
                    var loginPinData = await _pinService.LoginByPin(pin, email);
                    if (loginPinData != null && !loginPinData.IsError && loginPinData.Model != null)
                    {
                        if (loginPinData.Model.IsLogin)
                        {
                            //Application.Current.MainPage = new NavigationPage(new Page());
                        }
                        else
                        {
                            pin = "";
                            countPin = pin.Length;
                            HintColorChange(countPin);
                            WarningText = "รหัสผ่านไม่ถูกต้อง";
                            WarningVisible = true;
                            try
                            {
                                Vibration.Vibrate();
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);
                            }
                            catch (FeatureNotSupportedException ex)
                            {
                            }
                            catch (Exception ex)
                            {
                            }
                            countLogin++;
                            await SecureStorage.SetAsync("CountLogin", countLogin.ToString());
                            if(countLogin >= 5)
                            {
                                ForceLogout();
                            }
                        }
                    }
                    else
                    {
                        WarningText = "ไม่สามารถเชื่อมต่อได้";
                        WarningVisible = true;
                        try
                        {
                            Vibration.Vibrate();
                            var duration = TimeSpan.FromSeconds(1);
                            Vibration.Vibrate(duration);
                        }
                        catch (FeatureNotSupportedException ex)
                        {
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }

        private void ForceLogout()
        {
            SecureStorage.RemoveAll();
            //Application.Current.MainPage = new NavigationPage(new Page());
        }

        private void HintColorChange(int length)
        {
            var hasKeyColor = "Gray";
            var hasNoKeyColor = "White";
            if (length == 0)
            {
                PwHint0 = hasNoKeyColor;
                PwHint1 = hasNoKeyColor;
                PwHint2 = hasNoKeyColor;
                PwHint3 = hasNoKeyColor;
                PwHint4 = hasNoKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 1)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasNoKeyColor;
                PwHint2 = hasNoKeyColor;
                PwHint3 = hasNoKeyColor;
                PwHint4 = hasNoKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 2)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasKeyColor;
                PwHint2 = hasNoKeyColor;
                PwHint3 = hasNoKeyColor;
                PwHint4 = hasNoKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 3)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasKeyColor;
                PwHint2 = hasKeyColor;
                PwHint3 = hasNoKeyColor;
                PwHint4 = hasNoKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 4)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasKeyColor;
                PwHint2 = hasKeyColor;
                PwHint3 = hasKeyColor;
                PwHint4 = hasNoKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 5)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasKeyColor;
                PwHint2 = hasKeyColor;
                PwHint3 = hasKeyColor;
                PwHint4 = hasKeyColor;
                PwHint5 = hasNoKeyColor;
            }
            else if (length == 6)
            {
                PwHint0 = hasKeyColor;
                PwHint1 = hasKeyColor;
                PwHint2 = hasKeyColor;
                PwHint3 = hasKeyColor;
                PwHint4 = hasKeyColor;
                PwHint5 = hasKeyColor;
            }
        }

        // ------------------------------ Propfull ------------------------------

        private string[] _pwHint = new string[] { "White", "White", "White", "White", "White", "White" };
        public string PwHint0
        {
            get { return _pwHint[0]; }
            set { _pwHint[0] = value; OnPropertyChanged(nameof(PwHint0)); }
        }
        public string PwHint1
        {
            get { return _pwHint[1]; }
            set { _pwHint[1] = value; OnPropertyChanged(nameof(PwHint1)); }
        }
        public string PwHint2
        {
            get { return _pwHint[2]; }
            set { _pwHint[2] = value; OnPropertyChanged(nameof(PwHint2)); }
        }
        public string PwHint3
        {
            get { return _pwHint[3]; }
            set { _pwHint[3] = value; OnPropertyChanged(nameof(PwHint3)); }
        }
        public string PwHint4
        {
            get { return _pwHint[4]; }
            set { _pwHint[4] = value; OnPropertyChanged(nameof(PwHint4)); }
        }
        public string PwHint5
        {
            get { return _pwHint[5]; }
            set { _pwHint[5] = value; OnPropertyChanged(nameof(PwHint5)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
