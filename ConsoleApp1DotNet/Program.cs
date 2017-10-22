//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace PromoCodeMappingSolution
//{
//    class ConsoleApp
//    {
//        static void Main(string[] args)
//        {
//            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
//            PromoCodeValidator vldtr = new PromoCodeValidator();

//            vldtr.GetUserPromoData();
//            vldtr.ParsePromoValidations();

//            Console.Read();

//        }


//    }

//    public class PromoCodeValidator
//    {
//        Dictionary<string, string> dictUserPromoCodes;
//        List<string> lstPromoValidations { get; set; }

//        public PromoCodeValidator()
//        {
//            dictUserPromoCodes = new Dictionary<string, string>();
//            lstPromoValidations = new List<string>();
//        }

//        public void GetUserPromoData()
//        {
//            int numPromoData, numPromoValidations = 0;
//            //accept number of user promo code data
//            var strNumPromoData = Console.ReadLine();
//            if(!int.TryParse(strNumPromoData,out numPromoData))
//            {
//                Console.WriteLine("Invalid number lines of User Promo Data");
//                return;
//            }
//            //accept user promo code data
//            for (int i = 1; i <= numPromoData; i++)
//            {
//                ParseUserPromoLineInput(Console.ReadLine());
//            }
//            //accept number of promo validations
//            var strNumPromoValiations = Console.ReadLine();
//            if (!int.TryParse(strNumPromoValiations, out numPromoValidations))
//            {
//                Console.WriteLine("Invalid number lines of User Promo Validations");
//                return;
//            }

//            for (int i = 1; i <= numPromoData; i++)
//            {
//                lstPromoValidations.Add(Console.ReadLine());
//            }
//        }

//        private void ParseUserPromoLineInput(string input)
//        {
//            string[] tokens = input.Split(',');

//            //assumption is that the first item is the user and rest are promo codes
//            if(tokens.Length>0)
//            {
//                string strUser = tokens[0];

//                //only user and no promo codes
//                if (tokens.Length==1)
//                {
//                    dictUserPromoCodes.Add(strUser, string.Empty);
//                }
//                else
//                {
//                    dictUserPromoCodes.Add(strUser, input);
//                }


//            }
//        }

//        public void ParsePromoValidations()
//        {
//            foreach(string s in lstPromoValidations)
//            {
//                if(string.IsNullOrEmpty(s))
//                {
//                    continue;
//                }
//                string[] tokens = s.Split(',');

//                if(tokens.Length==0)
//                {
//                    continue;
//                }

//                string strUser = tokens[0];
//                string strPromoCode = tokens.Length>1?tokens[1]:string.Empty;

//                ValidatePromoCode(strUser, strPromoCode);

//            }
//        }

//        private void ValidatePromoCode(string strUser,string strPromoCode)
//        {

//            //Invalid User check
//            if (!dictUserPromoCodes.ContainsKey(strUser))
//                Console.WriteLine("Invalid User");
//            else
//            //No Promo Code check
//            if (dictUserPromoCodes[strUser]==string.Empty)
//            {
//                Console.WriteLine("No Promo Code");
//            }
//            else
//            // Code check
//            if (dictUserPromoCodes[strUser].Contains(strPromoCode))
//            {
//                Console.WriteLine("Valid Code");
//            }
//            else
//            {
//                Console.WriteLine("Invalid Code");
//            }
//        }
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ArraySort
{
   

    public class ArraySort
    {

        
        static public void Main()
        {
            
            //user input
            Console.WriteLine("Enter First Array (items separated by space)");
            string fArray = Console.ReadLine();
            Console.WriteLine("Enter second Array (items separated by space)");
            string sArray = Console.ReadLine();

            string[] arr1 = readFirstArray(fArray);
            string[] arr2 = readSecondArray(sArray);

            Console.WriteLine("\nLoop based Approach");
            LoopBased(arr1, arr2);
            Console.WriteLine("\nRecursive Approach");
            FirstTry(arr1, arr2);
            Console.WriteLine("\nMerge Sort Approach");
            SecondTry(arr1, arr2);
            
                      
            Console.Read();
        }

        
        public static void LoopBased(string[] arr1,string[] arr2)
        {
            var watch = Stopwatch.StartNew();

            int arr1Length = arr1.Length;
            int arr2Length = arr2.Length;
            int combinedLength = arr1Length + arr2Length;
            int combinedArrayIndex = 0;
            string [] combinedArray = new string[combinedLength];

            //add items to combined array
            for (int i = 0; i < arr1Length; i++)
            {
                combinedArray[combinedArrayIndex] = arr1[i];
                combinedArrayIndex++;
            }

            for (int j=0;j<arr2Length;j++)
                {
                combinedArray[combinedArrayIndex] = arr2[j];
                combinedArrayIndex++;
            }

            //sort combined array via swap
            for(int k=0;k<combinedLength-1;k++)
            {
                for (int m = k + 1; m < combinedLength ; m++)
                {
                    if (string.Compare(combinedArray[k], combinedArray[m]) > 0)
                    {
                        swap(ref combinedArray[k], ref combinedArray[m]);
                    }
                }
            }
            watch.Stop();
            double es = (double)watch.ElapsedMilliseconds;
            Console.WriteLine("Took " + watch.ElapsedTicks + " Ticks");
            Console.WriteLine("Took " + es + " milliseconds");
            watch = null;
            PrintArray(combinedArray);

    }
         
        public static void FirstTry(string[] arr1, string[] arr2)
        {
            var watch = Stopwatch.StartNew();

            int arr1Length = arr1.Length;
            int arr2Length = arr2.Length;
            int arr1Counter = 0;
            int arr2Counter = 0;
            int combinedLength = arr1Length + arr2Length;
            int combinedArrayIndex = 0;
            string[] combinedArray = new string[combinedLength];

            RecursiveCompare(ref arr1, ref arr2, ref arr1Counter, ref arr2Counter,ref combinedArray,ref combinedArrayIndex );
            watch.Stop();
            double es = (double)watch.ElapsedMilliseconds;
            Console.WriteLine("Took " + watch.ElapsedTicks + " Ticks");
            Console.WriteLine("Took " + es + " milliseconds");
            watch = null;
            PrintArray(combinedArray);
        }

        public static void SecondTry(string[] arr1, string[] arr2)
        {
            var watch = Stopwatch.StartNew();
            int arr1Length = arr1.Length;
            int arr2Length = arr2.Length;
            int combinedLength = arr1Length + arr2Length;
            int combinedArrayIndex = 0;
            string[] combinedArray = new string[combinedLength];

            int i = 0, j = 0;
            while(i<arr1Length)
            {
                //check validity of second array
                if(j<arr2Length)
                {
                    if(arr1[i]==arr2[j])
                    {
                        combinedArray[combinedArrayIndex] = arr1[i];
                        combinedArrayIndex++;
                        i++;
                        combinedArray[combinedArrayIndex] = arr2[j];
                        combinedArrayIndex++;
                        j++;
                    }
                    
                    else if(string.Compare(arr1[i],arr2[j])<0)
                    {
                        combinedArray[combinedArrayIndex] = arr1[i];
                        combinedArrayIndex++;
                        i++;
                    }
                    else
                    {
                        combinedArray[combinedArrayIndex] = arr2[j];
                        combinedArrayIndex++;
                        j++;
                    }
                }
                else
                {
                    //add remaining elements of first array
                    combinedArray[combinedArrayIndex] = arr1[i];
                    combinedArrayIndex++;
                    i++;
                }
            }
            if(j<arr2Length)
            {
                while (j<arr2Length)
                {
                    combinedArray[combinedArrayIndex] = arr2[j];
                    combinedArrayIndex++;
                    j++;
                }
            }
            watch.Stop();
            double es = (double)watch.ElapsedMilliseconds;
            Console.WriteLine("Took " + watch.ElapsedTicks + " Ticks");
            Console.WriteLine("Took " + es + " milliseconds");
            watch = null;
            PrintArray(combinedArray);
        }

        #region Private Methods
        private static string[] readFirstArray(string input)
        {
            string[] tokens = input.Split(' ');
            if (tokens.Length == 0 || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided for first array. Sample input will be used.");
                return new string[] { "abc", "add", "bfg", "bhg" };
            }
            else
                return tokens;
        }

        private static string[] readSecondArray(string input)
        {
            string[] tokens = input.Split(' ');
            if (tokens.Length == 0 || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided for second array. Sample input will be used.");
                return new string[] { "acd", "aed", "beg" };
            }
            else
                return tokens;
        }
        private static void PrintArray(string[] combinedArray)
        {
            for (int n = 0; n < combinedArray.Length; n++)
            {
                Console.WriteLine(combinedArray[n]);
            }
        }

        private static void RecursiveCompare(ref string[] arr1,ref string[] arr2,ref int arr1Counter,ref int arr2Counter,ref string[] combinedArray,ref int combinedArrayIndex)
            {
           // var c = Stopwatch.StartNew();
            

            //exit criteria
            if (arr1Counter == arr1.Length && arr2Counter == arr2.Length)
            {
                return;
            }
            
                //if one of the array items have been exhausted
                if (arr1Counter  == arr1.Length || arr2Counter  == arr2.Length)
            {
                //if second array items have been exhausted
                if(arr2Counter== arr2.Length)
                {
                    //add remaining items of first array recursively
                    combinedArray[combinedArrayIndex] = arr1[arr1Counter];
                    combinedArrayIndex++;
                    arr1Counter++;
                   // c.Stop();
                   // Console.WriteLine("rec " + recursionCounter + ": " + c.ElapsedTicks + " ticks");
                    RecursiveCompare(ref arr1, ref arr2, ref arr1Counter, ref arr2Counter, ref combinedArray, ref combinedArrayIndex);
                }
                
                else 
                //if first array items have been exhausted
                if (arr1Counter== arr1.Length)
                {
                    //add remaining items of second array recursively
                    combinedArray[combinedArrayIndex] = arr2[arr2Counter];
                    combinedArrayIndex++;
                    arr2Counter++;
                   // c.Stop();
                   // Console.WriteLine("rec " + recursionCounter + ": " + c.ElapsedTicks + " ticks");
                    RecursiveCompare(ref arr1, ref arr2, ref arr1Counter, ref arr2Counter, ref combinedArray, ref combinedArrayIndex);
                }

            }
            else
            {
                //if items are equal
                if (arr1[arr1Counter] == arr2[arr2Counter])
                {
                    combinedArray[combinedArrayIndex] = arr1[arr1Counter];
                    combinedArrayIndex++;
                    arr1Counter++;
                    combinedArray[combinedArrayIndex] = arr2[arr2Counter];
                    combinedArrayIndex++;
                    arr2Counter++;
                    //c.Stop();
                   // Console.WriteLine("rec " + recursionCounter + ": " + c.ElapsedTicks + " ticks");
                    RecursiveCompare(ref arr1, ref arr2, ref arr1Counter, ref arr2Counter, ref combinedArray, ref combinedArrayIndex);
                }
                //if first item of first array is alphabetically first
                else if (string.Compare(arr1[arr1Counter], arr2[arr2Counter]) < 0)
                {
                    combinedArray[combinedArrayIndex] = arr1[arr1Counter];
                    combinedArrayIndex++;
                    arr1Counter++;
                   // c.Stop();
                   // Console.WriteLine("rec " + recursionCounter + ": " + c.ElapsedTicks + " ticks");
                    //swap arrays - send second array for further comparison
                    RecursiveCompare(ref arr2, ref arr1, ref arr2Counter, ref arr1Counter, ref combinedArray, ref combinedArrayIndex);
                }
                //if first item of second array is alphabetically first
                else if (string.Compare(arr1[arr1Counter], arr2[arr2Counter]) > 0)
                {
                    combinedArray[combinedArrayIndex] = arr2[arr2Counter];
                    combinedArrayIndex++;
                    arr2Counter++;
                   // c.Stop();
                   // Console.WriteLine("rec " + recursionCounter + ": " + c.ElapsedTicks + " ticks");
                    //send first array for further comparison
                    RecursiveCompare(ref arr1, ref arr2, ref arr1Counter, ref arr2Counter, ref combinedArray, ref combinedArrayIndex);
                }
            }
            
        }

        private static void swap(ref string s1, ref string s2)
        {
            string temp = s1;
            s1 = s2;
            s2 = temp;

        }
        #endregion

    }

    
    



}