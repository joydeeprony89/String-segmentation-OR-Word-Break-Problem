using System;
using System.Collections.Generic;

namespace String_segmentation_OR_Word_Break_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aaaaaab"; // applepenapple // aaaaaab
            List<string> wordDict = new List<string>()
            {
                "a","aa","aaa","b" // "apple","pen" "a","aa","aaa"
            };

            Program p = new Program();
            Console.WriteLine(p.WordBreak(s, wordDict));

            Console.WriteLine(DPWordBreak(s, wordDict));
        }

        // using bottom up approach
        static bool DPWordBreak(string s, IList<string> wordDict)
        {
            int length = s.Length;
            bool[] dp = new bool[length + 1];
            dp[0] = true;

            for (int len = 1; len <= length; len++)
            {
                for (int i = 0; i < len; i++)
                {
                    string left = s.Substring(i, len - i);
                    if (dp[i] && wordDict.Contains(left))
                    {
                        dp[len] = true; break;
                    }
                }
            }
            return dp[length];
        }

        // using top down approach.
        Dictionary<string, bool> hash = new Dictionary<string, bool>();
        bool WordBreak(string s, IList<string> wordDict)
        {
            if (wordDict.Contains(s)) return true;
            if (hash.ContainsKey(s))
                return hash[s];
            for(int i = 1; i <= s.Length - 1; i++)
            {
                string left = s.Substring(0, i);
                if (wordDict.Contains(left) && WordBreak(s.Substring(i), wordDict)) 
                {
                    hash.Add(s, true);
                    return true;
                }
            }
            hash.Add(s, false);
            return false;
        }
    }
}
