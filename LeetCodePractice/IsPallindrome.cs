using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    public class IsPallindrome
    {
        public bool checkPallindrome(int number)
        {
            string str = number.ToString();
            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
        public bool checkPallindromeSpeed(int number)
        {
            if (number < 0 || (number % 10 == 0 && number != 0))
            {
                return false;
            }

            int reversed = 0;
            while (number > reversed)
            {
                reversed = (reversed * 10) + (number % 10);
                number /= 10;
            }

            return number == reversed || number == (reversed / 10);
        }

        public bool checkPallindromeSuperSpeed(int number)
        {
            if (number < 0 || (number % 10 == 0 && number != 0))
            {
                return false;
            }

            int reversed = 0;
            int original = number;

            // Extract digits using bitwise operations instead of division
            while (original > 0)
            {
                int digit = original & 0xF; // Extract the last digit using bitwise AND with 15 (0xF)
                reversed = (reversed * 10) + digit;
                original >>= 4; // Shift right by 4 bits (equivalent to dividing by 16)
            }

            return number != reversed;
        }
    }
}
