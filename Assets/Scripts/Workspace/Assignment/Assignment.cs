using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords(); Check
            // AS02_CountNumber(); Check
            // AS03_CheckValidBrackets(); Check
            // AS04_PrintReverseLinkedList(); Check
            // AS05_FindMiddleElement(); Check
            // AS06_MergeDictionaries(); Check
            // AS07_RemoveDuplicatesFromLinkedList(); Check
            // AS08_TopFrequentNumber(); Check
            // AS09_PlayerInventory(); Check
            // AS10_GameEventQueue(); Check
            AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();

            foreach (string word in words) 
            {
                if (wordsDict.ContainsKey(word)) 
                {
                    wordsDict[word]++;
                }
                else 
                {
                    wordsDict[word] = 1;
                }
            }

            foreach (var word in wordsDict)
            {
                Debug.Log($"{word.Key} : {word.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numbersDict = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (numbersDict.ContainsKey(number)) 
                {
                    numbersDict[number]++;
                }
                else 
                {
                    numbersDict[number] = 1;
                }
            }

            foreach (var number in numbersDict)
            {
                Debug.Log($"Number {number.Key} : {number.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketsDict = new Dictionary<char, char>();
            bracketsDict.Add( '(', ')' );
            LinkedList<char> stack = new LinkedList<char>();

            foreach (char letter in input)
            {
                if (letter == '(') 
                {
                    stack.AddLast(letter);
                }

                else if (letter == ')')
                {
                    if (stack.Count <= 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    else if (bracketsDict.ContainsKey(stack.Last.Value))
                    {
                        stack.RemoveLast();
                    }
                    else
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            Debug.Log(stack.Count <= 0 ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            var current = list.Last;

            if (list.Count <= 0)
            {
                Debug.Log("List is empty");
                return;
            }

            while (current != null)
            {
                var next = current.Previous;
                Debug.Log(current.Value);
                current = next;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            var slow = list.First;
            var fast = list.First;

            if (list.Count <= 0)
            {
                Debug.Log("List is empty");
                return;
            }

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next; 
                fast = fast.Next.Next;
            }
            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            Dictionary<string, int> mergedDict = new Dictionary<string, int>(dict1);

            foreach (var entry in dict2)
            {
                if (mergedDict.ContainsKey(entry.Key)) 
                {
                    mergedDict[entry.Key] += entry.Value;
                }
                else 
                {
                    mergedDict[entry.Key] = entry.Value;
                }
            }

            foreach (var entry in mergedDict)
            {
                var key = entry.Key;
                var value = entry.Value;
                Debug.Log($"{key} : {value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            Dictionary<int, bool> foundNum = new Dictionary<int, bool>();
            var current = list.First;

            while (current != null) 
            {
                var next = current.Next;
                if (foundNum.ContainsKey(current.Value))
                {
                    Debug.Log("Removed " + current.Value);
                }
                else
                {
                    foundNum.Add(current.Value, true);
                }
                current = next;
            }

            foreach (var entry in foundNum)
            {
                int key = entry.Key;  
                Debug.Log(key);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            Dictionary<int, int> numList = new Dictionary<int, int>();

            if (numbers == null || numbers.Length <= 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            foreach (var number in numbers)
            {
                if (numList.ContainsKey(number)) 
                {
                    numList[number]++;
                }
                else 
                {
                    numList[number] = 1;
                }
            }

            var highestCount = numList[numbers[0]];
            int highestNumber = numbers[0];

            foreach (var number in numbers)
            {
                var count = numList[number];

                if (count > highestCount)
                {
                    highestCount = count;
                    highestNumber = number;
                }
            }

            Debug.Log($"{highestNumber} count: {highestCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory.ContainsKey(itemName)) 
            {
                inventory[itemName] += quantity;
            }
            else 
            {
                inventory[itemName] = quantity;
            }

            foreach (var item in inventory)
            {
                var key = item.Key;
                var count = item.Value;
                Debug.Log($"{key} : {count}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();

            if (eventQueue.Count <= 0)
            {
                Debug.Log("Event queue is empty!");
                return;
            }

            while (eventQueue.Count > 0)
            {
                var current = eventQueue.First.Value;
                eventQueue.RemoveFirst();
                Debug.Log("Processing event: " + current.Name);
                Debug.Log("Remaining events: " + eventQueue.Count);
                Debug.Log($"{current.EventType} event processed: {current.Name}");
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else playerStats[statName] = value;
            Debug.Log($"Updated {statName} : {playerStats[statName]}");

            Debug.Log("Current player stats:");
            foreach (var stat in playerStats)
            {
                var key = stat.Key;
                var val = stat.Value;

                Debug.Log($"{key} : {val}");
            }
        }

        #endregion
    }
}
