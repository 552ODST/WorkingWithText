using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace WorkingWithText
{
    public static class WorkingWithText
    {
        // 1- Write a method that accepts a string of numbers separated by a hyphen. If the
        // input is incorrect, return false Work out if the numbers are consecutive. For
        // example, if the input is "5-6-7-8-9" or "20-19-18-17-16", return bool True; otherwise,
        // return bool False.
        public static bool IsConsecutive(string hyphenNum)
        {
            var splitNum = hyphenNum.Split('-');
            var numSplitList = new List<int>();
            int parseVar = 0;

            foreach (var num in splitNum)
            {
                if (int.TryParse(num, out parseVar))
                {
                    numSplitList.Add(parseVar);
                }
                else
                {
                    return false;
                }
            }

            for (var i = 1; i < numSplitList.Count; i++)
            {
                numSplitList.Sort();

                if (numSplitList[i] != numSplitList[i - 1] + 1)
                {
                    return false;
                }
            }
            return true;
        }

        // 2- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            var splitNum = hyphenNum.Split('-');
            var intList = new List<int>();
            int parseVar = 0;

            foreach (var num in splitNum)
            {
                if (int.TryParse(num, out parseVar))
                {
                    intList.Add(parseVar);
                }
                else
                {
                    return false;
                }
            }
            if (intList.Distinct().Count() != intList.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
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
            {
                if (hyphenNum.Contains(':'))
                {
                    var times = hyphenNum.Split(':');
                    var hour = Convert.ToInt32(times[0]);
                    var min = Convert.ToInt32(times[1]);

                    if (times.Length != 2)
                        return false;
                    else if (hour < 0 || hour > 23)
                        return false;
                    else if (min < 0 || min > 59)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            else
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
            {
                return null;
            }
            var myFewWords = aFewWords.Trim(' ');
            var wordMy = "";

            foreach (var word in myFewWords.Split(' '))
            {
                var capitalWord = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                wordMy += capitalWord;
            }
            return wordMy;
            /*for (var i = 0; i < myWords.Length; i++)
            {
                if (myWords[i] == ' ')
                {
                    char.ToUpper(myWords[i + 1]);
                }
            }
            var upperWords = myWords;

            for (var i = 0; i < upperWords.Length; i++)
            {
                if (upperWords[i] == ' ')
                {
                    upperWords.Remove(i, 1);
                }
            }
            var pascal = upperWords;


            return pascal;*/

        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            var wordArr = aWord.ToLower().ToCharArray();

            int result = 0;

            foreach (var letter in wordArr)
            {
                if (letter == 'a')
                    result++;
                else if (letter == 'e')
                    result++;
                else if (letter == 'i')
                    result++;
                else if (letter == 'o')
                    result++;
                else if (letter == 'u')
                    result++;
            }
            return result;
        }
    }


    internal static class Program
    {
        private static void Main()
        {
            var result = WorkingWithText.PascalConverter("I AM LEGEND  ");
            Console.WriteLine(result);
            // Method intentionally left empty.
        }
    }
}
