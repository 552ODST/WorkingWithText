using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace WorkingWithText
{
    public static class WorkingWithText
    {
        // 1- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            bool result = false;
            try
            {
                List<int> nums = hyphenNum.Split('-').Select(int.Parse).ToList();

                for (int i = 0; i < hyphenNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        try
                        {
                            if (i != j)
                            {
                                if (Convert.ToInt32(nums[i]) == Convert.ToInt32(nums[j]))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
                return result;
            }
           
            //char[] hyphenCheck = hyphenNum.ToCharArray();
            //result = Char.IsNumber(hyphenCheck[0]);
            //result = Char.IsNumber(hyphenCheck[hyphenCheck.Length - 1]);
            //for (int i = 0; i < hyphenCheck.Length; i++)
            //{
            //    try
            //    {
            //        if (Convert.ToString(hyphenCheck[i]) != "-" || Char.IsNumber(hyphenCheck[0]) == false)
            //        {
            //            result = false;
            //            break;
            //        }
            //        else if (hyphenCheck[i] == hyphenCheck[i + 1])
            //        {
            //            result = false;
            //            break;
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
            return result;
        }

        // 2- Write a method that accepts a string of numbers separated by a hyphen. If the input 
        // is NOT in the correct format OR is NOT consecutive then return bool False. If the format 
        // is correct AND the numbers are consecutive, return bool True. For
        // example, if the input is "5-6-7-8-9" or "20-19-18-17-16", return bool True.
        // Do not use .Sort, it will cause the test to pass when it actually does not.
        public static bool IsConsecutive(string hyphenNum)
        {
            bool isConsecutiveAcending = false;
            bool isConsecutiveDecending = false;

            try
            {
                List<int> nums = hyphenNum.Split('-').Select(int.Parse).ToList();
                isConsecutiveAcending = !nums.Select((i, j) => i - j).Distinct().Skip(1).Any();
                isConsecutiveDecending = !nums.Select((i, j) => i + j).Distinct().Skip(1).Any(); 
            }
            catch
            {
                return false;
            }
            if (isConsecutiveAcending == true || isConsecutiveDecending == true)
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
            bool result = false;
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(hyphenNum);
                if(hyphenNum == dt.ToString("HH:mm"))
                {
                    result = true;
                }
                
            }
            catch
            {
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
            if(aFewWords == "" || aFewWords == null)
            {
                return aFewWords;
            }
            string lowerCase = aFewWords.ToLower();
            string[] separated = aFewWords.Split(' ');
            string temp = "";
            string result = "";
            for (int i = 0; i < separated.Count(); i++)
            {
                temp = separated[i];
                if (temp.Length > 1)
                {
                    result += char.ToUpper(temp[0]) + temp.Substring(1).ToLower();
                }
                else
                {
                    result += temp.ToUpper();
                }
            }
            return result;
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
          public static int VowelCounter(string aWord)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            aWord = aWord.ToLower();
            char[] characters = aWord.ToCharArray();
            int vowelCount = 0;
            aWord = aWord.ToLower();

            for(int i = 0; i<characters.Length; i++)
            {
                for(int j = 0; j<vowels.Length; j++)
                {
                    if(vowels[j] == characters[i])
                    {
                        vowelCount++;
                    }
                }
            }
            return vowelCount;
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
