using System;
using System.Collections.Generic;

namespace String_segmentation_OR_Word_Break_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "applepenapple";
            List<string> wordDict = new List<string>()
            {
                "apple","pen"
            };

            Console.WriteLine(WordBreak(s, wordDict));

            Console.WriteLine(DPWordBreak(s, wordDict));
        }

        static bool WordBreak(string s, IList<string> wordDict)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            int length = s.Length;
            for (int i = 1; i <= length; i++)
            {
                if (wordDict.Contains(s.Substring(0, i)) && WordBreak(s.Substring(i), wordDict)) return true;
            }

            return false;
        }

        static bool DPWordBreak(string s, IList<string> wordDict)
        {
            int length = s.Length;
            bool[] dp = new bool[length + 1];
            dp[0] = true;

            for (int len = 1; len <= length; len++)
            {
                for (int i = 0; i < len; i++)
                {
                    if (dp[i] && wordDict.Contains(s.Substring(i, len -i)))
                    {
                        dp[len] = true; break;
                    }
                }
            }
            return dp[length];
        }
    }
}
