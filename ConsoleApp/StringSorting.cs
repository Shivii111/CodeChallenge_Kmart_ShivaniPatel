using System;
using System.Collections;

namespace ConsoleApp
    {
    public class StringSorting
    {
        static void Main(string[] args)
        {
            StringSorting str = new StringSorting();
            Console.WriteLine("Input:");
            string input = Console.ReadLine();

            Console.WriteLine("Longest increasing subsequence :" + str.findLongestIncreasingSubSeq(input));
        }

        // find longest increasing substring from given input
        public String findLongestIncreasingSubSeq(String? input)
        {
            String[] inputArray = input.Split(' '); // Array to store an individual value from input string into an array
            ArrayList currentArrayList = new ArrayList();  // Arraylist to store each increasing substring
            String subString = "";

            for (int i = 1; i < inputArray.Length; i++)
            {
                double next = double.Parse(inputArray[i]);
                double prev = double.Parse(inputArray[i - 1]);

                // to create a incremental sub string sequence
                if (next > prev)
                {
                    if (subString.Length == 0)
                    {
                        subString = inputArray[i - 1] + " " + inputArray[i];
                    }
                    else
                    {
                        subString = subString + " " + inputArray[i];
                    }
                    currentArrayList.Add(subString);

                }
                else if (next < prev)
                {
                    subString = "";

                }

            }

            string[] currentArray = (string[])currentArrayList.ToArray(typeof(string)); // Converted an arraylist into array of string

            int[][] jArray = currentArray.Select(t => t.Split(' ').Select(y => int.Parse(y)).ToArray()).ToArray(); // Created jagged array of int from a currentArray of string

            int lengthOfSubString = 1;
            string longestSubString = "";

            // To find longest increasing sub string from the list of sub strings

            for (int j = 0; j < jArray.Length; j++)
            {

                if (lengthOfSubString < jArray[j].Length)
                {
                    lengthOfSubString = jArray[j].Length;
                    longestSubString = string.Join(" ", jArray[j]);
                }

            }

            return longestSubString;

        }

    }
}


