using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackBuilder.Models
{
    public class ComponentModel
    {
        public IList<string> SelectedComponent { get; set; }
        public IList<SelectListItem> AvailableComponent { get; set; }

        public ComponentModel()
        {
            SelectedComponent = new List<string>();
        }
    }
}
