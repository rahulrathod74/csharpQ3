using System;
using System.Collections.Generic;

class Program
{
    // 1. Sum of Array Elements
    public static int ArraySum(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return sum;
    }

    // 2. Find the Missing Number
    public static int FindMissNumber(int[] arr, int n)
    {
        int sum = n * (n + 1) / 2;
        foreach (int num in arr)
        {
            sum -= num;
        }
        return sum;
    }

    // 3. Reverse an Array in Place
    public static void ReverseArray(int[] arr)
    {
        int start = 0;
        int end = arr.Length - 1;
        while (start < end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }

    // 4. Find First Non-Repeating Character in a String
    public static char FirstUniqueChar(string str)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char ch in str)
        {
            if (charCount.ContainsKey(ch))
                charCount[ch]++;
            else
                charCount[ch] = 1;
        }
        foreach (char ch in str)
        {
            if (charCount[ch] == 1)
                return ch;
        }
        return '\0';  // Return null character if no unique character is found
    }

    // 5. Find the Majority Element
    public static int MajorityElement(int[] arr)
    {
        int candidate = -1;
        int count = 0;

        foreach (int num in arr)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return candidate;
    }

    // 6. Rotate an Array by K Positions
    public static void RotateArray(int[] arr, int k)
    {
        k = k % arr.Length;
        ReverseArrayRange(arr, 0, arr.Length - 1);
        ReverseArrayRange(arr, 0, k - 1);
        ReverseArrayRange(arr, k, arr.Length - 1);
    }

    private static void ReverseArrayRange(int[] arr, int start, int end)
    {
        while (start < end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }

    // 7. Find the Longest Consecutive Sequence
    public static int LongestConsecutive(int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int longest = 0;

        foreach (int num in arr)
        {
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longest = Math.Max(longest, currentStreak);
            }
        }
        return longest;
    }

    // 8. Find K-th Smallest Element in an Unsorted Array
    public static int KthSmallestElement(int[] arr, int k)
    {
        Array.Sort(arr);
        return arr[k - 1];
    }

    // 9. Find the Maximum Product of Three Numbers
    public static int MaxProductOfThree(int[] arr)
    {
        Array.Sort(arr);
        int n = arr.Length;
        return Math.Max(arr[n - 1] * arr[n - 2] * arr[n - 3], arr[0] * arr[1] * arr[n - 1]);
    }

    // 10. Merge Two Sorted Arrays
    public static int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
        int i = 0, j = 0, k = 0;
        int[] result = new int[arr1.Length + arr2.Length];

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
            {
                result[k++] = arr1[i++];
            }
            else
            {
                result[k++] = arr2[j++];
            }
        }

        while (i < arr1.Length)
        {
            result[k++] = arr1[i++];
        }

        while (j < arr2.Length)
        {
            result[k++] = arr2[j++];
        }

        return result;
    }

    // 11. Find Pair with Given Sum in a Sorted Array
    public static int[] TwoSumSorted(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int sum = arr[left] + arr[right];
            if (sum == target)
            {
                return new int[] { left, right };
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return new int[] { -1, -1 }; // Return -1 if no such pair is found
    }

    // 12. Find the Peak Element in an Array
    public static int FindPeakElement(int[] arr)
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                return arr[i];
            }
        }
        return arr[0] > arr[1] ? arr[0] : arr[arr.Length - 1]; // Peak is at the boundary
    }

    // 13. Check If an Array is a Subset of Another
    public static bool IsSubset(int[] arr1, int[] arr2)
    {
        HashSet<int> set = new HashSet<int>(arr1);
        foreach (int num in arr2)
        {
            if (!set.Contains(num))
            {
                return false;
            }
        }
        return true;
    }

    // 14. Trapping Rain Water
    public static int TrapRainWater(int[] height)
    {
        int n = height.Length;
        if (n == 0) return 0;

        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        leftMax[0] = height[0];
        rightMax[n - 1] = height[n - 1];

        for (int i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }
        for (int i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        int waterTrapped = 0;
        for (int i = 0; i < n; i++)
        {
            waterTrapped += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        return waterTrapped;
    }

    // 15. Find the Smallest Window in a String Containing All Characters of Another String
    public static string MinWindowSubstring(string s, string t)
    {
        if (s.Length == 0 || t.Length == 0) return "";

        Dictionary<char, int> targetCount = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (targetCount.ContainsKey(c))
                targetCount[c]++;
            else
                targetCount[c] = 1;
        }

        int start = 0, end = 0, minLength = int.MaxValue, minStart = 0;
        int matchCount = 0;

        while (end < s.Length)
        {
            char rightChar = s[end];
            if (targetCount.ContainsKey(rightChar))
            {
                targetCount[rightChar]--;
                if (targetCount[rightChar] >= 0)
                    matchCount++;
            }
            while (matchCount == t.Length)
            {
                if (minLength > end - start + 1)
                {
                    minLength = end - start + 1;
                    minStart = start;
                }
                char leftChar = s[start];
                if (targetCount.ContainsKey(leftChar))
                {
                    targetCount[leftChar]++;
                    if (targetCount[leftChar] > 0)
                        matchCount--;
                }
                start++;
            }
            end++;
        }

        return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
    }

    // 16. Find All Anagrams of a String in Another String
    public static List<int> FindAnagrams(string s, string t)
    {
        List<int> result = new List<int>();
        if (s.Length < t.Length) return result;

        Dictionary<char, int> tCount = new Dictionary<char, int>();
        Dictionary<char, int> sCount = new Dictionary<char, int>();

        foreach (char c in t)
        {
            if (tCount.ContainsKey(c))
                tCount[c]++;
            else
                tCount[c] = 1;
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (sCount.ContainsKey(s[i]))
                sCount[s[i]]++;
            else
                sCount[s[i]] = 1;
        }

        if (AreDictionariesEqual(tCount, sCount))
            result.Add(0);

        for (int i = t.Length; i < s.Length; i++)
        {
            char addChar = s[i];
            char removeChar = s[i - t.Length];

            sCount[addChar]++;
            sCount[removeChar]--;

            if (AreDictionariesEqual(tCount, sCount))
                result.Add(i - t.Length + 1);
        }

        return result;
    }

    private static bool AreDictionariesEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        foreach (var kvp in dict1)
        {
            if (!dict2.ContainsKey(kvp.Key) || dict2[kvp.Key] != kvp.Value)
                return false;
        }
        return true;
    }

    // 17. Find the K Closest Numbers to a Target
    public static int[] KClosestNumbers(int[] arr, int k, int x)
    {
        Array.Sort(arr, (a, b) => Math.Abs(a - x).CompareTo(Math.Abs(b - x)));
        int[] result = new int[k];
        Array.Copy(arr, result, k);
        return result;
    }

    // 18. Find Duplicates in an Array
    public static List<int> FindDuplicates(int[] arr)
    {
        List<int> duplicates = new List<int>();
        HashSet<int> set = new HashSet<int>();

        foreach (int num in arr)
        {
            if (!set.Add(num))
                duplicates.Add(num);
        }
        return duplicates;
    }

    // 19. Find the Longest Palindromic Substring
    public static string LongestPalindrome(string s)
    {
        if (s.Length < 1) return "";

        int start = 0, maxLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            // Odd length palindrome
            int len1 = ExpandAroundCenter(s, i, i);
            // Even length palindrome
            int len2 = ExpandAroundCenter(s, i, i + 1);

            int len = Math.Max(len1, len2);
            if (len > maxLength)
            {
                maxLength = len;
                start = i - (maxLength - 1) / 2;
            }
        }
        return s.Substring(start, maxLength);
    }

    private static int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }

    // 20. Find the Median of Two Sorted Arrays
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        if (n1 > n2) return FindMedianSortedArrays(nums2, nums1); // Ensure that nums1 is smaller

        int low = 0, high = n1;
        while (low <= high)
        {
            int partition1 = (low + high) / 2;
            int partition2 = (n1 + n2 + 1) / 2 - partition1;

            int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
            int minRight1 = (partition1 == n1) ? int.MaxValue : nums1[partition1];

            int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
            int minRight2 = (partition2 == n2) ? int.MaxValue : nums2[partition2];

            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
            {
                if ((n1 + n2) % 2 == 0)
                {
                    return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                }
                else
                {
                    return Math.Max(maxLeft1, maxLeft2);
                }
            }
            else if (maxLeft1 > minRight2)
            {
                high = partition1 - 1;
            }
            else
            {
                low = partition1 + 1;
            }
        }

        throw new InvalidOperationException("Input arrays are not sorted correctly.");
    }

    static void Main()
    {
        // Example usage:
        Console.WriteLine("1. Sum of Array Elements: " + ArraySum(new int[] { 1, 2, 3, 4, 10, 11 })); 
          Console.WriteLine("2. Find the Missing Number: " + FindMissNumber(new int[] { 1, 2, 4, 5, 6 }, 6));
          Console.WriteLine("3. Reverse an Array in Place: ");
        int[] arr3 = { 1, 2, 3, 4 };
        ReverseArray(arr3);
        Console.WriteLine(string.Join(", ", arr3));

        Console.WriteLine("4. First Non-Repeating Character: " + FirstUniqueChar("swiss"));
        Console.WriteLine("5. Majority Element: " + MajorityElement(new int[] { 3, 3, 4, 2, 3, 3, 3, 1 }));
        Console.WriteLine("6. Rotate Array by K Positions: ");
        int[] arr6 = { 1, 2, 3, 4, 5, 6, 7 };
        RotateArray(arr6, 3);
        Console.WriteLine(string.Join(", ", arr6));
        Console.WriteLine("7. Longest Consecutive Sequence: " + LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
        Console.WriteLine("8. Kth Smallest Element: " + KthSmallestElement(new int[] { 7, 10, 4, 3, 20, 15 }, 3));
        Console.WriteLine("9. Max Product of Three: " + MaxProductOfThree(new int[] { 1, 10, -5, 1, -100 }));
        Console.WriteLine("10. Merge Two Sorted Arrays: " + string.Join(", ", MergeSortedArrays(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 })));
        Console.WriteLine("11. Two Sum Sorted: " + string.Join(", ", TwoSumSorted(new int[] { 1, 2, 3, 4, 6 }, 6)));
        Console.WriteLine("12. Find Peak Element: " + FindPeakElement(new int[] { 1, 2, 3, 1 }));
        Console.WriteLine("13. Is Subset: " + IsSubset(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4 }));
        Console.WriteLine("14. Trap Rain Water: " + TrapRainWater(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        Console.WriteLine("15. Min Window Substring: " + MinWindowSubstring("ADOBECODEBANC", "ABC"));
        Console.WriteLine("16. Find Anagrams: " + string.Join(", ", FindAnagrams("cbaebabacd", "abc")));
        Console.WriteLine("17. K Closest Numbers: " + string.Join(", ", KClosestNumbers(new int[] { 1, 2, 3, 4, 5 }, 2, 3)));
        Console.WriteLine("18. Find Duplicates: " + string.Join(", ", FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 })));
        Console.WriteLine("19. Longest Palindrome: " + LongestPalindrome("babad"));
        Console.WriteLine("20. Median of Two Sorted Arrays: " + FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
    
    }
}
