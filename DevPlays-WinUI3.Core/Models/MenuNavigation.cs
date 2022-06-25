using System;
using System.Collections.Generic;
using System.Text;

namespace DevPlays_WinUI3.Core.Models
{
    public class MenuNavigation
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string NavigationName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
