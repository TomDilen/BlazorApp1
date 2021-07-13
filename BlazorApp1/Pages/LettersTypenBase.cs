using BlazorApp1.TDS;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class LettersTypenBase : ComponentBase
    {
        private const int MAX_CHARS = 255;

        private string _input;



        public string Input
        {
            get { return _input; }
            set { 
                _input = value;
                MaxcharsToType = MAX_CHARS - value.Length;
                AantalWoorden = value.CountWords();

                InputWithEmoticons = value.ReplaceEmoticons();
                WoordenVetTssSterretjes =InputWithEmoticons.ReplaceStringWithTagsByCharSeperator('*', "<span style=\"font-weight: 900;\">", "</span>");

                //InputWithEmoticons = value.ReplaceEmoticons();
                //WoordenVetTssSterretjes = value.ReplaceStringWithTagsByCharSeperator('*', "<span style=\"font-weight: 900;\">", "</span>");

            }
        }

        public int MaxcharsToType { get; private set; } = MAX_CHARS;

        public int AantalWoorden { get; private set; } = 0;

        public string WoordenVetTssSterretjes { get; set; }

        public string InputWithEmoticons { get; set; }

    }

}
