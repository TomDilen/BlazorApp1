using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class DatabindingBase : ComponentBase
    {
        public string Name { get; set; } = "Joske";
        protected string Color { get; set; } = "background-color:red";
    }
}
