using MyApp.Pages;
using MyApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace MyApp.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            //Register pages and page models            
            Register<DashboardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            //Register servies (services are registered as Singletons default)
            _container.Register<INavigationService, NavigationService>();

        }

        public static T Resolve<T>() where T: class
        {
            return _container.Resolve<T>();
        }
        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TPageModel, Tpage>() where TPageModel : PageModelBase where Tpage :Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(Tpage));
            _container.Register<TPageModel>();
        }

    }
}
