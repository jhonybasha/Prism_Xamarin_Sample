using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ISuitePro.ERP.Digital.CxUI
{
    public class NavigationItem
    {
        public string Text { get; private set; }
        public string Icon { get; private set; }
        public ICommand Command { get; private set; }

        public NavigationItem(string text, string icon, ICommand command)
        {
            Text = text;
            Icon = icon;
            Command = command;
        }
    }
}
