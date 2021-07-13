using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class ForecastBase : ComponentBase
    {
        protected  WeatherForecast[] forecasts;// { get; set; }



        [Inject]
        protected WeatherForecastService WeatherForecastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
        }

    }
}
