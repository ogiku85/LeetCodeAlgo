using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace LEETCODE2020.Models
{

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode();
            string l1Value = "";
            string l2Value = "";

            BigInteger l1NumberValue = 0;
            BigInteger l2NumberValue = 0;

            BigInteger totalSum = 0;
            string totalSumString = "";
            try
            {
                if (l1 == null && l2 == null)
                {
                    newHead = null;
                    return newHead;
                }
                if (l1 == null && l2 != null)
                {
                    newHead = l2;
                    return newHead;
                }
                if (l1 != null && l2 == null)
                {
                    newHead = l1;
                    return newHead;
                }

                l1Value = getLinkedListValue(l1);
                l2Value = getLinkedListValue(l2);

                if (l1Value.Length > l2Value.Length)
                {
                    while(l2Value.Length < l1Value.Length)
                    {
                        l2Value += "0";
                    }
                }

                if (l1Value.Length < l2Value.Length)
                {
                    while(l1Value.Length < l2Value.Length)
                    {
                        l1Value += "0";
                    }
                }

                ///since the list were reversed , we reverse theuir string value b4 conversion
                l1Value = new string(l1Value.Reverse().ToArray());
                l2Value = new string(l2Value.Reverse().ToArray());

                bool converted = BigInteger.TryParse(l1Value, out l1NumberValue);
                converted = BigInteger.TryParse(l2Value, out l2NumberValue);

                totalSum = l1NumberValue + l2NumberValue;
                totalSumString = totalSum.ToString();

                int count = 0;
                ListNode prevNode = null;
                ListNode currentNode = null;
                int currentValue = 0;
                while (count < totalSumString.Length)
                {
                    currentValue = Convert.ToInt32(totalSumString[count].ToString());
                    currentNode = new ListNode { val = currentValue };
                    currentNode.next = prevNode;
                    prevNode = currentNode;
                    count++;
                }
                //at the end of the loop, currentNode will contain the value of the last digit hence our new head
                newHead = currentNode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return newHead;
        }
        public string getLinkedListValue(ListNode head)
        {
            string value = "";
            ListNode currentNode;
            try
            {
                currentNode = head;
                while (currentNode != null)
                {
                    value += currentNode.val;
                    currentNode = currentNode.next;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return value;
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode();
            ListNode currentNodeFornewList = null;
            ListNode currentNode1 = l1;
            ListNode currentNode2 = l2;
            try
            {
                /*
                if both list are empty or thiers heads equal null simply return an empty list or null head
                */
                if (l1 == null && l2 == null)
                {
                    newHead = null;
                    return newHead;
                }
                /*
                if one head is empty and the other is not simply return the head of the list that is not empty as the new list
                */
                if (l1 != null && l2 == null)
                {
                    newHead = l1;
                    return newHead;
                }
                if (l1 == null && l2 != null)
                {
                    newHead = l2;
                    return newHead;
                }
                /*
                 At this point both nodes are not empty. pick the node with the smallest value from either list and assign that as
                 the staring point or head of the new list to be created and move to the next node of the selected list
                 */
                if (currentNode1.val < currentNode2.val)
                {
                    newHead = currentNode1;
                    currentNode1 = currentNode1.next;
                }
                else
                {
                    newHead = currentNode2;
                    currentNode2 = currentNode2.next;
                }
                currentNodeFornewList = newHead;


                while (currentNode1 != null && currentNode2 != null)
                {
                    if (currentNode1.val < currentNode2.val)
                    {
                        currentNodeFornewList.next = currentNode1;
                        currentNode1 = currentNode1.next;
                    }
                    else
                    {
                        currentNodeFornewList.next = currentNode2;
                        currentNode2 = currentNode2.next;
                    }
                    currentNodeFornewList = currentNodeFornewList.next;
                }
                // at the end of the while loop we could have reached the end of both loops or just one of them so we do some extra check
                /*if either list still has content after the above loop, simply set the new list to point to the remaining nodes in the list 
                  with more content*/
                if (currentNode1 != null && currentNode2 == null)
                {
                    currentNodeFornewList.next = currentNode1;
                }

                if (currentNode1 == null && currentNode2 != null)
                {
                    currentNodeFornewList.next = currentNode2;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return newHead;
        }
        public ListNode MiddleNode(ListNode head)
        {
            ListNode middleNode = new ListNode();
            int nodeCount = 0;
            int middleNodePosition = 0;
            int count = 0;
            ListNode currentNode;
            try
            {
                nodeCount = getNodeCount(head);
                // we using (nodeCount / 2) + 1  because If there are two middle nodes, we should return the second middle node.
                // and we are usning (nodeCount + 1) / 2 because that's the only way to evenly divide an odd number
                // middleNodePosition = nodeCount % 2 == 0 ? nodeCount / 2 : (nodeCount + 1) / 2;

                middleNodePosition = nodeCount % 2 == 0 ? (nodeCount / 2) + 1 : (nodeCount + 1) / 2;

                currentNode = head;
                while (currentNode != null && count < middleNodePosition)
                {
                    count++;
                    middleNode = currentNode;
                    currentNode = currentNode.next;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return middleNode;
        }
        
        public int getNodeCount(ListNode head)
        {
            int count = 0;
            ListNode currentNode;
            try
            {
                currentNode = head;
                while(currentNode != null)
                {
                    count++;
                    currentNode = currentNode.next;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return count;
        }
        public ListNode ReverseList(ListNode head)
        {
            ListNode currentNode;
            ListNode previousNode = null;
            ListNode nextNode;
            try
            {
                currentNode = head;
                while(currentNode != null)
                {
                    nextNode = currentNode.next;
                    currentNode.next = previousNode;
                    previousNode = currentNode;
                    currentNode = nextNode;
                }

                // the above while loop will end when current node is null hence pre node will be the new head node
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return previousNode;
        }
        public IList<int> LuckyNumbersOLD(int[][] matrix)
        {
            List<int> selectedLuckyNumbers = new List<int>();
            List<int> minNumbersInRow = new List<int>();
            List<int> maxNumbersInColumn = new List<int>();

            Dictionary<string, int> minNumbersInRowDict = new Dictionary<string, int>();

            Dictionary<string, int> maxNumbersInColumnDict = new Dictionary<string, int>();
            //when trying to get min or max in an array it is safer to set variable to the type min/max value as show below.
            int minNumberInRow = int.MaxValue;
            int maxNumberInColumn = int.MinValue;

            int indexOfMinNumberInRow = int.MinValue;
            int indexOfMaxNumberInRow = int.MinValue;

            try
            {
                //matrixes are defined as m x n where m = rows and n = columns
                //since the matrix is an array of array, lenght simply returns the number of internal array present withing the outer array
                int noOfRows = matrix.Length;

                //this will take the first array iniside the outer array and it lenght represnts the no of columns since all the internal arrays are expected to have the same lenght or coulmns
                int noOfColumns = matrix[0].Length;
               

                
                for (int i = 0; i < noOfRows; i++)
                {
                  //  minNumberInRow = matrix[i].Min();
                   // minNumbersInRow.Add(minNumberInRow);
                    //reset max number for eevery column
                    maxNumberInColumn = int.MinValue;
                    minNumberInRow = int.MaxValue;
                    for (int j = 0; j < noOfColumns; j++)
                    {
                        //matrix[i][j] i is the row j is the column i.e the content in the first bracket is the row and that of the second is the column
                        // if i == j we are dealing with a column
                        if (i == j)
                        {
                            maxNumberInColumn = matrix[i][j] > maxNumberInColumn ? matrix[i][j] : maxNumberInColumn;
                            maxNumbersInColumnDict.Add(i.ToString() + j.ToString(), maxNumberInColumn);
                        }

                        if (matrix[i][j] < minNumberInRow)
                        {
                            minNumberInRow = matrix[i][j] < minNumberInRow ? matrix[i][j] : minNumberInRow;
                            minNumbersInRowDict.Add(i.ToString() + j.ToString(), minNumberInRow);
                            minNumbersInRow.Add(minNumberInRow);
                        }
                       



                    }
                    maxNumbersInColumn.Add(maxNumberInColumn);
                    
                }

                // at the end of the loop the min and max dictionaries will now contain the required value and their order of addition to th list equal their respective row and columns
                //all we need to do is find a match
                foreach(var key in minNumbersInRowDict.Keys)
                {
                    if (maxNumbersInColumnDict.ContainsKey(key) && maxNumbersInColumnDict[key] == minNumbersInRowDict[key])
                    {
                        selectedLuckyNumbers.Add(maxNumbersInColumnDict[key]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return selectedLuckyNumbers;
        }

        public IList<int> LuckyNumbersOLD2(int[][] matrix)
        {
            List<int> selectedLuckyNumbers = new List<int>();
            List<int> minNumbersInRow = new List<int>();
            List<int> maxNumbersInColumn = new List<int>();

            Dictionary<string, int> minNumbersInRowDict = new Dictionary<string, int>();

            Dictionary<string, int> maxNumbersInRowDict = new Dictionary<string, int>();
            //when trying to get min or max in an array it is safer to set variable to the type min value as show below
            int minNumberInRow = int.MinValue;
            int maxNumberInColumn = int.MinValue;

            int indexOfMinNumberInRow = int.MinValue;
            int indexOfMaxNumberInRow = int.MinValue;

            try
            {
                //matrixes are defined as m x n where m = rows and n = columns
                //since the matrix is an array of array, lenght simply returns the number of internal array present withing the outer array
                int noOfRows = matrix.Length;

                //this will take the first array iniside the outer array and it lenght represnts the no of columns since all the internal arrays are expected to have the same lenght or coulmns
                int noOfColumns = matrix[0].Length;



                for (int i = 0; i < noOfRows; i++)
                {
                    minNumberInRow = matrix[i].Min();
                    minNumbersInRow.Add(minNumberInRow);
                    //reset max number for eevery column
                    maxNumberInColumn = int.MinValue;
                    for (int j = i; j < noOfRows; j++)
                    {
                        //matrix[i][j] i is the row j is the column i.e the content in the first bracket is the row and that of the second is the column
                        //within this loop we only want to tranverse the columns hence we use the row counter as column index since the matrix are of the same dimension

                        maxNumberInColumn = matrix[j][i] > maxNumberInColumn ? matrix[j][i] : maxNumberInColumn;


                    }
                    maxNumbersInColumn.Add(maxNumberInColumn);

                    //if (maxNumberInColumn == minNumberInRow)
                    //{
                    //    selectedLuckyNumbers.Add(maxNumberInColumn);
                    //}
                }

                // at the end of the loop the min and max list will now contain the required value and their order of addition to th list equal their respective row and columns
                //all we need to do is find a match

                //for (int i = 0; i < minNumbersInRow.Count; i++)
                //{
                //    // if equal it means the current number was the min in it ro and the max for it coulmn
                //    if (minNumbersInRow[i] == maxNumbersInColumn[i])
                //    {
                //        selectedLuckyNumbers.Add(minNumbersInRow[i]);
                //    }
                //}
                //since the numbers in the matrix are unique it means they occur once in one exact location so if it si present in both the maxColumn and mincolumn list then
                //it is the same number
                 selectedLuckyNumbers =  minNumbersInRow.Where(m => maxNumbersInColumn.Contains(m)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return selectedLuckyNumbers;
        }

        public IList<int> LuckyNumbers(int[][] matrix)
        {
            List<int> selectedLuckyNumbers = new List<int>();
            List<int> minNumbersInRow = new List<int>();
            List<int> maxNumbersInColumn = new List<int>();

            Dictionary<string, int> minNumbersInRowDict = new Dictionary<string, int>();

            Dictionary<string, int> maxNumbersInRowDict = new Dictionary<string, int>();
            //when trying to get min or max in an array it is safer to set variable to the type min value as show below
            int minNumberInRow = int.MinValue;
            int maxNumberInColumn = int.MinValue;

            int indexOfMinNumberInRow = int.MinValue;
            int indexOfMaxNumberInRow = int.MinValue;

            try
            {
                //matrixes are defined as m x n where m = rows and n = columns
                //since the matrix is an array of array, lenght simply returns the number of internal array present withing the outer array
                int noOfRows = matrix.Length;

                //this will take the first array iniside the outer array and it lenght represnts the no of columns since all the internal arrays are expected to have the same lenght or coulmns
                int noOfColumns = matrix[0].Length;

                int loopControl = 0;

                loopControl = noOfColumns > noOfRows ? noOfColumns : noOfRows;

                for (int i = 0; i < loopControl; i++)
                {
                   
                    if (i < noOfRows)
                    {
                        minNumberInRow = matrix[i].Min();
                        minNumbersInRow.Add(minNumberInRow);
                    }
                    //reset max number for eevery column
                    maxNumberInColumn = int.MinValue;
                    for (int j = i; j < loopControl; j++)
                    {
                        //matrix[i][j] i is the row j is the column i.e the content in the first bracket is the row and that of the second is the column
                        //within this loop we only want to tranverse the columns hence we use the row counter as column index since the matrix are of the same dimension

                        if (i < noOfColumns && j < noOfRows)
                        {
                            maxNumberInColumn = matrix[j][i] > maxNumberInColumn ? matrix[j][i] : maxNumberInColumn;
                        }
                        


                    }
                    maxNumbersInColumn.Add(maxNumberInColumn);

                    //if (maxNumberInColumn == minNumberInRow)
                    //{
                    //    selectedLuckyNumbers.Add(maxNumberInColumn);
                    //}
                }

                // at the end of the loop the min and max list will now contain the required value and their order of addition to th list equal their respective row and columns
                //all we need to do is find a match

                //for (int i = 0; i < minNumbersInRow.Count; i++)
                //{
                //    // if equal it means the current number was the min in it ro and the max for it coulmn
                //    if (minNumbersInRow[i] == maxNumbersInColumn[i])
                //    {
                //        selectedLuckyNumbers.Add(minNumbersInRow[i]);
                //    }
                //}
                //since the numbers in the matrix are unique it means they occur once in one exact location so if it si present in both the maxColumn and mincolumn list then
                //it is the same number
                selectedLuckyNumbers = minNumbersInRow.Where(m => maxNumbersInColumn.Contains(m)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return selectedLuckyNumbers;
        }


        public void Rotate(int[][] matrix)
        {
            try
            {
                //to rotate a matrix by 90 degrees means to transpose the matrix and reverse it rows. Transposing a matrix means to turn it rows into columns and vic verss
                /*
            [           
              [1,2,3],
              [4,5,6],
              [7,8,9]
            ], 
            tranposes into [
                              [1,4,7],
                              [2,5,8],
                              [3,6,9]
                            ],
             and it rows are reversed into [
                                              [7,4,1],
                                              [8,5,2],
                                              [9,6,3]
                                            ],
                 */

                //to transpose we use tow nested for loops to iterate over the rows and columsn of the matrix

                //matrixes are defined as m x n where m = rows and n = columns
                //since the matrix is an array of array, lenght simply returns the number of internal array present withing the outer array
                int noOfRows = matrix.Length;

                //this will take the first array iniside the outer array and it lenght represnts the no of columns since all the internal arrays are expected to have the same lenght or coulmns
                int noOfColumns = matrix[0].Length;
                //temp will temporarily hold values that are to be swapped
                int temp = 0;

                //use for loop to transpose
                for (int i =0; i < noOfRows; i++)
                {
                    for(int j = i; j < noOfColumns; j++)
                    {
                        //matrix[i][j] i is the row j is the column i.e the content in the first bracket is the row and that of the second is the column
                        temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
                int startIndex = 0;
                int endIndex = noOfColumns - 1;
                //use code below to reverse array by swapping values
                for(int i =0; i < noOfRows; i++)
                {
                    //the while loop below will swap the neccessary values
                    //reset start and endindex after each row iteration so that all rows can be swapped
                    startIndex = 0;
                    endIndex = noOfColumns - 1;
                    while (startIndex <= endIndex)
                    {
                        temp = matrix[i][startIndex];
                        matrix[i][startIndex] = matrix[i][endIndex];
                        matrix[i][endIndex] = temp;
                        startIndex++;
                        endIndex--;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
        }
        public int[] findPerm(String A, int B)
        {
            int[] answer = new int[B];
            int startIndex = 1;
            int endIndex = B;
            try
            {
                // a D in string A means the next charater should be lesser and in order to achive that we simply add the highest number to the current index and that we ensure the next number will be lesser
                // an I in string A means the next charater should be greater and in order to achive that we simply add the lowest number to the current index and that we ensure the next number will be greater

                char[] controls = A.ToCharArray();
                for (int i=0; i < controls.Length; i++)
                {
                    if (controls[i] == 'D')
                    {
                        answer[i] = endIndex;
                        endIndex--;
                    }
                    if (controls[i] == 'I')
                    {
                        answer[i] = startIndex;
                        startIndex++;
                    }
                }
                //at the nd of the for loop only B -1 numbers would have been used so we just place the last number in the answer array
                //either endindex or startIndex will do beacuse they are both pointing at the same number
                answer[B- 1] = endIndex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return answer;
        }
        public bool CanReach(int[] arr, int start)
        {
            bool canReachZero = false;
            int currentIndex = 0;
            try
            {
                Queue<int> indexToVisit = new Queue<int>();
                Dictionary<int, bool> visitedIndexDictionary = new Dictionary<int, bool>();

                indexToVisit.Enqueue(start);
                visitedIndexDictionary.Add(start, true);
                while (indexToVisit.Count > 0)
                {
                    currentIndex = indexToVisit.Dequeue();
                    if (arr[currentIndex] == 0)
                    {
                        canReachZero = true;
                        return canReachZero;
                    }

                    int[] indexesToExploreAfterCurrentIndex = { currentIndex + arr[currentIndex], currentIndex - arr[currentIndex] };

                    foreach (int index in indexesToExploreAfterCurrentIndex)
                    {
                        if (index >= 0 && index < arr.Length && !visitedIndexDictionary.ContainsKey(index))
                        {
                            indexToVisit.Enqueue(index);
                            visitedIndexDictionary.Add(index, true);
                        }
                        

                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return canReachZero;
        }
            public bool CanReachOLD(int[] arr, int start)
        {
            bool canReachZero = false;
            int lastGoodIndex = 0;
            int lastBadIndex = 0;
            try
            {
                //the goal of this fucntion is to see if it is impossible to traverse the full array
                //i.e go forarwd or backward completely. Once we hit an index with zeo or 0 it means we cann't jump hence we cann't go further

                //the good index is the index which allows us to get to the end. This will start as the last index of the array and we will move back backwards to the left or begining knowing 
                //that we can always get to the last previous good index from the current one

                //to ensure realibity we simply ignore the passed in satrt value or set it to the end of the array whichever way solution is sil O(n)
                if (arr == null && arr.Length <= 0)
                {
                    canReachZero = false;
                    return canReachZero;
                }
                lastGoodIndex = arr.Length - 1;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] + i >= lastGoodIndex)
                    {
                        lastGoodIndex = i;
                    }
                    else
                    {
                        lastBadIndex = i;
                        if(arr[i] == 0)
                        {
                            canReachZero = true;
                            return canReachZero;
                        }
                    }
                }
                //if at the end of the for loop we find our self at the begining or index 0, it menas we can go from zero to the end since we just came from the dn to zero
                if (lastGoodIndex == 0)
                {
                    canReachZero = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }

            return canReachZero;

        }
        public string ReverseWords(string s)
        {
            // this task involves reversing the individual words before reversing the entire string otherswise the word will not be fully reversed
            string reversedWord = "";
            int begin = 0;
            int end = 0;
            char[] stringToReverseCharacter;
            
            try
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return "";
                }
                stringToReverseCharacter = s.ToCharArray();
                while(end < stringToReverseCharacter.Length)
                {
                    //if current charater is a space then we just found a word i.e reached the end of a word na d we have to reverse the word using our helper function
                    if(s[end] == ' ')
                    {
                        //end -1 passes the word without th newly found space
                        ReverseCharactersHelper(ref stringToReverseCharacter, begin, end - 1);
                        end = end + 1;
                        begin = end;
                    }
                    else
                    {
                        //current character is not up to a word so we keep going
                        end = end + 1;
                    }
                }
                var lastCharacter = stringToReverseCharacter[stringToReverseCharacter.Length - 1];
                //if the last charater was not space it means will not be able to change it in the above while loop therfeore we have to reverse it here outside the loop
                if (lastCharacter.ToString() != " " && begin <= stringToReverseCharacter.Length - 1)
                {
                    //at this point begin is at the start index of the last word so we start from begin to the end of the string to get and reverse the last word in the string
                    ReverseCharactersHelper(ref stringToReverseCharacter, begin, stringToReverseCharacter.Length - 1);
                }
                // now that all the words within the string is reveres, let's reverse the endtire string
                ReverseCharactersHelper(ref stringToReverseCharacter, 0, stringToReverseCharacter.Length - 1);

                //now lets remove multiple spaces and leave only single spaces
                int i = 0;
                while (i < stringToReverseCharacter.Length)
                {
                    if (stringToReverseCharacter[i].ToString() == " ")
                    {
                        reversedWord += stringToReverseCharacter[i].ToString();
                        i++;
                        while (stringToReverseCharacter[i].ToString() == " " && i < stringToReverseCharacter.Length)
                        {
                            i++;
                        }
                    }
                    else
                    {
                        reversedWord += stringToReverseCharacter[i].ToString();
                        i++;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            reversedWord = reversedWord.Trim();
            return reversedWord;
        }
        public char[] ReverseCharactersHelper(ref char[] s, int begin, int end)
        {
            char temp;
            try
            {
                while (begin <= end)
                {
                    temp = s[begin];
                    s[begin] = s[end];
                    s[end] = temp;
                    begin++;
                    end--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return s;
        }

        public int Jump(int[] nums)
        {
            int noOfJumps = 0;
            try
            {
                if (nums == null)
                {
                    noOfJumps = -1;
                    return noOfJumps;
                }
                if (nums[0] == 0)
                {
                    noOfJumps = 0;
                    return noOfJumps;
                }
                if (nums.Length == 0 || nums.Length == 1)
                {
                    noOfJumps = 0;
                    return noOfJumps;
                }
                int indexOfSelectedLongestJump = 0;
                // At the begining the longest jump available is the value at index 0. This will change as we traverse the array
                int currentLongestJumpAvailable = nums[0];
                // this is set as the difference between current position and the max juimp available and this determine when we make a jump
                int noOfStepsAvailableInSelectedjump = nums[0];
                // Since the array is not null and the first index is not 0 we can begin by taking a jump with whatever value is in index 0
                noOfJumps = 1;

                for (int i = 1; i < nums.Length; i++)
                {
                    // we look for a jump higher than the current jump we are on so that we have a new jump that we can switch to
                    if (nums[i] + i > currentLongestJumpAvailable)
                    {
                        currentLongestJumpAvailable = nums[i] + i;

                        indexOfSelectedLongestJump = i;
                    }
                    noOfStepsAvailableInSelectedjump = noOfStepsAvailableInSelectedjump - 1;

                    if (noOfStepsAvailableInSelectedjump == 0 && currentLongestJumpAvailable > i && i != nums.Length - 1)
                    {
                        // we have exhausted the steps from the previously selected jump but we found a new jump to take based on the earlier condition check above
                        noOfJumps = noOfJumps + 1;
                        //   noOfStepsAvailableInSelectedjump = currentLongestJumpAvailable - i;
                        

                        noOfStepsAvailableInSelectedjump = currentLongestJumpAvailable - i;
                    }
                    else if (noOfStepsAvailableInSelectedjump == 0 && currentLongestJumpAvailable <= i && i != nums.Length - 1)
                    {
                        //we have exhausted the steps from the previously selected jump and we could not find a next jump that can take us beyond the current position
                        //it is no longer possibel to continue hence we return -1 to show we cann't get to the end
                        noOfJumps = -1;
                        return noOfJumps;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return noOfJumps;
        }
        public bool CanJump(int[] nums)
        {
            bool canGetToTheEnd = false;
            int lastGoodIndex = 0;
            try
            {
                //the good index is the index which allows us to get to the end. This will start as the last index of the array and we will move back backwards to the left or begining knowing 
                //that we can always get to the last previous good index from the current one
                if (nums == null && nums.Length <=0)
                {
                    canGetToTheEnd = false;
                    return canGetToTheEnd;
                }
                lastGoodIndex = nums.Length - 1;

                for (int i = nums.Length - 1; i >=0; i--)
                {
                    if (nums[i] + i >= lastGoodIndex)
                    {
                        lastGoodIndex = i;
                    }
                }
                //if at the end of the for loop we find our self at the begining or index 0, it menas we can go from zero to the end since we just came from the dn to zero
                if (lastGoodIndex == 0)
                {
                    canGetToTheEnd = true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }

            return canGetToTheEnd;

        }
        public void ReverseString(char[] s)
        {
            try
            {
                int startIndex = 0;
                int endIndex = 0;
                char temp;

                if (s == null)
                {
                    return;
                }
                endIndex = s.Length - 1;
                // we simply begin to swap characters from the begining and the end

                while(startIndex <= endIndex)
                {
                    temp = s[startIndex];
                    s[startIndex] = s[endIndex];
                    s[endIndex] = temp;

                    startIndex = startIndex + 1;
                    endIndex = endIndex - 1;

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }

        }
        public bool IsPalindrome(string s)
        {
            bool result = false;
            int startIndex = 0;
            int endIndex = 0;
            string convertedString = "";
            try
            {
                if(s == null)
                {
                    result = false;
                    return result;
                }
                if (string.IsNullOrWhiteSpace(s))
                {
                    result = true;
                    return result;
                }
                if (s.Length == 1)
                {
                    result = true;
                    return result;
                }
                //now that we know string is not empty we can send end index
                endIndex = s.Length - 1;

                //we use all lower case since he question says comparison should be case insenstive bys saying a = A
                convertedString = s.ToLower();

                while(startIndex <= endIndex)
                {
                    //the code below endures we are only comparing alphabets and numbers and not spaces or commas
                    while (startIndex <= endIndex)
                    {
                        if (!Regex.IsMatch(convertedString[startIndex].ToString(),"^[a-zA-Z0-9]*$"))
                        {
                            startIndex = startIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (startIndex <= endIndex)
                    {
                        if (!Regex.IsMatch(convertedString[endIndex].ToString(), "^[a-zA-Z0-9]*$"))
                        {
                            endIndex = endIndex - 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    //this is to prevent issues when startIndex gets greater than enIndex
                    if (startIndex > endIndex)
                    {
                        break;
                    }
                    //At this point we are sure we are comapraing only alphatbeths and numbers so we can do direct compariosn and olny proceed in the loop if both sides are equal
                    if (convertedString[startIndex] == convertedString[endIndex])
                    {
                        startIndex = startIndex + 1;
                        endIndex = endIndex - 1;
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
                //if we are out of the loop it means bost sides are equal and we have a plaindrome
                result = true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);

            }

            return result;

        }
        public string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            string smallestWordInArray = "";
            try
            {
                if (strs == null || strs.Length <= 0)
                {
                    result = "";
                    return result;
                }
                //to be efficient we need to loop over the smallest word in the array. The longest prefix cannot be greater than the smallest word
                smallestWordInArray = strs.Min();

                //we start looping over the smallest word in the word list or array
                for(int i=0; i < smallestWordInArray.Length; i++)
                {
                    //we take each character in the smallest word and compare it to the other words i.e position by position
                    // if we pick the first character of the smallest word we compare it to the first letter of the other words.
                    //we return if the chacter at the given position is not the same for all words or if we get to the end of the list or array


                    //we use j to loop over the remaining words while i loops over position of the letters of the smallest word
                    //i position of characters, j positions of words strs[j][i] = word j position i
                    for (int j=0; j < strs.Length; j++)
                    {
                        if (smallestWordInArray[i] != strs[j][i])
                        {
                            return result;
                        }
                    }
                    result += smallestWordInArray[i];

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);

            }
            return result;

        }
        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            try
            {
                for(int i = 1; i <= n; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        result.Add("FizzBuzz");
                        continue;
                    }
                    if (i % 3 == 0)
                    {
                        result.Add("Fizz");
                        continue;
                    }
                    if (i % 5 == 0)
                    {
                        result.Add("Buzz");
                        continue;
                    }
                    result.Add(i.ToString());
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);

            }
            return result;
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            bool same = false;
            try
            {
                if (p == null & q == null)
                {
                    same = true;
                    return same;
                }
                if (p != null & q == null)
                {
                    same = false;
                    return same;
                }
                if (p == null & q != null)
                {
                    same = false;
                    return same;
                }

                if (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))
                {
                    same = true;
                    return same;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return same;

        }
        public int MajorityElement(int[] nums)
        {
            int result = int.MinValue;
            int oldCount = 0;
            int newCount = 0;
            bool retrieved = false;
            try
            {
                if (nums == null || nums.Length < 1)
                {
                    result = int.MinValue;
                    return result;
                }
                int maxElementParameter = (nums.Length / 2);
                Dictionary<int, int> numCountDic = new Dictionary<int, int>();
                foreach(var n in nums)
                {
                    oldCount = 0;
                    newCount = 0;
                    retrieved = numCountDic.TryGetValue(n, out oldCount);
                    if (retrieved == true)
                    {
                        newCount = oldCount + 1;
                        numCountDic[n] = newCount;
                    }
                    else
                    {
                        newCount = oldCount + 1;
                        numCountDic.Add(n, newCount);
                    }
                    //max element occurs greater than n/2 times

                    if (newCount > maxElementParameter)
                    {
                        result = n;
                        return result;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }

            return result;

        }
        public string ConvertToTitle(int n)
        {
            string title ="";
            int realAsciValue = 0;

            try
            {
                // we use base 26 because letters go from A-Z before changing to AA Ab and so on
                //we call the helper method below to convert our number to a number in base 26. we wil get our result in string so that we don't confuse it with a real base 10 number
                var numberInBase26 = convertNumberToAnotherBase(n, 26);
                foreach(var s in numberInBase26)
                {
                    //Excel sheets start from A and A has an ascii value of 65 and a value of 1. fro this to happen we subtract 64 from it real asci value to get 1.
                    //To convert back to the real ascii value we nned to add 64

                    realAsciValue = 64 + Convert.ToInt32(s.ToString());
                    title += Convert.ToChar(realAsciValue);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return title;
        }

        public List<string> convertNumberToAnotherBase(int number, int newBase)
        {
            // string resultInstring = "";
            List<string> resultInstring = new List<string>();
            int divisionResult = 0;
            int divisionRemainder = 0;
            List<char> resultsInChar = new List<char>();
            try
            {
                if (number <= 0)
                {
                    resultInstring.Add("0");
                    return resultInstring;
                }
                if (number <= newBase)
                {
                    resultInstring.Add(number.ToString());
                    return resultInstring;
                }
                divisionResult = number;
                //the whle loop will run while there is stil something to divide based on the last division result
                while (divisionResult > 0)
                {

                    divisionRemainder = divisionResult % newBase;
                   // divisionResult = divisionResult / newBase;
                    if (divisionRemainder == 0)
                    {
                        resultInstring.Add(newBase.ToString());
                        divisionResult = (divisionResult / 26) - 1;
                    }
                    else
                    {
                        resultInstring.Add(divisionRemainder.ToString());
                        divisionResult = (divisionResult / 26);
                    }

                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            //we convert the string to number and back to string in order to prevent situations like 01 which should just be 1
            //var resultInNumber = Convert.ToInt32(new string(resultsInChar.ToArray()));
            // resultInstring = resultInNumber.ToString();
            //after all the cal results should be reversed to get accurate value
            resultInstring.Reverse();
            return resultInstring;
        }


        public List<string> convertNumberToAnotherBaseOLD2(int number, int newBase)
        {
            // string resultInstring = "";
            List<string> resultInstring = new List<string>();
            int divisionResult = 0;
            int divisionRemainder = 0;
            List<char> resultsInChar = new List<char>();
            try
            {
                if (number <= 0)
                {
                    resultInstring.Add("0");
                    return resultInstring;
                }
                if (number <= newBase)
                {
                    resultInstring.Add(number.ToString());
                    return resultInstring;
                }
                divisionResult = number / newBase;
                divisionRemainder = number % newBase;

                resultInstring.Add(divisionRemainder.ToString());
                //the whle loop will run while there is stil something to divide based on the last division result
                while(divisionResult > newBase)
                {
                    divisionRemainder = divisionResult % newBase;
                    divisionResult = divisionResult / newBase;
                  //  resultsInChar.Add(divisionRemainder.ToString().ToCharArray()[0]);

                    resultInstring.Add(divisionRemainder.ToString());

                }
                //once the while loop end the result is no longer divisible and hsould just be added to the end of the new number string

                resultInstring.Add(divisionResult.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            //we convert the string to number and back to string in order to prevent situations like 01 which should just be 1
            //var resultInNumber = Convert.ToInt32(new string(resultsInChar.ToArray()));
            // resultInstring = resultInNumber.ToString();
            //after all the cal results should be reversed to get accurate value
            resultInstring.Reverse();
            return resultInstring;
        }
        public string convertNumberToAnotherBaseOLD(int number, int newBase)
        {
            string resultInstring = "";
            int divisionResult = 0;
            int divisionRemainder = 0;
            List<char> resultsInChar = new List<char>();
            try
            {
                if (number <= 0)
                {
                    resultInstring = "0";
                    return resultInstring;
                }
                if (number <= newBase)
                {
                    resultInstring = number.ToString();
                    return resultInstring;
                }
                divisionResult = number / newBase;
                divisionRemainder = number % newBase;

                resultsInChar.Add(divisionRemainder.ToString().ToCharArray()[0]);
                //the whle loop will run while there is stil something to divide based on the last division result
                while (divisionResult > newBase)
                {
                    divisionRemainder = divisionResult % newBase;
                    divisionResult = divisionResult / newBase;
                    resultsInChar.Add(divisionRemainder.ToString().ToCharArray()[0]);

                }
                //once the while loop end the result is no longer divisible and hsould just be added to the end of the new number string

                resultsInChar.Add(divisionResult.ToString().ToCharArray()[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            //we convert the string to number and back to string in order to prevent situations like 01 which should just be 1
            var resultInNumber = Convert.ToInt32(new string(resultsInChar.ToArray()));
            resultInstring = resultInNumber.ToString();
            return resultInstring;
        }

        public int TitleToNumber(string s)
        {
            int columnNumber = 0;
            double runningColumnTotalNumber = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    columnNumber = 0;
                    return columnNumber;
                }
               
                int numberOfCharacters = s.Length;
                int maxPower = numberOfCharacters - 1;
                //max power is always numberofCharacters - 1 since power is zero based . the last digit is a product of the current based raised to zero
                for (int i=0; i < s.Length; i++)
                {
                    //Ascii value of A is 65 and in excel it is 1 hence we subtract 64 from current character
                    runningColumnTotalNumber += (s[i] - 64) * Math.Pow(26, maxPower);
                    //since we starting from the left or teh highest power we need to decrease power as we iterate
                    maxPower = maxPower - 1;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);

            }
            columnNumber = Convert.ToInt32(runningColumnTotalNumber);
            return columnNumber;

        }
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int max = int.MinValue;
            try
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] >= 0 && A[i] < 10)
                    {
                        if(A[i] > max)
                        {
                            max = A[i];
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex.Message" + ex.Message);
                Console.WriteLine("ex.StackTrace" + ex.StackTrace);
            }
            return max;
        }
        public int ClimbStairs(int n)
        {
            Console.WriteLine("n = " + n);
            int maxNoOfStairs = 0;
            if (n <= 0)
            {
                return 0;
            }
            // so that array element can be addressed directly. Arrays are zero based. the plus one just allows easy //access
            int[] ClimbStairsMemory = new int[n + 1];

            
            int ClimbStairsHelper(int s)
            {
                int maxNoOfStairsHelper = 0;

                try
                {
                    //you can only climb 0 , 1, 2 stairs in the exact no of ways hence they serve as base case
                    if (s == 0)
                    {
                        return 0;
                    }
                    if (s == 1)
                    {
                        return 1;
                    }
                    if (s == 2)
                    {
                        return 2;
                    }
                    Console.WriteLine("s = " + s);
                    if (ClimbStairsMemory[s] != 0)
                    {
                        var storedValue = ClimbStairsMemory[s];
                        return storedValue;
                    }

                    maxNoOfStairsHelper = ClimbStairsHelper(s - 1) + ClimbStairsHelper(s - 2);
                    ClimbStairsMemory[s] = maxNoOfStairsHelper;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ex.Message" + ex.Message);
                    Console.WriteLine("ex.StackTrace" + ex.StackTrace);
                }

                return maxNoOfStairsHelper;
            }
            maxNoOfStairs = ClimbStairsHelper(n);
            return maxNoOfStairs;

        }
    }
}
