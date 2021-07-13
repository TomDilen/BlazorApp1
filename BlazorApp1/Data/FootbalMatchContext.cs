using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class FootbalMatchContext : ComponentBase
    {
        
        protected FootbalMatch[] FootbalMatches { get; set; }



        [Inject]
        protected FootbalMatchhystorieService FootbalMatchhystorieService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FootbalMatches = await FootbalMatchhystorieService.GetFootbalMatchAsync(DateTime.Now,13);
        }

    }
}
