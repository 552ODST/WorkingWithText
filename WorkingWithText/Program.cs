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
            var splitNum = hyphenNum.Split('-');
            var numSplitList = new List<int>();
            bool result = true;
            
            //check each number in the string
            foreach (var num in splitNum)
            {
                //using tryparse to check to see if inputted values are  valid numbers
                if(int.TryParse(num, out var parseInt))
                {
                    numSplitList.Add(parseInt);
                }
                //return false
                else
                {
                    return false;
                }
            }

            //check inital difference
            //make sure that the inital difference is the same for the rest of the numbers

            var intDifference = numSplitList[0] - numSplitList[1];

            //loop through list of numbers
            for (var i = 0; i < numSplitList.Count - 1; i++)
            {
                if (Math.Abs(numSplitList[i] - numSplitList[i + 1]) != 1)
                {
                    return false;
                }
            }
            return result;
        }

        // 2- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            // splits lists by hyphen
            var splitNum = hyphenNum.Split('-');
            var intList = new List<int>();
            bool result = true;

            //checks for valid imput
            foreach (var num in splitNum)
            {
                if (int.TryParse(num, out var parseInt))
                {
                    intList.Add(parseInt);
                }
                else
                {
                    return false;
                }
            }

            //
            if (intList.Distinct().Count() != intList.Count )
            {
                return true;
            }
            else
            {
                result = false;
            }
            return result;

            
        }

        // 3- Write a method that accepts a string of a time 24-hour time format
        // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
        // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
        // consider it as False. Make sure that its returns false if any letters are passed.
        public static bool IsValidTime(string hyphenNum)
        {
            var result = true;
            //checks the imput to see if there is stuff, if not return false
            if (string.IsNullOrWhiteSpace(hyphenNum))
            {
                result = false;
            }
            //checks the first value if it's a 0,1, or 2 because those are the only values for 24 hour time
            else if (hyphenNum[0] == '0' || hyphenNum[0] == '1' || hyphenNum[0] == '2')
            {
                //checks if the string is in the proper format
                if (hyphenNum.Contains(':'))
                {
                    var times = hyphenNum.Split(':');
                    var validHour = int.TryParse(times[0], out var hour);
                    var validMin = int.TryParse(times[1], out var min);

                    if (validHour && validMin)
                    {
                        //along with 24hr time
                        if (times.Length != 2)
                            result = false;
                        else if (hour < 0 || hour > 23)
                            result = false;
                        else if (min < 0 || min > 59)
                            result = false;
                        else
                            return true;
                    }
                    else result = false;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
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

            var seperatedWords = aFewWords.Trim().Split(' ');

            //capitlize first letter of each word

            var result = string.Empty;

            foreach (var eachWord in seperatedWords)
            {
                //make every letter lowercase
                var trimmedWord = eachWord.Trim().ToLower();

                //makes the first letter uppercase and assigns a new variable due to string memory immutability
                var trimmedCap = trimmedWord[0].ToString().ToUpper() + trimmedWord.Substring(1);

                //list of capped words
                result += trimmedCap;
            }
            return result;
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            var wordArr = aWord.ToLower().ToCharArray();

            char[] vowelArray = { 'a', 'i', 'u', 'e', 'o' };
            int result = 0;
            //checks for vowels
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
            // Method intentionally left empty.
        }
    }
}
