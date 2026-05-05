using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4
{
    public class Lambda
    {
        public Lambda(){}

        public List<int> FilterOddNums(List<int> nums)
        {
            var oddNums = nums.Where(n => n % 2 != 0);
            return oddNums.ToList();
        }
        public int middleNum(List<int> nums)
        {
            var middle = nums.OrderBy(n => n).Skip(nums.Count / 2).First();
            return middle;
        }
        public List<string> SortAlphabetically(List<string> words, string order)
        {
            var sortedWords = new List<string>();
            if (order == "desc")
            {
                return words.OrderByDescending(w => w).ToList();
            }
            else
            {
                return words.OrderBy(w => w).ToList();
            }
        }
        public int SumOfEven(List<int> nums)
        {
            var sum = nums.Where(n => n % 2 == 0).Sum();
            return sum;
        }
        public int FactorialLambda(int n)
        {
            Func<int, int> factorial = null;
            factorial = (x) => x == 0 ? 1 : x * factorial(x - 1);
            return factorial(n);
        }
        public void SumMultiply(List<int> nums)
        {
            var sum = nums.Sum();
            var product = nums.Aggregate((a, b) => a * b);
            Console.WriteLine($"Sum: {sum}, Product: {product}");
        }
        public List<int> squareNums(List<int> nums)
        {
            var squaredNums = nums.Select(n => n * n);
            return squaredNums.ToList();
        }
        public List<string> orderByLength(List<string> words)
        {
            return words.OrderBy(w => w.Length).ToList();
        }
        public int CountWordsLambda(string sequence)
        {
            var count = sequence.Split(' ').Count(w => !string.IsNullOrEmpty(w));
            return count;
        }
        public string getNotEmptyString(List<string> strings)
        {
            var notEmptyString = strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
            return notEmptyString;
        }
        public bool isAllfirstBigCase(List<string> words)
        {
            return words.All(w => char.IsUpper(w[0]));
        }
        public int secondLargest(List<int> nums)
        {
            var sL = nums.OrderByDescending(n => n).Skip(1).First();
            return sL;
        }
        public int LargestEven(List<int> nums)
        {
            var largestEven = nums.Where(n => n % 2 == 0).Max();
            return largestEven;
        }
    }
}