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

            int antal = 1000;

            // Bubble Sort 
            List<int> bblList = new List<int>();

            for(int a = 0; a < antal; a++){
                bblList.Add(rnd.Next(0, 100));
            }
            
            int listLength = bblList.Count;

            Stopwatch bblSW = new Stopwatch();
            
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
            
            //Insertion Sort
            List<int> insList = new List<int>();

            for (int b = 0; b < antal; b++)
            {
                insList.Add(rnd.Next());
            }

            int Lengthlist = insList.Count;

            Stopwatch insSW = new Stopwatch();
            
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

            //Merge Sort
            List<int> unsorted = new List<int>();
            List<int> sorted;

            for(int c = 0; c< antal;c++){
                unsorted.Add(rnd.Next(0, 100));
            }

            Stopwatch mergeSW = new Stopwatch();
            
            mergeSW.Start();

            sorted = MergeSort(unsorted);

            mergeSW.Stop();

            Console.WriteLine("Bubble Sort: " + bblSW.ElapsedMilliseconds);
            Console.WriteLine("Insertion Sort: " + insSW.ElapsedMilliseconds);
            Console.WriteLine("Merge Sort: " + mergeSW.ElapsedMilliseconds);
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