using System.Collections.Generic;

namespace TakeawayCodingTask
{
    public class Task_01
    {
        /// <summary>
        /// From 1 to limit inclusive, counting up
        /// On each iteration, 
        ///     When the number is divisible by 3 return the string "Fizz"
        ///     When the number is divisible by 5 return the string "Buzz"
        ///     When the number is divisable by both 3 & 5 return the string "Fizz buzz"
        ///     otherwise return the number
        ///     e.g. When the limit is 16, the function will return 1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz, 16
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<string> FizzBuzz(int limit)
        {
			var result = new List<string>();
            for(var i = 1; i<= limit; i++){
                if (i % 3== 0 && i % 5 ==0){
                    result.Add("FizzBuzz");
                }else if (i % 3== 0){
                    result.Add("Fizz");
                }else if (i % 5== 0){
                    result.Add("Buzz");
                }else{
                    result.Add(i.ToString());
                }
            }
            return result;
        }
    }
}