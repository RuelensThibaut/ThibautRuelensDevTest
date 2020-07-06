using Business_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class TextAnalyserService : ITextAnalyserService
    {
        /// <summary>
        /// Calculates the amount of constanents in string
        /// </summary>
        /// <param name="textToBeAnalysed"></param>
        /// <returns>
        /// the amount of constenants as an integer</returns>
        public int calculateAmountOfConstenants(string textToBeAnalysed)
        {

            if (textToBeAnalysed == string.Empty) throw new Exception("String is empty");
            if (textToBeAnalysed.Any(char.IsDigit)) throw new Exception("String contains a number");
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            //The replace function is needed to be sure that " " or white space isn't counted as a constenant
            int total = textToBeAnalysed.Replace(" ",string.Empty).Count(c => !vowels.Contains(c));

            return total;
        }
        /// <summary>
        /// Calculates the amount of vowels in string
        /// </summary>
        /// <param name="textToBeAnalysed"></param>
        /// <returns>
        /// the amount of vowel as an integer</returns>
        public int calculateAmountOfVowels(string textToBeAnalysed)
        {
            if (textToBeAnalysed == string.Empty) throw new Exception("String is empty");
            if (textToBeAnalysed.Any(char.IsDigit)) throw new Exception("String contains a number");

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            int total = textToBeAnalysed.Count(c => vowels.Contains(c));

            return total;
        }

        /// <summary>
        /// This will return the string but in a reversed order
        /// </summary>
        /// <param name="textToBeAnalysed"></param>
        /// <returns>
        /// string of reversed order</returns>
        public string reverseString(string textToBeAnalysed)
        {
            if (textToBeAnalysed == string.Empty) throw new Exception("String is empty");
            if (textToBeAnalysed.Any(char.IsDigit)) throw new Exception("String contains a number");

            char[] charArray = textToBeAnalysed.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
