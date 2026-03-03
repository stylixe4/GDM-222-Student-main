using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
           // 1. สร้าง LinkedList ของประเภท string
            LinkedList<string> linkedList = new LinkedList<string>();

            // 2. เพิ่มข้อมูลที่ท้ายของ LinkedList
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            // 3. เพิ่มข้อมูลที่ต้นของ LinkedList
            linkedList.AddFirst("Node 0");

            // 4. แสดงเนื้อหาใน LinkedList
            LCT01_PrintLinkedList(linkedList);

            // 5. เช้าถึงข้อมูลใน LinkedList
            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log("last", lastNode.Value);
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);
            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            // 6. add node ก่อน หรือ หลัง node ที่กำหนด
            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkedList);

            // 6. ลบ Node แรก
            linkedList.RemoveFirst();
            LCT01_PrintLinkedList(linkedList);

            // 7. ลบ Node ตามค่าที่กำหนด
            linkedList.Remove("Node 2");
            LCT01_PrintLinkedList(linkedList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("LinkedList...");
            foreach(var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            
            Hashtable hashtable = new Hashtable();
            //Key Value
            hashtable.Add(1,"Apple");
            hashtable.Add(2,"Banana");
            hashtable.Add("bad-fruit","Rotten Tomato");

            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];

            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }
        public void LCT02_PrintHashTable(Hashtable hashtable)
        {
            Debug.Log("table ...");
            foreach(DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts[word] = 1;
            }

            foreach (var pair in wordCounts)
            {
                Debug.Log($"word: '{pair.Key}' count: {pair.Value}");
            }
        }

        public void AS02_CountNumber(int[] numbers)
        {
            Dictionary<int, int> numCounts = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (numCounts.ContainsKey(num))
                    numCounts[num]++;
                else
                    numCounts[num] = 1;
            }

            foreach (var pair in numCounts)
            {
                Debug.Log($"number: {pair.Key} count: {pair.Value}");
            }
        }

        public void AS03_CheckValidBrackets(string input)
        {
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) { isValid = false; break; }
                    
                    char open = stack.Pop();
                    if ((c == ')' && open != '(') || 
                        (c == ']' && open != '[') || 
                        (c == '}' && open != '{'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0) isValid = false;

            Debug.Log(isValid ? "Valid" : "Invalid");
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // Start from the Last node and move backwards using .Previous
            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value.ToString());
                current = current.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // Using two pointers (Slow and Fast) to find the middle
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            // Fast moves two steps, Slow moves one. When Fast hits the end, Slow is at middle.
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            // Combine both dictionaries into a new one (or modify dict1)
            Dictionary<string, int> result = new Dictionary<string, int>(dict1);

            foreach (var pair in dict2)
            {
                if (result.ContainsKey(pair.Key))
                    result[pair.Key] += pair.Value;
                else
                    result[pair.Key] = pair.Value;
            }

            foreach (var pair in result)
            {
                Debug.Log($"key: {pair.Key}, value: {pair.Value}");
            }
        }
        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            HashSet<int> seen = new HashSet<int>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;
                if (seen.Contains(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value);
                }
                current = next;
            }

            foreach (int val in list)
            {
                Debug.Log(val.ToString());
            }
        }
        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            int maxCount = 0;
            int topNum = numbers[0];

            foreach (int n in numbers)
            {
                if (counts.ContainsKey(n)) counts[n]++;
                else counts[n] = 1;

                if (counts[n] > maxCount)
                {
                    maxCount = counts[n];
                    topNum = n;
                }
                // Tie-breaker: The test cases expect the first one encountered if counts are equal
            }

            Debug.Log($"{topNum} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory == null)
            {
                Debug.Log("Inventory is null");
                return;
            }

            if (inventory.ContainsKey(itemName))
                inventory[itemName] += quantity;
            else
                inventory[itemName] = quantity;

            foreach (var item in inventory)
            {
                Debug.Log($"{item.Key}: {item.Value}");
            }
        }

        #endregion

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            throw new System.NotImplementedException();
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
