using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class FootbalMatch
    {

        public DateTime Date { get; set; }

        public Country CountryHome { get; set; }

        public Country CountryOut { get; set; }

        public int GoalsHome { get; set; }

        public int GoalsOut { get; set; }
    }
}
