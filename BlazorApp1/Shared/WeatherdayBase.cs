using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class WeatherdayBase : ComponentBase
    {
        [Parameter]
        public DayOfWeek DayOfWeek { get; set; }

        [Parameter]
        public int Temperature { get; set; }

        [Parameter]
        public string Sumary { get; set; }



        public string  Icon
        {
            get {
                if (Sumary == "Cloudy") return "cloud";
                if (Sumary == "Rainy") return "rain";
                if (Sumary == "Sunny") return "sun";

                else return "";
            }
          
        }

    }
}
