using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KeyPadMinTypingTimeSolution
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */

            TypingTimeCalculator calc = new TypingTimeCalculator();

            //process input
            string strEmployeeId = Console.ReadLine();
            //parse input
            var keyNums= calc.parseEmployeeIdInput(strEmployeeId);
            //calculate minimum typing time
            int typingTime = calc.CalculateMinTypingTime(keyNums);

            Console.WriteLine(typingTime);
            
        }
    }
   
    public class TypingTimeCalculator
    {

        Dictionary<string,int> dictKeyTypingTimeCombinations { get; set; }

        public TypingTimeCalculator()
        {
            InitializeTypingTimeCombinations();
        }

        private void InitializeTypingTimeCombinations()
        {
            dictKeyTypingTimeCombinations = new Dictionary<string, int>();

            dictKeyTypingTimeCombinations.Add("1,1", 0);
            dictKeyTypingTimeCombinations.Add("1,245", 1);
            dictKeyTypingTimeCombinations.Add("1,36789",2);

            dictKeyTypingTimeCombinations.Add("2,2", 0);
            dictKeyTypingTimeCombinations.Add("2,13456", 1);
            dictKeyTypingTimeCombinations.Add("2,789", 2);

            dictKeyTypingTimeCombinations.Add("3,3", 0);
            dictKeyTypingTimeCombinations.Add("3,256", 1);
            dictKeyTypingTimeCombinations.Add("3,14789", 2);

            dictKeyTypingTimeCombinations.Add("4,4", 0);
            dictKeyTypingTimeCombinations.Add("4,12578", 1);
            dictKeyTypingTimeCombinations.Add("4,369", 2);

            dictKeyTypingTimeCombinations.Add("5,5", 0);
            dictKeyTypingTimeCombinations.Add("5,12346789", 1);
           

            dictKeyTypingTimeCombinations.Add("6,6", 0);
            dictKeyTypingTimeCombinations.Add("6,23589", 1);
            dictKeyTypingTimeCombinations.Add("6,147", 2);

            dictKeyTypingTimeCombinations.Add("7,7", 0);
            dictKeyTypingTimeCombinations.Add("7,458", 1);
            dictKeyTypingTimeCombinations.Add("7,12369", 2);

            dictKeyTypingTimeCombinations.Add("8,8", 0);
            dictKeyTypingTimeCombinations.Add("8,45679", 1);
            dictKeyTypingTimeCombinations.Add("8,123", 2);

            dictKeyTypingTimeCombinations.Add("9,9", 0);
            dictKeyTypingTimeCombinations.Add("9,568", 1);
            dictKeyTypingTimeCombinations.Add("9,12347", 2);


        }

        public List<string> parseEmployeeIdInput(string strEmployeeId)
        {
            return strEmployeeId.Select(c => c.ToString()).ToList();
            
         }

        private List<string> getDictKeys()
        {
            return dictKeyTypingTimeCombinations.Keys.ToList();
        }


        private string findKey(List<string> keyList,string curKey,string nextKey)
        {
            

            var possibleKeys = keyList.Where(x => x.StartsWith(curKey)).ToList();

            foreach(string s in possibleKeys)
            {
                var keyPile = s.Split(',')[1];
                if(keyPile.Contains(nextKey))
                {
                    return s;
                }

            }

            return string.Empty;
        }

        public int CalculateMinTypingTime(List<string> keyNums)
        {
            string curKey = string.Empty;
            string nextKey = string.Empty;
            string key = string.Empty;

            int typingTime = 0;
            var keyList = getDictKeys();

            for (int i = 0; i <=keyNums.Count-2; i++)
            {
                
                curKey = keyNums[i];
                
                nextKey = keyNums[i + 1];

                if (curKey != nextKey) //same keys yield zero input time
                {
                    key = findKey(keyList, curKey, nextKey);

                    if (!string.IsNullOrEmpty(key))
                    {
                        typingTime += Convert.ToInt32(dictKeyTypingTimeCombinations[key]);
                    }
                }
            }
            return typingTime;
        }
    }


   
}