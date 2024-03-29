﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EV.Customer.Dependency;
using EV.Customer.Droid.Dependency;
using Plugin.CurrentActivity;
using Xamarin.Essentials;
using ZXing.Mobile;
using static ZXing.Mobile.MobileBarcodeScanningOptions;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace EV.Customer.Droid.Dependency
{
    public class DeviceService : IDeviceService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner
            {
                UseCustomOverlay = true
            };

            var options = new ZXing.Mobile.MobileBarcodeScanningOptions()
            {
                TryHarder = true,
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                CameraResolutionSelector = new CameraResolutionSelectorDelegate(SelectLowestResolutionMatchingDisplayAspectRatio),
                PossibleFormats = new List<ZXing.BarcodeFormat>()
                {
                    ZXing.BarcodeFormat.QR_CODE
                }
            };

            View scanView = LayoutInflater.From(Application.Context).Inflate(Resource.Layout.ScanView, null);
            ImageView imgClose = scanView.FindViewById<ImageView>(Resource.Id.imgClose);
            imgClose.Click += delegate
            {
                scanner.Cancel();
            };
            scanner.CustomOverlay = scanView;

            ZXing.Result scanResults = await scanner.Scan(CrossCurrentActivity.Current.Activity, options);
            if (scanResults != null)
            {
                return scanResults.Text;
            }
            return string.Empty;
        }


        private CameraResolution SelectLowestResolutionMatchingDisplayAspectRatio(List<CameraResolution> availableResolutions)
        {
            CameraResolution result = null;
            //a tolerance of 0.1 should not be visible to the user
            double aspectTolerance = 0.1;
            var displayOrientationHeight = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait ? DeviceDisplay.MainDisplayInfo.Height : DeviceDisplay.MainDisplayInfo.Width;
            var displayOrientationWidth = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait ? DeviceDisplay.MainDisplayInfo.Width : DeviceDisplay.MainDisplayInfo.Height;
            //calculatiing our targetRatio
            var targetRatio = displayOrientationHeight / displayOrientationWidth;
            var targetHeight = displayOrientationHeight;
            var minDiff = double.MaxValue;
            //camera API lists all available resolutions from highest to lowest, perfect for us
            //making use of this sorting, following code runs some comparisons to select the lowest resolution that matches the screen aspect ratio and lies within tolerance
            //selecting the lowest makes Qr detection actual faster most of the time
            foreach (var r in availableResolutions.Where(r => Math.Abs(((double)r.Width / r.Height) - targetRatio) < aspectTolerance))
            {
                //slowly going down the list to the lowest matching solution with the correct aspect ratio
                if (Math.Abs(r.Height - targetHeight) < minDiff)
                    minDiff = Math.Abs(r.Height - targetHeight);
                result = r;
            }
            return result;
        }
    }
}