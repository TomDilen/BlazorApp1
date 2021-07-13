using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class EK2021base : ComponentBase
    {
        protected FootbalMatch[] footbalMatches;// { get; set; }



        [Inject]
        protected EK2001Service FootbalMatchhystorieService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            footbalMatches = await FootbalMatchhystorieService.GetFootbalMatchAsync(DateTime.Now);
        }



    }
}
