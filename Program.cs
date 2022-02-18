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

            int antal = 10000;

            List<int> list = new List<int>();
            for(int i = 0; i < antal; i++){
                list.Add(rnd.Next());
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            list.Sort();
            stopwatch.Stop();
            
            // Bubble Sort 
            List<int> bblList = new List<int>();

            for(int a = 0; a < antal; a++){
                bblList.Add(rnd.Next());
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

            for(int c = 0; c < antal; c++){
                unsorted.Add(rnd.Next());
            }

            Stopwatch mergeSW = new Stopwatch();
            
            mergeSW.Start();

            MergeSort(unsorted);

            mergeSW.Stop();

            //Quick Sort
            List<int> quickUnsorted = new List<int>();

            for(int d = 0; d < antal; d++){
                quickUnsorted.Add(rnd.Next());
            }

            Stopwatch quickSW = new Stopwatch();
            quickSW.Start();

            QuickSort(quickUnsorted, 0, quickUnsorted.Count - 1);

            quickSW.Stop();

            Console.WriteLine($"Default sorting thing: {stopwatch.ElapsedMilliseconds} \nMerge Sort: {mergeSW.ElapsedMilliseconds} \nQuick Sort: {quickSW.ElapsedMilliseconds} \n{quickSW.ElapsedTicks}");

            //\nBubble Sort: {bblSW.ElapsedMilliseconds} \nInsertion Sort: {insSW.ElapsedMilliseconds}  
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

        private static void QuickSort(List<int> list, int left, int right)
        {
            if(left < right){
                int pivot = Partition(list, left, right);

                if(pivot > 1){
                    QuickSort(list, left, pivot - 1);
                }
                if(pivot + 1 < right){
                    QuickSort(list, pivot + 1, right);
                }
            }
        }

        private static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[left];
            while (true)
            {   
                while(list[left] < pivot)
                {
                    left++;
                } 

                while(list[right] > pivot)
                {
                    right--;
                }

                if(left < right)
                {
                    if(list[left] == list[right]) return right;
                
                    int temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
