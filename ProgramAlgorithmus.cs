using namespaceStuktur;
using namespaceUtility;
using System;
using System.Collections;
using System.Collections.Generic;

namespace namespaceAlgorithmus
{
    class Algorithmus
    {
        public List<Node> visitList = new List<Node>();
        public List<Node> unVisitList = new List<Node>();

        public double result = 0;

        public void zeitOfAlgorithmus(string path, String methode, int startId, int endI, bool directed)
        {
            Console.WriteLine(methode);

            Algorithmus algorithmus = new Algorithmus();

            Graph graph = Parse.getGraphByFile(path, directed);

            DateTime befor = System.DateTime.Now;

            if (methode == "Dijkstra")
            {
                algorithmus.dijkstra(graph, startId, endI);
            }
            else
            {
                algorithmus.MooreBellmanFord(graph, startId, endI);
            }

            DateTime after = System.DateTime.Now;
            TimeSpan ts = after.Subtract(befor);
            Console.WriteLine("\n\n{0}s \n", ts.TotalSeconds);
        }

        public void dijkstra(Graph graph, int startId, int endId)
        {
            //init
            foreach (Node node in graph.nodeList)
            {
                if (node.id == startId)
                {
                    node.weight = 0;
                    visitList.Add(node);
                }
                else
                {
                    node.weight = Double.MaxValue;
                    unVisitList.Add(node);
                }
            }


            Node minNode = graph.nodeList[startId];
            while (minNode.id != endId)
            {
                foreach (Edge e in minNode.edgeList)
                {
                    double weight = minNode.weight + e.weight;

                    if (weight < e.endNode.weight)
                    {
                        e.endNode.weight = weight;
                        // Console.WriteLine(e.endNode + "," + e.endNode.weight);
                    }
                }

                minNode = findMinNode();

                visitList.Add(minNode);
                unVisitList.Remove(minNode);
            }

            Console.WriteLine(endId + " result:" + Math.Round(graph.nodeList[endId].weight, 5));

        }

        public Node findMinNode()
        {
            double min = Double.MaxValue;
            Node node = null;
            foreach (Node n in unVisitList)
            {
                if (n.weight < min)
                {
                    min = n.weight;
                    node = n;
                }
            }

            return node;
        }




        public void MooreBellmanFord(Graph graph, int startId, int endId)
        {
            //init
            foreach (Node node in graph.nodeList)
            {
                if (node.id == startId)
                {
                    node.weight = 0;
                }
                else
                {
                    node.weight = Double.MaxValue;
                }
            }

            bool negativeCycle = false;

            for (int i = 0; i < graph.nodeList.Count; i++)
            {
                //Console.WriteLine("-------------------------------------");
                foreach (Edge e in graph.edgeList)
                {
                    // Console.WriteLine("" + e.startNode+"----"+ e.endNode);

                    double weight = e.startNode.weight + e.weight;

                    if (e.startNode.weight < double.MaxValue && weight < e.endNode.weight)
                    {
                        // Console.WriteLine("node:"+ e.endNode);
                        //Console.WriteLine("weight:" + weight);
                        //Console.WriteLine("vater:" + e.startNode);

                        e.endNode.previousNode = e.startNode;
                        e.endNode.weight = weight;
                    }

                }

            }

            //negativeCycle checken!
            foreach (Edge e in graph.edgeList)
            {
                // Console.WriteLine("" + e.startNode + "----" + e.endNode);
                if (e.startNode.weight < double.MaxValue)
                {
                    double weight = e.startNode.weight + e.weight;

                    if (weight < e.endNode.weight)
                    {
                        negativeCycle = true;
                        break;
                    }
                }
            }


            if (negativeCycle)
            {
                Console.WriteLine("negativeCycle");
            }
            else
            {
                Console.WriteLine(display(endId, graph) + " result:" + Math.Round(graph.nodeList[endId].weight, 5));
            }
        }




        public string display(int endId, Graph graph)
        {
            return endId + "," + findVater(graph.nodeList[endId], graph);
        }

        public string findVater(Node node, Graph graph)
        {
            if (node.previousNode != null)
            {
                Edge e = graph.findEdge(node.previousNode, node);
                result = result + e.weight;
                return node.previousNode + "," + findVater(node.previousNode, graph);
            }
            else
            {
                return "";
            }
        }
    }
}
