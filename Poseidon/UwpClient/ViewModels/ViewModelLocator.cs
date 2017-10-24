using System;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using UwpClient.Services;
using UwpClient.Views;

namespace UwpClient.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<StartPageViewModel, StartPagePage>();
            Register<EnrolledSubjectsPageViewModel, EnrolledSubjectsPagePage>();
            Register<EnrollableSubjectsPageViewModel, EnrollableSubjectsPagePage>();
            Register<ChartViewModel, ChartPage>();
            Register<TabbedViewModel, TabbedPage>();
            Register<ContactsPageViewModel, ContactsPagePage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<DetailsViewModel, DetailsPage>();
        }

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ContactsPageViewModel ContactsPageViewModel => ServiceLocator.Current.GetInstance<ContactsPageViewModel>();

        public TabbedViewModel TabbedViewModel => ServiceLocator.Current.GetInstance<TabbedViewModel>();

        public ChartViewModel ChartViewModel => ServiceLocator.Current.GetInstance<ChartViewModel>();

        public EnrollableSubjectsPageViewModel EnrollableSubjectsPageViewModel => ServiceLocator.Current.GetInstance<EnrollableSubjectsPageViewModel>();

        public EnrolledSubjectsPageViewModel EnrolledSubjectsPageViewModel => ServiceLocator.Current.GetInstance<EnrolledSubjectsPageViewModel>();

        public StartPageViewModel StartPageViewModel => ServiceLocator.Current.GetInstance<StartPageViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public DetailsViewModel DetailsViewModel => ServiceLocator.Current.GetInstance<DetailsViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
