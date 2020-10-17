using System;
using System.Collections.Generic;
using System.Text;

namespace LEETCODE2020.Models
{

    
    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
        where TValue : class
    {

        //THIS IS FOR Q3 SHOULD BE IN SEPERATE CLASS
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int largestNo = 0;
            int left = 0;
            int right = A.Length - 1;
            int sum = 0;
            try
            {
                Array.Sort(A);
                while(left < right)
                {
                    sum = A[left] + A[right];
                    if(sum == 0)
                    {
                        if (A[right] > A[left])
                        {
                            largestNo = A[right];
                        }
                        else
                        {
                            largestNo = A[left];
                        }
                    }
                    else if(sum > 0)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return largestNo;
        }

        Dictionary<string, TValue> internalStorage = new Dictionary<string, TValue>();
        /// <summary> Returns number of elements in a map</summary>
        public int Count => internalStorage.Count;

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            bool added = false;
            TValue existingValue;
            try
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException("Specified key bis an empty string");
                }
               bool retrieved = internalStorage.TryGetValue(key, out existingValue);
                if (retrieved)
                {
                    internalStorage.Remove(key);
                }
                internalStorage.Add(key, value);
                added = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return added;
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            bool removed = false;
            TValue existingValue;
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Specified key is an empty string");
            }
            try
            {
                bool retrieved = internalStorage.TryGetValue(key, out existingValue);
                if (retrieved)
                {
                    internalStorage.Remove(key);
                    removed = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return removed;
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            TValue returnValue = this.DefaultValue;
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                
                throw new ArgumentException("Specified key bis an empty string");
            }
            try
            {
                bool retrieved = internalStorage.TryGetValue(key, out returnValue);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return returnValue;
        }
    }
}
