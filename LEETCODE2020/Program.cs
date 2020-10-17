using LEETCODE2020.Models;
using System;

namespace LEETCODE2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution s = new Solution();
            //   s.ClimbStairs(3);

            //string excelColumn = "AA";
            //s.TitleToNumber(excelColumn);
            // var result =s.convertNumberToAnotherBase(29, 2);
            // var result = s.ConvertToTitle(27);
            // var result = s.ConvertToTitle(1);
            //var result = s.ConvertToTitle(26);
            //Console.WriteLine(result.ToString());

            //var result = s.ConvertToTitle(28);
            //Console.WriteLine(result.ToString());

            //var result2 = s.ConvertToTitle(52);
            //Console.WriteLine(result2.ToString());
            //string[] strs = { "flower", "flow", "flight" };
            //var result = s.LongestCommonPrefix(strs);
            //var i = "A man, a plan, a canal: Panama";
            //var i = "aba";
            //var i = ".";
            //var i = ".,";
            //var result = s.IsPalindrome(i);
            // int[] i = { 2, 3, 1, 1, 4 };
            //int[] i = { 1, 2 };
            //int[] i = {1, 1, 1, 1};
            //var result = s.Jump(i);
            //var i = "the sky is blue";
            // var result = s.ReverseWords(i);
            //var result = s.findPerm("ID", 3);
            //int[][] i = new int[][]{ new int[]{ 3, 7, 8 }, new int[] { 9, 11, 13 }, new int[] { 15, 16, 17 } };

            //int[][] i = new int[][] { new int[] { 1, 10, 4, 2 }, new int[] { 9, 3, 8, 7 }, new int[] { 15, 16, 17, 12 } };
            //var result = s.LuckyNumbers(i);
            //Console.WriteLine(result.ToString());

            ListNode l1head = new ListNode { val = 2 };

            //ListNode l10 = new ListNode { val = 2 };
            //ListNode l11 = new ListNode { val = 4 };
            //ListNode l12 = new ListNode { val = 3 };

            //l10.next = l11;
            //l11.next = l12;
            //l12.next = null;


            //ListNode l20 = new ListNode { val = 5 };
            //ListNode l21 = new ListNode { val = 6 };
            //ListNode l22 = new ListNode { val = 4 };

            //l20.next = l21;
            //l21.next = l22;
            //l22.next = null;


            ListNode l10 = new ListNode { val = 9 };

            l10.next = null;


            ListNode l20 = new ListNode { val = 1 };
            ListNode l21 = new ListNode { val = 9 };
            ListNode l22 = new ListNode { val = 9 };

            l20.next = l21;
            l21.next = l22;
            l22.next = null;

            var result =  s.AddTwoNumbers(l10, l20);
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}