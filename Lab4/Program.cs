using System;
using Lab4;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Lambda lambda = new Lambda();

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<string> words = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };

            Console.WriteLine("Odd Numbers: " + string.Join(", ", lambda.FilterOddNums(nums)));
            Console.WriteLine("Middle Number: " + lambda.middleNum(nums));
            Console.WriteLine("Sorted Words (asc): " + string.Join(", ", lambda.SortAlphabetically(words, "asc")));
            Console.WriteLine("Sorted Words (desc): " + string.Join(", ", lambda.SortAlphabetically(words, "desc")));
            Console.WriteLine("Sum of Even Numbers: " + lambda.SumOfEven(nums));
            Console.WriteLine("Factorial of 5: " + lambda.FactorialLambda(5));
            lambda.SumMultiply(nums);
            Console.WriteLine("Squared Numbers: " + string.Join(", ", lambda.squareNums(nums)));
            Console.WriteLine("Words Ordered by Length: " + string.Join(", ", lambda.orderByLength(words)));
            Console.WriteLine("Count of Words in Sequence: " + lambda.CountWordsLambda("This is a sample sequence of words."));
            Console.WriteLine("Second Largest Number: " + lambda.secondLargest(nums));
            Console.WriteLine("Largest Even Number: " + lambda.LargestEven(nums));
            List<string> sentenceWithAllBig= new List<string> { "Word1", "Word2", "Word3" };
            List<string> sentenceWithOneSmall= new List<string> { "Word1", "word2", "Word3" };
            Console.WriteLine("Is All First Characters Upper Case: " + lambda.isAllfirstBigCase(sentenceWithAllBig));
            Console.WriteLine("Is All First Characters Upper Case: " + lambda.isAllfirstBigCase(sentenceWithOneSmall));
             List<string> sentenceWithEmptyStrings= new List<string> { " ", null, "Word3", "Word4" };
            Console.WriteLine("First not empty string: " + lambda.getNotEmptyString(sentenceWithEmptyStrings));
        }
    }
}