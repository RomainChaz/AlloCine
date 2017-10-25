using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlloCine.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CompteViewModel>();
        }
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public CompteViewModel Compte => ServiceLocator.Current.GetInstance<CompteViewModel>();

        public AddCompteViewModel AddCompte => ServiceLocator.Current.GetInstance<AddCompteViewModel>();
    }
}
