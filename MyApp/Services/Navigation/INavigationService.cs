using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services.Navigation
{
    public interface INavigationService
    {

        /// <summary>
        /// Nvigation method to push onto the Navigation stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false);
       /// <summary>
       /// Navigation methos to pop off the Navigation Stack
       /// </summary>
       /// <returns></returns>
        Task GoBackAsync();
    }
}
