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
            string str = Console.ReadLine();
            bool flag = Question2.CheckIfPangram(str);
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
            int[] nums = { 1, 2, 3, 1, 1, 3 };
            int gp = Question3.NumIdenticalPairs(nums);
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
            String merged = Program5.merge(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Question 6
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = Program6.ToGoatLatin(sentence);
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
                int x = 0;
                int y = 0;
                // converting the string to char array
                char[] array = moves.ToCharArray();
                //Loop through the entire string
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'R')
                        x++;
                    else if (array[i] == 'L')
                        x--;
                    else if (array[i] == 'U')
                        y++;
                    else if (array[i] == 'D')
                        y--;
                }
                return (x == 0 && y == 0);
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
                bool[] isUsed = new bool[26];
                int ai = (int)'a';
                int total = 0;
                //converting the string to lower case
                //reading individual characters in the string using CharEnumerator method and moving to next character using MoveNext method
                for (CharEnumerator en = str.ToLower().GetEnumerator(); en.MoveNext();)
                {
                    int d = (int)en.Current - ai;
                    if (d >= 0 && d < 26)
                        if (!isUsed[d])
                        {
                            isUsed[d] = true;
                            total++;
                        }
                }
                return (total == 26);
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
        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Initialize the output in variable ans
                int ans = 0;
                //Condiser all possible pairs and check their sums
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] == nums[j])
                        {
                            ans++;
                        }
                    }
                }
                return ans;
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
        public static int PivotIndex(int[] nums)
        {
            try
            {
                // Count the prefix sum of nums: prefix[i] = nums[0] + nums[1] + .. + nums[i - 1]
                int len = nums.Length;
                int sum = 0;
                int[] prefix = new int[len];
                for (int i = 0; i < len; i++)
                {
                    prefix[i] = sum;
                    sum += nums[i];
                }

                //Find the pivot using the sum
                for (int i = 0; i < len; i++)
                {
                    if (prefix[i] == prefix[len - 1] - prefix[i] - nums[i] + nums[len - 1])
                    {
                        return i;
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;

            }
        }

    }
    class Program5
    {
        //function to merge 2 strings alternatively
        public static string merge(string word1, string word2)
        {
            try
            {
                //to store the output
                string result = "";

                //for every index in the strings
                for (int i = 0; i < word1.Length || i < word2.Length; i++)
                {
                    //first choose the ith character in the first string if exists
                    if (i < word1.Length)
                        result += word1[i];
                    //Now choose the ith character in the second string if exists
                    if (i < word2.Length)
                        result += word2[i];
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }
    }
    class Program6
    {
        // function to convert the given sentence to Goat Latin 
        public static string ToGoatLatin(string sentence)
        {
            try
            {
                //removing the spaces in the given sentence
                var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string suffix = "a", 
                result = "";
                var vowels = new List<char>() { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
                // repeat the following process for every word in the sentence
                foreach (var word in words)
                {
                    //if the first letter of the first word is vowel then append 'ma' and 'a' 
                    if (vowels.Any(x => x == word[0]))
                    {
                        result += word + "ma" + suffix + " ";
                    }
                    //if the first letter of the first word is not a vowel then append the 'first letter', 'ma' and 'a'
                    else
                    {
                        result += word.Substring(1) + word[0] + "ma" + suffix + " ";
                    }

                    suffix += "a";

                }

                return result.Substring(0, result.Length - 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}




