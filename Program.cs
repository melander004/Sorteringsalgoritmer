using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorteringsalgoritmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> rndList = new List<int>();
            List<int> randList = new List<int>();

            Stopwatch sw = new Stopwatch();
            Stopwatch stopwatch = new Stopwatch();


            for (int i = 0; i < 1000; i++)
            {
                rndList.Add(rnd.Next());
                randList.Add(rnd.Next());
            }

            // Bubblesort 
            int listLength = rndList.Count;
            
            sw.Start();
            
            for(int a = 0; a < (listLength - 1); a++){
                for(int b = 0; b < (listLength - 1 - a); b++){
                    if(rndList[b] > rndList[b + 1]){
                        int c = rndList[b + 1];
                        rndList[b + 1] = rndList[b];
                        rndList[b] = c;
                    }
                }
            }

            sw.Stop();
            
            //Insertionsort
            int Lengthlist = randList.Count;
            
            stopwatch.Start();
            for(int d = 1; d < Lengthlist; ++d){
                int key = randList[d];
                int e = d - 1;

                while(e >= 0 && randList[e] > key){
                    randList[e + 1] = randList[e];
                    e = e - 1;
                }
                randList[e + 1] = key;
            }

            stopwatch.Stop();

            Console.WriteLine("Bubblesort: " + sw.ElapsedMilliseconds);
            Console.WriteLine("Insertionsort: " + stopwatch.ElapsedMilliseconds);

        }
    }
}
