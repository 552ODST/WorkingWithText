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
            // split the input based off the hyphens
            var splitNum = hyphenNum.Split('-');
            var numSplitList = new List<int>();
            var result = true;

            // check each number in my split by hypen string array 
            foreach (var num in splitNum)
                // using tryparse to check to see if each value inputted was a valid number
                if (int.TryParse(num, out var parseInt))
                    numSplitList.Add(parseInt);
                // if it wasn't then we return false
                else
                    return false;

            // create a variable to check the difference between the 1st and 2nd value 
            var intDifference = numSplitList[0] - numSplitList[1];

            // make sure the difference is 1 or -1
            if (Math.Abs(intDifference) != 1)
                // If it's not, then that means it can't be consecutive
                result = false;

            // now we loop through the rest of the array to make sure they're consecutive too
            for (var i = 0; i < numSplitList.Count - 1; i++)
                // make sure that the difference stays consistent
                if (numSplitList[i] - numSplitList[i + 1] != intDifference)
                {
                    result = false;
                    break;
                }
            // if the difference stays consistant the whole way through, we chillin
            return result;
        }


        // 2- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            // splits list by hyphen
            var splitNum = hyphenNum.Split('-');
            var intList = new List<int>();
            var result = true;

            // checks to see if inputs are valid
            foreach (var num in splitNum)
                if (int.TryParse(num, out var parseInt))
                    intList.Add(parseInt);
                // if they're not then, that's as far as we go
                else
                    return false;

            // now we cross check the count of distinct numbers with the count in the list
            // if they dont match then there are duplicates, and we return false
            result = intList.Distinct().Count() != intList.Count;

            return result;
        }


        // 3- Write a method that accepts a string of a time 24-hour time format
        // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
        // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
        // consider it as False. Make sure that its returns false if any letters are passed.
        public static bool IsValidTime(string hyphenNum)
        {
            var result = true;

            // check the input to see if it contains stuff, if not return false
            if (string.IsNullOrWhiteSpace(hyphenNum))
            {
                result = false;
            }
            // checks if first value is a 0, 1, or 2 because those are the only valid inital values for 24hr time
            else if (hyphenNum[0] == '0' || hyphenNum[0] == '1' || hyphenNum[0] == '2')
            {
                // check to see if the given string is in the proper format 
                if (hyphenNum.Contains(':'))
                {
                    var times = hyphenNum.Split(':');
                    // now we make sure we don't crash by checking for valid number inputs
                    var validHour = int.TryParse(times[0], out var hour);
                    var validMin = int.TryParse(times[1], out var min);

                    // if both are valid numbers then we'll check to see that they fall into the 24hr time format range
                    if (validHour && validMin)
                    {
                        if (times.Length != 2)
                            result = false;
                        else if (hour < 0 || hour > 23)
                            result = false;
                        else if (min < 0 || min > 59)
                            result = false;
                    }
                    // if inputs are not valid numbers
                    else result = false;
                }
                // if there is no : as requested
                else result = false;
            }
            // if the first value isn't a 1, 2 or 3
            else
            {
                result = false;
            }
            // as long as result was never changed to false, we chillin
            return result;

        }

        // 4- Write a method that accepts a string of a few words separated by a space. Use the
        // words to create a variable name with PascalCase. For example, if the user types: "number
        // of students", return "NumberOfStudents". Make sure that the program is not dependent on
        // the input. So, if the user types "NUMBER OF STUDENTS", the program should still return "NumberOfStudents".
        // Trim off unneeded spaces.
        public static string PascalConverter(string aFewWords)
        {
            // First check if there's something to work off of, if not we're done!
            if (string.IsNullOrWhiteSpace(aFewWords))
            {
                return null;
            }

            // then we make some variables, making sure to trim any spaces off out input
            // to be sure they don't get in the way of our splitting
            var myFewWords = aFewWords.Trim(' ');
            var inputPascal = string.Empty;

            // split the string into an array based off the spaces beteen words
            foreach (var word in myFewWords.Split(' '))
            {
                // capitalize the first char of each word and lower the rest
                var capitalWord = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                // and put them back together! and add them to our empty string
                inputPascal += capitalWord;
            }
            return inputPascal;
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            // make sure our input is all in lowercase format
            var wordArr = aWord.ToLower().ToCharArray();
            int result = 0;

            // check to see if any char in our array matches a vowel
            foreach (var letter in wordArr)
            {
                if (letter == 'a')
                    // if they do then we increase our result by 1
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
            // Method intentionally left empty.
        }
    }
}
