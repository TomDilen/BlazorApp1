using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class FootbalMatchhystorieService
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
            //new Country{Name="Tsjechië" , ImagePath ="images/countries/Tsjechië.png"},

        };




        public async Task<FootbalMatch[]> GetFootbalMatchAsync(DateTime startDate, int numberOfMatches)
        {
            //Task<int> task = new Task<int>(TelKaraktersUitBestand);
            //task.Start();
            ////Task.Run(() => CreateFootbalMatches(startDate, numberOfMatches));

            //Task<FootbalMatch[]> task = new Task<FootbalMatch[]>(CreateFootbalMatches(startDate, numberOfMatches));
            return  CreateFootbalMatches(startDate, numberOfMatches);
        }
        
        public FootbalMatch[] CreateFootbalMatches(DateTime startDate, int numberOfMatches) {

            Random rnd = new Random();
            Country[] Countries   = _countries.OrderBy(x => rnd.Next()).ToArray();


            FootbalMatch[] terug = new FootbalMatch[7]; //we hebben  8 landen, worden 7 matchen 

            for (int i = 0; i < terug.Length; i++)
            {
                terug[i] = new FootbalMatch();
                terug[i].Date = startDate.AddDays(i);
            }

            //========================================================
            //vierde finale
            //========================================================
            var rng = new Random();
            for (int i = 0; i < 4; i++)
            {
               

                //int countryHomeIndex = rng.Next(Countries.Length);
                //int countryOutIndex = countryHomeIndex;

                ////zoeken tot 2 indexen verschillend zijn
                //while (countryHomeIndex == countryOutIndex)
                //    countryOutIndex = rng.Next(Countries.Length);

                
                terug[i].CountryHome = Countries[i*2];
                terug[i].CountryOut = Countries[(i*2)+1];

                terug[i].GoalsHome = rng.Next(4);
                terug[i].GoalsOut = rng.Next(4);

                if (terug[i].CountryHome == _countries[0]) terug[i].GoalsHome = terug[i].GoalsOut+1;
                if (terug[i].CountryOut == _countries[0]) terug[i].GoalsOut = terug[i].GoalsHome+1;

                while (terug[i].GoalsHome == terug[i].GoalsOut)
                    terug[i].GoalsHome = rng.Next(7);

            }

            //========================================================
            //halve finale
            //========================================================

            //eerste match
            if (terug[0].GoalsHome > terug[0].GoalsOut) terug[4].CountryHome = terug[0].CountryHome;
            else terug[4].CountryHome = terug[0].CountryOut;
            
            if (terug[1].GoalsHome > terug[1].GoalsOut) terug[4].CountryOut = terug[1].CountryHome;
            else terug[4].CountryOut = terug[1].CountryOut;

            //tweede mathc

            //eerste
            if (terug[2].GoalsHome > terug[2].GoalsOut) terug[5].CountryHome = terug[2].CountryHome;
            else terug[5].CountryHome = terug[2].CountryOut;

            if (terug[3].GoalsHome > terug[3].GoalsOut) terug[5].CountryOut = terug[3].CountryHome;
            else terug[5].CountryOut = terug[3].CountryOut;


            //scores geven
            terug[4].GoalsHome = rng.Next(4);
            terug[4].GoalsOut = rng.Next(4);

            if (terug[4].CountryHome == _countries[0]) terug[4].GoalsHome = terug[4].GoalsOut + 1;
            if (terug[4].CountryOut == _countries[0]) terug[4].GoalsOut = terug[4].GoalsHome + 1;

            while (terug[4].GoalsHome == terug[4].GoalsOut)
                terug[4].GoalsHome = rng.Next(7);


            terug[5].GoalsHome = rng.Next(4);
            terug[5].GoalsOut = rng.Next(4);

            if (terug[5].CountryHome == _countries[0]) terug[5].GoalsHome = terug[5].GoalsOut + 1;
            if (terug[5].CountryOut == _countries[0]) terug[5].GoalsOut = terug[5].GoalsHome + 1;

            while (terug[5].GoalsHome == terug[5].GoalsOut)
                terug[5].GoalsHome = rng.Next(7);


            //========================================================
            //finale
            //========================================================

            //eerste match
            if (terug[4].GoalsHome > terug[4].GoalsOut) terug[6].CountryHome = terug[4].CountryHome;
            else terug[6].CountryHome = terug[4].CountryOut;

            if (terug[5].GoalsHome > terug[5].GoalsOut) terug[6].CountryOut = terug[5].CountryHome;
            else terug[6].CountryOut = terug[5].CountryOut;

            terug[6].GoalsHome = rng.Next(4);
            terug[6].GoalsOut = rng.Next(4);

            if (terug[6].CountryHome == _countries[0]) terug[6].GoalsHome = terug[6].GoalsOut + 1;
            if (terug[6].CountryOut == _countries[0]) terug[6].GoalsOut = terug[6].GoalsHome + 1;

            while (terug[6].GoalsHome == terug[6].GoalsOut)
                terug[6].GoalsHome = rng.Next(7);




            return terug;
        }

    }
}
