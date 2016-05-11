using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPdf_RTLLanguageSupport.Utils
{
    public class ArabicScripting
    {
        private class ArabicCharInfo
        {
            public string Beginning;
            public string Middle;
            public string End;
            public string Isolated;
            public bool NewStartAfter; //to force the next letter to get Beginning position
            public bool IsTashkeel;
        }

        private static Dictionary<string, ArabicCharInfo> ArabicLetters = new Dictionary<string, ArabicCharInfo>()
        {
            { "أ",new ArabicCharInfo() { Beginning = "\uFE83",Middle = "\uFE84",End = "\uFE84",Isolated="\uFE83" , NewStartAfter = true  } },
            { "إ",new ArabicCharInfo() { Beginning = "\uFE87",Middle = "\uFE88",End = "\uFE88",Isolated="\uFE87" , NewStartAfter = true  } },
            { "ب",new ArabicCharInfo() { Beginning = "\uFE91",Middle = "\uFE92",End = "\uFE90",Isolated="\uFE8F" } },
            { "ت",new ArabicCharInfo() { Beginning = "\uFE97",Middle = "\uFE98",End = "\uFE96",Isolated="\uFE95" } },
            { "ث",new ArabicCharInfo() { Beginning = "\uFE9B",Middle = "\uFE9C",End = "\uFE9A",Isolated="\uFE99" } },
            { "ج",new ArabicCharInfo() { Beginning = "\uFE9F",Middle = "\uFEA0",End = "\uFE9E",Isolated="\uFE9D" } },
            { "ح",new ArabicCharInfo() { Beginning = "\uFEA3",Middle = "\uFEA4",End = "\uFEA2",Isolated="\uFEA1" } },
            { "خ",new ArabicCharInfo() { Beginning = "\uFEA7",Middle = "\uFEA8",End = "\uFEA6",Isolated="\uFEA5" } },
            { "د",new ArabicCharInfo() { Beginning = "\uFEA9",Middle = "\uFEAA",End = "\uFEAA",Isolated="\uFEA9" , NewStartAfter = true } },
            { "ذ",new ArabicCharInfo() { Beginning = "\uFEAB",Middle = "\uFEAC",End = "\uFEAC",Isolated="\uFEAB" , NewStartAfter = true} },
            { "ر",new ArabicCharInfo() { Beginning = "\uFEAD",Middle = "\uFEAE",End = "\uFEAE",Isolated="\uFEAD" , NewStartAfter = true} },
            { "ز",new ArabicCharInfo() { Beginning = "\uFEAF",Middle = "\uFEB0",End = "\uFEB0",Isolated="\uFEAF" , NewStartAfter = true} },
            { "س",new ArabicCharInfo() { Beginning = "\uFEB3",Middle = "\uFEB4",End = "\uFEB2",Isolated="\uFEB1" } },
            { "ش",new ArabicCharInfo() { Beginning = "\uFEB7",Middle = "\uFEB8",End = "\uFEB6",Isolated="\uFEB5" } },
            { "ص",new ArabicCharInfo() { Beginning = "\uFEBB",Middle = "\uFEBC",End = "\uFEBA",Isolated="\uFEB9" } },
            { "ض",new ArabicCharInfo() { Beginning = "\uFEBF",Middle = "\uFEC0",End = "\uFEBE",Isolated="\uFEBD" } },
            { "ط",new ArabicCharInfo() { Beginning = "\uFEC3",Middle = "\uFEC4",End = "\uFEC2",Isolated="\uFEC1" } },
            { "ظ",new ArabicCharInfo() { Beginning = "\uFEC7",Middle = "\uFEC8",End = "\uFEC6",Isolated="\uFEC5" } },
            { "ع",new ArabicCharInfo() { Beginning = "\uFECB",Middle = "\uFECC",End = "\uFECA",Isolated="\uFEC9" } },
            { "غ",new ArabicCharInfo() { Beginning = "\uFECF",Middle = "\uFED0",End = "\uFECE",Isolated="\uFECD" } },
            { "ف",new ArabicCharInfo() { Beginning = "\uFED3",Middle = "\uFED4",End = "\uFED2",Isolated="\uFED1" } },
            { "ق",new ArabicCharInfo() { Beginning = "\uFED7",Middle = "\uFED8",End = "\uFED6",Isolated="\uFED5" } },
            { "ك",new ArabicCharInfo() { Beginning = "\uFEDB",Middle = "\uFEDC",End = "\uFEDA",Isolated="\uFED9" } },
            { "ل",new ArabicCharInfo() { Beginning = "\uFEDF",Middle = "\uFEE0",End = "\uFEDE",Isolated="\uFEDD" } },
            { "م",new ArabicCharInfo() { Beginning = "\uFEE3",Middle = "\uFEE4",End = "\uFEE2",Isolated="\uFEE1" } },
            { "ن",new ArabicCharInfo() { Beginning = "\uFEE7",Middle = "\uFEE8",End = "\uFEE6",Isolated="\uFEE5" } },
            { "ه",new ArabicCharInfo() { Beginning = "\uFEEB",Middle = "\uFEEC",End = "\uFEEA",Isolated="\uFEE9" } },
            { "و",new ArabicCharInfo() { Beginning = "\uFEED",Middle = "\uFEEE",End = "\uFEEE",Isolated="\uFEED" , NewStartAfter = true } },
            { "ؤ",new ArabicCharInfo() { Beginning = "\uFE85",Middle = "\uFE86",End = "\uFE86",Isolated="\uFE85" , NewStartAfter = true } },
            { "ي",new ArabicCharInfo() { Beginning = "\uFEF3",Middle = "\uFEF4",End = "\uFEF2",Isolated="\uFEF1" } },
            { "ة",new ArabicCharInfo() { Beginning = "\uFE93",Middle = "\uFE94",End = "\uFE94",Isolated="\uFE93" , NewStartAfter = true} },
            { "ى",new ArabicCharInfo() { Beginning = "\uFEEF",Middle = "\uFEF0",End = "\uFEF0",Isolated="\uFEEF" , NewStartAfter = true} },
            { "ئ",new ArabicCharInfo() { Beginning = "\uFE8B",Middle = "\uFE8C",End = "\uFE8A",Isolated="\uFE89" } },
            { "ا",new ArabicCharInfo() { Beginning = "\uFE8D",Middle = "\uFE8E",End = "\uFE8E",Isolated="\uFE8D" , NewStartAfter = true} },
            { "ﻻ",new ArabicCharInfo() { Beginning = "\uFEFB",Middle = "\uFEFC",End = "\uFEFC",Isolated="\uFEFB" , NewStartAfter = true} },
            { "ﻷ",new ArabicCharInfo() { Beginning = "\uFEF7",Middle = "\uFEF8",End = "\uFEF8",Isolated="\uFEF7" , NewStartAfter = true} },
            { "ﻹ",new ArabicCharInfo() { Beginning = "\uFEF9",Middle = "\uFEFA",End = "\uFEFA",Isolated="\uFEF9" , NewStartAfter = true} },
            { "ﻵ",new ArabicCharInfo() { Beginning = "\uFEF5",Middle = "\uFEF6",End = "\uFEF6",Isolated="\uFEF5" , NewStartAfter = true} },
            { "ﺁ",new ArabicCharInfo() { Beginning = "\uFE81",Middle = "\uFE82",End = "\uFE82",Isolated="\uFE81" , NewStartAfter = true} },
            { "ﷲ",new ArabicCharInfo() { Beginning = "ﷲ",Middle = "ﷲ",End = "ﷲ",Isolated="ﷲ" } },
            { "ـ",new ArabicCharInfo() { Beginning = "ـ",Middle = "ـ",End = "ـ",Isolated="ـ" } },//مدة
            { "َ",new ArabicCharInfo() { Beginning = "\uFE76",Middle = "\uFE77",End = "\uFE77",Isolated="\uFE76" , IsTashkeel = true} },//فتحة
            { "ً",new ArabicCharInfo() { Beginning = "\uFE70",Middle = "\uFE71",End = "\uFE71",Isolated="\uFE70" , IsTashkeel = true } },//تنوين فتح
            { "ُ",new ArabicCharInfo() { Beginning = "\uFE78",Middle = "\uFE79",End = "\uFE79",Isolated="\uFE78" , IsTashkeel = true } },//ضمة
            { "ٌ",new ArabicCharInfo() { Beginning = "\uFE72",Middle = "ٌ",End = "ٌ",Isolated="\uFE72" , IsTashkeel = true } },//تنوين ضم
            { "ِ",new ArabicCharInfo() { Beginning = "\uFE7A",Middle = "\uFE7B",End = "\uFE7B",Isolated="\uFE7A" , IsTashkeel = true } },//كسرة
            { "ٍ",new ArabicCharInfo() { Beginning = "ٍ",Middle = "ٍ",End = "ٍ",Isolated="ٍ" , IsTashkeel = true } },//تنوين كسر
            { "ْ",new ArabicCharInfo() { Beginning = "\uFE7E",Middle = "\uFE7F",End = "\uFE7F",Isolated="\uFE7E" , IsTashkeel = true } },//سكون
            { "ّ",new ArabicCharInfo() { Beginning = "\uFE7C",Middle = "\uFE7D",End = "\uFE7D",Isolated="\uFE7C" , IsTashkeel = true } }, //شدة

            // add more letters to this dectionary 
        };


        public static string ConvertArabicTextToRTLShapes(string ArabicText)
        {

            string resultString = "";

            //replace the string with special character 
            ArabicText = ArabicText.Replace("لا", "ﻻ");
            ArabicText = ArabicText.Replace("لأ", "ﻷ");
            ArabicText = ArabicText.Replace("لإ", "ﻹ");
            ArabicText = ArabicText.Replace("لآ", "ﻵ");
            ArabicText = ArabicText.Replace("الله", "ﷲ");
            //ArabicText = ArabicText.Replace("لله", "للّه");


            ArabicText = ArabicText.Replace("\u064E", "َ"); // Fatha
            ArabicText = ArabicText.Replace("\u064B", "ً"); // Tanween Fatha
            ArabicText = ArabicText.Replace("\u064F", "ُ"); // Dhamma
            ArabicText = ArabicText.Replace("\u064C", "ٌ"); // Tanween Dhamma
            ArabicText = ArabicText.Replace("\u0650", "ِ"); // Kasra
            ArabicText = ArabicText.Replace("\u064D", "ٍ"); // Tanween Kasra
            ArabicText = ArabicText.Replace("\u0651", "ّ"); // Shaddah
            ArabicText = ArabicText.Replace("\u0652", "ْ"); // Skoon

            string ArabicTextWithoutTashkeel = ArabicText;

            // this loop remove all tashkeels from ArabicText (the input string)
            foreach (var TashkeelEntry in ArabicLetters.Where(i => i.Value.IsTashkeel))
            {
                ArabicTextWithoutTashkeel = ArabicTextWithoutTashkeel.Replace(TashkeelEntry.Key, "");
            }

            // this line creates a list of all sepcial chars (chars that are not in the ArabicLetters Dictionary)
            List<char> SepcialSeparators = ArabicTextWithoutTashkeel.Where(ch => !ArabicLetters.Select(p => p.Key).Select(s => s[0]).Contains(ch)).Distinct().ToList();

            // this line creates a list of all (new start after) chars, where NewStartAfter = true
            List<char> SeparatorsLetters = ArabicLetters.Where(p => p.Value.NewStartAfter).Select(p => p.Key).Select(s => s[0]).ToList();

            //List for storing result after first step of separation (separation based on SepcialSeparators)
            List<string> InitailSeparatedWords = new List<string>();

            string splittedSubWord = "";
            // Loop that do the first step of separation
            foreach (char ch in ArabicTextWithoutTashkeel)
            {

                if (SepcialSeparators.Contains(ch))
                {
                    InitailSeparatedWords.Add(splittedSubWord);
                    InitailSeparatedWords.Add(ch + "");
                    splittedSubWord = "";
                }
                else
                {
                    splittedSubWord += ch;
                }
            }
            if (splittedSubWord.Length > 0)
                InitailSeparatedWords.Add(splittedSubWord);

            splittedSubWord = "";


            //List for storing result after second step of separation (separation based on SeparatorsLetters)
            List<string> FinalSeparatedWords = new List<string>();

            foreach (string word in InitailSeparatedWords)
            {

                foreach (char ch in word)
                {
                    splittedSubWord += ch;
                    if (SeparatorsLetters.Contains(ch))
                    {
                        FinalSeparatedWords.Add(splittedSubWord);
                        splittedSubWord = "";
                    }
                }
                if (splittedSubWord.Length > 0)
                    FinalSeparatedWords.Add(splittedSubWord);
                splittedSubWord = "";
            }



            // Loop that do the logic for selecting the position for each letter
            foreach (string word in FinalSeparatedWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    ArabicCharInfo info = null;
                    if (!ArabicLetters.TryGetValue(ch + "", out info))
                    {
                        resultString += ch;
                        continue;
                    }
                    if (word.Length == 1)
                    {
                        resultString += info.Isolated;
                        continue;
                    }
                    if (i == 0)
                    {
                        resultString += info.Beginning;
                        continue;
                    }
                    if (i == word.Length - 1)
                    {
                        resultString += info.End;
                        continue;
                    }
                    resultString += info.Middle;
                }
            }

            // Loop for reinserting Tashkeel 
            for (int i = 0; i < resultString.Length; i++)
            {
                char ch = ArabicText[i];
                ArabicCharInfo info = null;
                if (!ArabicLetters.TryGetValue(ch + "", out info))
                {
                    continue;
                }
                if (resultString[i] == ch ||
                    resultString[i].ToString() == info.Beginning ||
                    resultString[i].ToString() == info.Middle ||
                    resultString[i].ToString() == info.End ||
                    resultString[i].ToString() == info.Isolated)
                {
                    continue;
                }
                resultString = resultString.Insert(i, "" + ch);
            }
            if (ArabicText.Length != resultString.Length)
                resultString += ArabicText.Substring(resultString.Length);

            // logic for handling English chars and numbers and reversing all the result but numbers and English letters
            string Result = "";
            string Numbers = "1234567890.";
            string EnglishLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string NumberTempHolder = ""; // to store numbers without reverse them
            string EnglishTempHolder = ""; // to store English letters without reverse them

            for (int i = 0; i < resultString.Length; i++)
            {
                if (Numbers.Contains(resultString[i]))
                {
                    NumberTempHolder += AppUtils.ConvertToIndicDigits("" + resultString[i]); //convert the arabic numbers to indic numbers
                }
                else if (EnglishLetters.Contains(resultString[i]))
                {
                    EnglishTempHolder += resultString[i];
                }
                else
                {
                    Result = NumberTempHolder + Result;
                    Result = EnglishTempHolder + Result;
                    NumberTempHolder = "";
                    EnglishTempHolder = "";
                    Result = resultString[i] + Result;
                }
            }

            if (NumberTempHolder.Length > 0)
                Result = NumberTempHolder + Result;
            if (EnglishTempHolder.Length > 0)
                Result = EnglishTempHolder + Result;

            var charArray = Result.Split('\r', '\v', '\n');
            Array.Reverse(charArray);
            string ResultWithOrderedLines = string.Join("\r", charArray);

            return ResultWithOrderedLines;
        }

    }
}
