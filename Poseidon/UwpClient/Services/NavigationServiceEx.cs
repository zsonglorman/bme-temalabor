﻿using System;
using System.Collections.Generic;
using System.Linq;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UwpClient.Services
{
    public class NavigationServiceEx
    {
        public event NavigatedEventHandler Navigated;

        public event NavigationFailedEventHandler NavigationFailed;

        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        private Frame _frame;

        public Frame Frame
        {
            get
            {
                if (_frame == null)
                {
                    _frame = Window.Current.Content as Frame;
                    RegisterFrameEvents();
                }

                return _frame;
            }

            set
            {
                UnregisterFrameEvents();
                _frame = value;
                RegisterFrameEvents();
            }
        }

        public bool CanGoBack => Frame.CanGoBack;

        public bool CanGoForward => Frame.CanGoForward;

        public void GoBack() => Frame.GoBack();

        public void GoForward() => Frame.GoForward();

        public bool Navigate(string pageKey, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            lock (_pages)
            {
                if (!_pages.ContainsKey(pageKey))
                {
                    throw new ArgumentException($"Page not found: {pageKey}. Did you forget to call NavigationService.Configure?", "pageKey");
                }

                var navigationResult = Frame.Navigate(_pages[pageKey], parameter, infoOverride);
                return navigationResult;
            }
        }

        public void Configure(string key, Type pageType)
        {
            lock (_pages)
            {
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in NavigationService");
                }

                if (_pages.Any(p => p.Value == pageType))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == pageType).Key}");
                }

                _pages.Add(key, pageType);
            }
        }

        public string GetNameOfRegisteredPage(Type page)
        {
            lock (_pages)
            {
                if (_pages.ContainsValue(page))
                {
                    return _pages.FirstOrDefault(p => p.Value == page).Key;
                }
                else
                {
                    throw new ArgumentException($"The page '{page.Name}' is unknown by the NavigationService");
                }
            }
        }

        private void RegisterFrameEvents()
        {
            if (_frame != null)
            {
                _frame.Navigated += Frame_Navigated;
                _frame.NavigationFailed += Frame_NavigationFailed;
            }
        }

        private void UnregisterFrameEvents()
        {
            if (_frame != null)
            {
                _frame.Navigated -= Frame_Navigated;
                _frame.NavigationFailed -= Frame_NavigationFailed;
            }
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e) => NavigationFailed?.Invoke(sender, e);

        private void Frame_Navigated(object sender, NavigationEventArgs e) => Navigated?.Invoke(sender, e);
    }
}
