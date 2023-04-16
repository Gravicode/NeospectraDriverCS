//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using NeospectraApp.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NeospectraApp
{
    // This scenario uses a DeviceWatcher to enumerate nearby Bluetooth Low Energy devices,
    // displays them in a ListView, and lets the user select a device and pair it.
    // This device will be used by future scenarios.
    // For more information about device discovery and pairing, including examples of
    // customizing the pairing process, see the DeviceEnumerationAndPairing sample.
    public sealed partial class Scenario1_Discovery : Page
    {
        private MainPage rootPage = MainPage.Current;

        private ObservableCollection<BluetoothLEDeviceDisplay> KnownDevices;
        private List<DeviceInformation> UnknownDevices;
       

       
        SWS_P3ConnectionServices service;
        #region UI Code
        public Scenario1_Discovery()
        {
            InitializeComponent();
            service = new SWS_P3ConnectionServices(this.Dispatcher);
            KnownDevices = service.KnownDevices;
            UnknownDevices = service.UnknownDevices;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            service.SetWatcher(false);

            // Save the selected device's ID for use in other scenarios.
            var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;
            if (bleDeviceDisplay != null)
            {
                rootPage.SelectedBleDeviceId = bleDeviceDisplay.Id;
                rootPage.SelectedBleDeviceName = bleDeviceDisplay.Name;
            }
        }
        private void EnumerateButton_Click()
        {
            if (service.deviceWatcher == null)
            {
                service.SetWatcher(true);
                EnumerateButton.Content = "Stop enumerating";
                rootPage.NotifyUser($"Device watcher started.", NotifyType.StatusMessage);
            }
            else
            {
                service.SetWatcher(false);
                EnumerateButton.Content = "Start enumerating";
                rootPage.NotifyUser($"Device watcher stopped.", NotifyType.StatusMessage);
            }
        }

        private bool Not(bool value) => !value;

        #endregion

        #region Device discovery

        

      

        #endregion

        #region Pairing

        private bool isBusy = false;

        private async void PairButton_Click()
        {
            // Do not allow a new Pair operation to start if an existing one is in progress.
            if (isBusy)
            {
                return;
            }

            isBusy = true;

            rootPage.NotifyUser("Pairing started. Please wait...", NotifyType.StatusMessage);

            // For more information about device pairing, including examples of
            // customizing the pairing process, see the DeviceEnumerationAndPairing sample.

            // Capture the current selected item in case the user changes it while we are pairing.
            var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;

            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();
            rootPage.NotifyUser($"Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);

            isBusy = false;
        }

        #endregion
    }
}