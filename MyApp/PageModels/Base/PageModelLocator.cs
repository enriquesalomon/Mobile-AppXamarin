using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;

namespace MyApp.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;
    }
}
