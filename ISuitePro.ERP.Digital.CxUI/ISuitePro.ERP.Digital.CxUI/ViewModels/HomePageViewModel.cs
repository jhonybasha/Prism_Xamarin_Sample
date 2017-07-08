using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISuitePro.ERP.Digital.CxUI.ViewModels
{
	public class HomePageViewModel : BindableBase
	{
        public DelegateCommand HomeCommand { get; set; }

        public HomePageViewModel()
        {
            HomeCommand = new DelegateCommand(Home);
        }

        private void Home()
        {
            //TODO: call service
        }
    }
}
