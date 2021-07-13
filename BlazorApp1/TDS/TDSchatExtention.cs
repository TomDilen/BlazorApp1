using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.TDS
{
    public static class TDSchatExtention
    {
        public static int CountWords(this string aString)
        {
            int laatste = aString.Length - 1;

            int teller = 0;
            for (int i = 0; i <= laatste; i++)
            {
                if (char.IsLetterOrDigit(aString[i]) &&
                     ((i == laatste) || char.IsPunctuation(aString[i + 1]) || char.IsWhiteSpace(aString[i + 1])))
                    teller++;
            }
            return teller;
        }

        public static string ReplaceStringWithTagsByCharSeperator(this string aString, char aSeperator, string aBeginTag, string aEndTag)
        {
            string[] splitted = aString.Split(aSeperator);


            if (splitted.Length < 3) return aString;


            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < splitted.Length - 2; i++)
            {
                sb.Append(splitted[i]);
                _ = i % 2 == 0 ? sb.Append(aBeginTag) : sb.Append(aEndTag);
            }
            sb.Append(splitted[splitted.Length - 2]);
            _ = splitted.Length % 2 == 0 ? sb.Append(aSeperator) : sb.Append(aEndTag);
            sb.Append(splitted[splitted.Length - 1]);

            return sb.ToString();
        }

        public static string ReplaceEmoticons(this string aString)
        {
            //https://support.skype.com/nl/faq/FA12330/wat-is-de-volledige-lijst-emoticons
            //https://www.w3schools.com/charsets/ref_emoji_smileys.asp

            string terug = aString;
            terug = terug.Replace(":-)", "&#x1F600;"); //Smile
            terug = terug.Replace(":-(", "&#x1F641;"); //bedroefd
            terug = terug.Replace(":-D", "&#x1F601;"); //big smile
            terug = terug.Replace(":-p", "&#x1F61B;"); //tong uitsteken
            terug = terug.Replace(":-@", "&#x1F621;"); //boos
            //terug = terug.Replace("", "&#;"); //
            //terug = terug.Replace("", "&#;"); //
            //terug = terug.Replace("", "&#;"); //



            // terug = "I will display &#x1F600;";
            return terug;
        }
    }
}
