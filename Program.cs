using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SorteringsAlgoritmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> bblList = new List<int>();
            List<int> insList = new List<int>();

            Stopwatch bblSW = new Stopwatch();
            Stopwatch insSW = new Stopwatch();
            Stopwatch mergeSW = new Stopwatch();

            int antal = 10000;

            for (int i = 0; i < antal; i++)
            {
                bblList.Add(rnd.Next());
                insList.Add(rnd.Next());
            }

            // Bubblesort 
            int listLength = bblList.Count;
            
            bblSW.Start();
            
            for(int bblA = 0; bblA < (listLength - 1); bblA++){
                for(int bblB = 0; bblB < (listLength - 1 - bblA); bblB++){
                    if(bblList[bblB] > bblList[bblB + 1]){
                        int bblC = bblList[bblB + 1];
                        bblList[bblB + 1] = bblList[bblB];
                        bblList[bblB] = bblC;
                    }
                }
            }

            bblSW.Stop();
            
            //Insertionsort
            int Lengthlist = insList.Count;
            
            insSW.Start();
            for(int insA = 1; insA < Lengthlist; ++insA){
                int key = insList[insA];
                int insB = insA - 1;

                while(insB >= 0 && insList[insB] > key){
                    insList[insB + 1] = insList[insB];
                    insB = insB - 1;
                }
                insList[insB + 1] = key;
            }

            insSW.Stop();

            //Merge sort
            mergeSW.Start();

            List<int> unsorted = new List<int>();
            List<int> sorted;

            for(int a = 0; a< antal;a++){
                unsorted.Add(rnd.Next(0, 100));
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            mergeSW.Stop();

            Console.WriteLine("Bubblesort: " + bblSW.ElapsedMilliseconds);
            Console.WriteLine("Insertionsort: " + insSW.ElapsedMilliseconds);
            Console.WriteLine("Merge sort: " + mergeSW.ElapsedMilliseconds);


        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    if(left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }  
                }

                else if(left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }

                else if(right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
