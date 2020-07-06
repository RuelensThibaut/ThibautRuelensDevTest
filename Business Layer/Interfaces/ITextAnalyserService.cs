using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interfaces
{
    public interface ITextAnalyserService
    {

        int calculateAmountOfVowels(string textToBeAnalysed);
        int calculateAmountOfConstenants(string textToBeAnalysed);
        string reverseString(string textToBeAnalysed);
    }
}
