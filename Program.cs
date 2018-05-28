using namespaceAlgorithmus;
using System;

namespace DijkstraMooreBellmanFord
{
    class Program
    {

        static void Main(string[] args)
        {
            Algorithmus algorithmus = new Algorithmus();
            //algorithmus.zeitOfAlgorithmus(@"../../Wege/Wege1.txt", "Dijkstra",2,0, true);
            //algorithmus.zeitOfAlgorithmus(@"../../Wege/Wege1.txt", "MooreBellmanFord", 2, 0, true);

            
            algorithmus.zeitOfAlgorithmus(@"../../Wege/Wege2.txt", "MooreBellmanFord", 2, 0, true);

            
            //algorithmus.zeitOfAlgorithmus(@"../../Wege/Wege3.txt", "MooreBellmanFord", 2, 0, true);

            //algorithmus.zeitOfAlgorithmus(@"../../Wege/G_1_2.txt", "Dijkstra",0,1,true);
            //algorithmus.zeitOfAlgorithmus(@"../../Wege/G_1_2.txt", "Dijkstra", 0, 1, false);
            //algorithmus.zeitOfAlgorithmus(@"../../Wege/G_1_2.txt", "MooreBellmanFord" ,0, 1, true);
           // algorithmus.zeitOfAlgorithmus(@"../../Wege/G_1_2.txt", "MooreBellmanFord", 0, 1, false);


            Console.WriteLine("\n");
            Console.ReadLine();
        }

    }
}
