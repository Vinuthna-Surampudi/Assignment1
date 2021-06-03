using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = Question1.JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }
            Console.WriteLine();

            // Question2
            Console.WriteLine(" Q2: Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = Question2.CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3
            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = Question3.NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);

            //Question 4
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = Question4.PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = Question5.MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Question 6
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = Question6.ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }
    }
    class Question1
    {
        //function to check if the robot comes to the initial point or not
        // bool returns true if the string is pangram else false
        public static bool JudgeCircle(string moves)
        {
            try
            {
                // Initial coordinates
                int a = 0;
                int b = 0;
                // converting the string to char array
                char[] xyz = moves.ToCharArray();
                //Loop through the entire string
                for (int i = 0; i < xyz.Length; i++)
                {
                    if (xyz[i] == 'R')
                        a++;
                    else if (xyz[i] == 'L')
                        a--;
                    else if (xyz[i] == 'U')
                        b++;
                    else if (xyz[i] == 'D')
                        b--;
                }
                return (a == 0 && b == 0);
            }
            catch (Exception)
            {
                throw;
            }
        }
            
    }
    public class Question2
    {
        //function used to check if the given sentence is pangram or not
        // bool returns true if the string is pangram else false
        public static bool CheckIfPangram(string str)
        {
            try
            {
                bool[] x = new bool[26];
                int y = (int)'a';
                int result = 0;
                //converting the string to lower case
                //reading individual characters in the string using CharEnumerator method and moving to next character using MoveNext method
                for (CharEnumerator cher = str.ToLower().GetEnumerator(); cher.MoveNext();)
                {
                    int i = (int)cher.Current - y;
                    if (i >= 0 && i < 26)
                        if (!x[i])
                        {
                            x[i] = true;
                            result++;
                        }
                }
                return (result == 26);
            }

            catch (Exception)
            {
                throw;
            }

        }
    }
    class Question3
    {
        //function to find the number of identical pairs in the given array
        public static int NumIdenticalPairs(int[] numbers)
        {
            try
            {
                // Initialize the output in variable ans
                int result = 0;
                //Condiser all possible pairs and check their sums
                for (int x = 0; x < numbers.Length - 1; x++)
                {
                    for (int y = x + 1; y < numbers.Length; y++)
                    {
                        if (numbers[x] == numbers[y])
                        {
                            result++;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    class Question4
    {
        //function to find the pivot index
        public static int PivotIndex(int[] numbers)
        {
            try
            {
                // Count the prefix sum of nums: prefix[i] = nums[0] + nums[1] + .. + nums[i - 1]
                int l = numbers.Length;
                int z = 0;
                int[] p = new int[l];
                for (int i = 0; i < l; i++)
                {
                    p[i] = z;
                    z += numbers[i];
                }

                //Find the pivot using the sum
                for (int i = 0; i < l; i++)
                {
                    if (p[i] == p[l - 1] - p[i] - numbers[i] + numbers[l - 1])
                    {
                        return i;
                    }
                }

                return -1;
            }
            catch (Exception exp)
            {
                Console.WriteLine("An error occured: " + exp.Message);
                throw;

            }
        }

    }
    class Question5
    {
        //function to merge 2 strings alternatively
        public static string MergeAlternately(string word1, string word2)
        {
            try
            {
                //to store the output
                string output = "";

                //for every index in the strings
                for (int i = 0; i < word1.Length || i < word2.Length; i++)
                {
                    //first choose the ith character in the first string if exists
                    if (i < word1.Length)
                        output += word1[i];
                    //Now choose the ith character in the second string if exists
                    if (i < word2.Length)
                        output += word2[i];
                }
                return output;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                throw;

            }
        }
    }
    class Question6
    {
        // function to convert the given sentence to Goat Latin 
        public static string ToGoatLatin(string sentence)
        {
            try
            {
                //removing the spaces in the given sentence
                var list_of_words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string s = "a", 
                output = "";
                var vowels = new List<char>() { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
                // repeat the following process for every word in the sentence
                foreach (var word in list_of_words)
                {
                    //if the first letter of the first word is vowel then append 'ma' and 'a' 
                    if (vowels.Any(z => z == word[0]))
                    {
                        output += word + "ma" + s + " ";
                    }
                    //if the first letter of the first word is not a vowel then append the 'first letter', 'ma' and 'a'
                    else
                    {
                        output += word.Substring(1) + word[0] + "ma" + s + " ";
                    }

                    s += "a";

                }

                return output.Substring(0, output.Length - 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}




