using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class FootbalMatch : ComponentBase
    {
        [Parameter]
        public DateTime Date { get; set; }

        [Parameter]
        public Country CountryHome { get; set; }

        [Parameter]
        public Country CountryOut { get; set; }

        [Parameter]
        public int GoalsHome { get; set; }

        [Parameter]
        public int GoalsOut { get; set; }


        //public override string ToString()
        //{
        //    StringBuilder terug = new StringBuilder();

        //    terug.Append($"======= {Date} =========\n");
        //    terug.Append($"{CountryHome} - {CountryOut}");
        //    terug.Append($"{GoalsHome} - {GoalsOut}");
        //    terug.Append($"===================================");

        //    return base.ToString();
        //}
    }
}
