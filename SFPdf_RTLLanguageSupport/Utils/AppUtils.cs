using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPdf_RTLLanguageSupport.Utils
{
    public class AppUtils
    {
        public static string ConvertToIndicDigits(string value)
        {
            try
            {
                string resultIndicString = "";
                string ARABIC_NUMBERS = "0123456789.";
                string INDIC_NUMBERS = "٠١٢٣٤٥٦٧٨٩٫";
                foreach (char ch in value)
                {
                    if (ARABIC_NUMBERS.IndexOf(ch) >= 0)
                        resultIndicString += INDIC_NUMBERS[ARABIC_NUMBERS.IndexOf(ch)];
                    else
                        resultIndicString += ch;
                }
                return resultIndicString;
            }
            catch
            {
                return null;
            }
        }
    }
}
