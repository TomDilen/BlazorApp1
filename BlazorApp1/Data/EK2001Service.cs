using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class EK2001Service
    {

        private static readonly Country[] _countries = new[]
        {
            new Country{Name="Belgie" , ImagePath ="/images/countries/België.png"},
            new Country{Name="Denemarken" , ImagePath ="/images/countries/Denemarken.png"},
            new Country{Name="Engeland" , ImagePath ="/images/countries/Engeland.png"},
            new Country{Name="Italië" , ImagePath ="/images/countries/Italië.png"},
            new Country{Name="Nederland" , ImagePath ="/images/countries/Nederland.png"},
            new Country{Name="Oostenrijk" , ImagePath ="images/countries/Oostenrijk.png"},
            new Country{Name="Portugal" , ImagePath ="images/countries/Portugal.png"},
            new Country{Name="Spanje" , ImagePath ="images/countries/Spanje.png"},
        };




        public async Task<FootbalMatch[]> GetFootbalMatchAsync(DateTime startDate)
        {
            return await Task.Run(() => CreateFootbalMatches(startDate));
        }
        
        private FootbalMatch[] CreateFootbalMatches(DateTime startDate) {

            //async testen
            //---------------------------------------------------------
            Thread.Sleep(2000);
            //---------------------------------------------------------

            Random  rng = new Random();
            Country[] Countries   = _countries.OrderBy(x => rng.Next()).ToArray();


            FootbalMatch[] matchReturn = new FootbalMatch[7]; //we hebben  8 landen, worden 7 matchen 

            for (int i = 0; i < matchReturn.Length; i++)
            {
                matchReturn[i] = new FootbalMatch();
                matchReturn[i].Date = startDate.AddDays(i);
            }

            //========================================================
            //vierde finale
            //========================================================
           
            for (int i = 0; i < 4; i++)
            {

                matchReturn[i].CountryHome = Countries[i*2];
                matchReturn[i].CountryOut = Countries[(i*2)+1];

                matchReturn[i].GoalsHome = rng.Next(4);
                matchReturn[i].GoalsOut = rng.Next(4);

                //belgium always wins
                if (matchReturn[i].CountryHome == _countries[0]) matchReturn[i].GoalsHome = matchReturn[i].GoalsOut+1;
                if (matchReturn[i].CountryOut == _countries[0]) matchReturn[i].GoalsOut = matchReturn[i].GoalsHome+1;

                while (matchReturn[i].GoalsHome == matchReturn[i].GoalsOut)
                    matchReturn[i].GoalsHome = rng.Next(7);

            }

            //========================================================
            //halve finale
            //========================================================

            //eerste match
            if (matchReturn[0].GoalsHome > matchReturn[0].GoalsOut) matchReturn[4].CountryHome = matchReturn[0].CountryHome;
            else matchReturn[4].CountryHome = matchReturn[0].CountryOut;
            
            if (matchReturn[1].GoalsHome > matchReturn[1].GoalsOut) matchReturn[4].CountryOut = matchReturn[1].CountryHome;
            else matchReturn[4].CountryOut = matchReturn[1].CountryOut;

            //scores geven
            matchReturn[4].GoalsHome = rng.Next(4);
            matchReturn[4].GoalsOut = rng.Next(4);

            //belgium always wins
            if (matchReturn[4].CountryHome == _countries[0]) matchReturn[4].GoalsHome = matchReturn[4].GoalsOut + 1;
            if (matchReturn[4].CountryOut == _countries[0]) matchReturn[4].GoalsOut = matchReturn[4].GoalsHome + 1;

            //never a equal score
            while (matchReturn[4].GoalsHome == matchReturn[4].GoalsOut)
                matchReturn[4].GoalsHome = rng.Next(7);

            //-------------------------------------------------------------

            //tweede match
            if (matchReturn[2].GoalsHome > matchReturn[2].GoalsOut) matchReturn[5].CountryHome = matchReturn[2].CountryHome;
            else matchReturn[5].CountryHome = matchReturn[2].CountryOut;

            if (matchReturn[3].GoalsHome > matchReturn[3].GoalsOut) matchReturn[5].CountryOut = matchReturn[3].CountryHome;
            else matchReturn[5].CountryOut = matchReturn[3].CountryOut;

            //random scores
            matchReturn[5].GoalsHome = rng.Next(4);
            matchReturn[5].GoalsOut = rng.Next(4);

            //belgium always wins
            if (matchReturn[5].CountryHome == _countries[0]) matchReturn[5].GoalsHome = matchReturn[5].GoalsOut + 1;
            if (matchReturn[5].CountryOut == _countries[0]) matchReturn[5].GoalsOut = matchReturn[5].GoalsHome + 1;

            //never a equal score
            while (matchReturn[5].GoalsHome == matchReturn[5].GoalsOut)
                matchReturn[5].GoalsHome = rng.Next(7);


            //========================================================
            //finale
            //========================================================

            if (matchReturn[4].GoalsHome > matchReturn[4].GoalsOut) matchReturn[6].CountryHome = matchReturn[4].CountryHome;
            else matchReturn[6].CountryHome = matchReturn[4].CountryOut;

            if (matchReturn[5].GoalsHome > matchReturn[5].GoalsOut) matchReturn[6].CountryOut = matchReturn[5].CountryHome;
            else matchReturn[6].CountryOut = matchReturn[5].CountryOut;

            matchReturn[6].GoalsHome = rng.Next(4);
            matchReturn[6].GoalsOut = rng.Next(4);

            if (matchReturn[6].CountryHome == _countries[0]) matchReturn[6].GoalsHome = matchReturn[6].GoalsOut + 1;
            if (matchReturn[6].CountryOut == _countries[0]) matchReturn[6].GoalsOut = matchReturn[6].GoalsHome + 1;

            while (matchReturn[6].GoalsHome == matchReturn[6].GoalsOut)
                matchReturn[6].GoalsHome = rng.Next(7);




            return matchReturn;
        }

    }
}
