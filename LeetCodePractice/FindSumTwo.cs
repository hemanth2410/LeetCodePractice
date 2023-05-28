using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    public class FindSumTwo
    {
        public int[] SumTwo(int[] nums, int target)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if(result.Contains(complement))
                {
                    return new int[] {Array.IndexOf(nums, complement), i};
                }
                result.Add(nums[i]);
            }
            return new int[0];
        }
    }
}
