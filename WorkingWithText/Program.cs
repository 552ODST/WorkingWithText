using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace WorkingWithText
{
    public static class WorkingWithText
    {
        // 1- Write a method that accepts a string of numbers separated by a hyphen. If the input 
        // is NOT in the correct format OR is NOT consecutive then return bool False. If the format 
        // is correct AND the numbers are consecutive, return bool True. For
        // example, if the input is "5-6-7-8-9" or "20-19-18-17-16", return bool True.
        // Do not use .Sort, it will cause the test to pass when it actually does not.
        public static bool IsConsecutive(string hyphenNum)
        {
            bool valid = false;

            try
            {
                

                List<int> list = hyphenNum.Split('-').Select(p => int.Parse(p)).ToList();

                bool hasDuplicates = list.Count != list.Distinct().Count();
                bool isAsc = false;
                bool isDsc = false;

                var orderedByAsc = list.OrderBy(d => d);
                if (list.SequenceEqual(orderedByAsc))
                {
                    isAsc = true;
                }

                var orderedByDsc = list.OrderByDescending(d => d);
                if (list.SequenceEqual(orderedByDsc))
                {
                    isDsc = true;
                }

                if (isAsc && !hasDuplicates || isDsc && !hasDuplicates)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            catch (Exception e)
            {
                valid = false;
            }


            return valid;
        }

        // 2- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            bool valid = false;

            try
            {
                List<int> list = hyphenNum.Split('-').Select(p => int.Parse(p)).ToList();

                bool hasDuplicates = list.Count != list.Distinct().Count();

                if (hasDuplicates)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            catch (Exception e)
            {
                valid = false;
            }

            return valid;
        }
   

    // 3- Write a method that accepts a string of a time 24-hour time format
    // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
    // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
    // consider it as False. Make sure that its returns false if any letters are passed.
    public static bool IsValidTime(string hyphenNum)
        {
            bool passed = false;

            string format = "HH:mm";

            CultureInfo invariant = System.Globalization.CultureInfo.InvariantCulture;

            DateTime dt;

            if (DateTime.TryParseExact(hyphenNum, format, invariant, DateTimeStyles.None, out dt))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }

            return passed;
        }
       

        // 4- Write a method that accepts a string of a few words separated by a space. Use the
        // words to create a variable name with PascalCase. For example, if the user types: "number
        // of students", return "NumberOfStudents". Make sure that the program is not dependent on
        // the input. So, if the user types "NUMBER OF STUDENTS", the program should still return "NumberOfStudents".
        // Trim off unneeded spaces.
        public static string PascalConverter(string aFewWords)
        {
            string oneWord;

            if(string.IsNullOrEmpty(aFewWords))
            {
                return aFewWords;
            }
            else
            {
                oneWord = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(aFewWords.Trim().ToLower());

                oneWord = oneWord.Replace(" ", string.Empty);

                return oneWord;
            }
        	
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            int total = 0;
            
            for(int i = 0; i < aWord.Length; i++)
            {
                if (aWord[i] == 'a' || aWord[i] == 'e'|| aWord[i] == 'i'|| aWord[i] == 'o' || aWord[i] == 'u'||
                    aWord[i] == 'A' || aWord[i] == 'E'|| aWord[i] == 'I'|| aWord[i] == 'O' || aWord[i] == 'U')
                {
                    total++;
                }
            }
            return total;
        }
    }


    internal static class Program
    {
        private static void Main()
        {
            
        }
    }
}
