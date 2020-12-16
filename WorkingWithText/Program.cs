using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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
            var splitNumbers = hyphenNum.Split('-');
            var numbersSplit = new List<int>();
            var specificNum = 0;

            foreach (var num in splitNumbers)
            {
                if (int.TryParse(num, out specificNum))
                {
                    numbersSplit.Add(specificNum);
                }

                else
                {
                    return false;
                }
            }
             var difference = numbersSplit[1] - numbersSplit[0];

            for (var i = 1; i < numbersSplit.Count; i++)
            {
                if (numbersSplit[i] != numbersSplit[i - 1] + difference)
                {
                    return false;
                }
                else if
                   (numbersSplit[1] != numbersSplit[i - 1] + difference)
                     {
                        return true;
                     }
            }
            return false;
        }
        // 2- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            var splitNumbers = hyphenNum.Split('-');
            var numbersSplit = new List<int>();
            int specificNum = 0;
            foreach (var num in splitNumbers)
                if (int.TryParse(num, out specificNum))
                    numbersSplit.Add(specificNum);
                else
                    return false;
            if (numbersSplit.Distinct().Count() != numbersSplit.Count())
                return true;
            else
                return false;
        }

        // 3- Write a method that accepts a string of a time 24-hour time format
        // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
        // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
        // consider it as False. Make sure that its returns false if any letters are passed.
        public static bool IsValidTime(string hyphenNum)
        {
            if (string.IsNullOrWhiteSpace(hyphenNum))
                return false;
            else if (hyphenNum[0] == '0' || hyphenNum[0] == '1' || hyphenNum[0] == '2')
                if (hyphenNum.Contains(':'))
                {
                    var time = hyphenNum.Split(':');
                    var hour = Convert.ToInt32(time[0]);
                    var minutes = Convert.ToInt32(time[1]);

                    if (time.Length != 2)
                        return false;
                    if (hour < 0 || hour > 23)
                        return false;
                    if (minutes < 0 || minutes > 59)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
                    return false;
        }

        // 4- Write a method that accepts a string of a few words separated by a space. Use the
        // words to create a variable name with PascalCase. For example, if the user types: "number
        // of students", return "NumberOfStudents". Make sure that the program is not dependent on
        // the input. So, if the user types "NUMBER OF STUDENTS", the program should still return "NumberOfStudents".
        // Trim off unneeded spaces.
        public static string PascalConverter(string aFewWords)
        {
            if (string.IsNullOrWhiteSpace(aFewWords))
                return null;

            var aCoupleWords = aFewWords.Trim(' ');
            var words = "";
            foreach (var word in aCoupleWords.Split(' '))
            {
                var capitalized = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                words += capitalized;
            }
            return words;
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            var englishWord = aWord.ToLower().ToCharArray();
            var result = 0;
            foreach (var vowel in englishWord)
                if (vowel == 'a')
                    result++;
                else if (vowel == 'e')
                    result++;
                else if (vowel == 'i')
                    result++;
                else if (vowel == 'o')
                    result++;
                else if (vowel == 'u')
                    result++;
            return result;
        }
    }


    internal static class Program
    {
        private static void Main()
        {
            // Method intentionally left empty.
        }
    }
}
