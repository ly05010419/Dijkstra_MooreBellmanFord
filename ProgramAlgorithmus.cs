using namespaceStuktur;
using namespaceUtility;
using System;
using System.Collections;
using System.Collections.Generic;

namespace namespaceAlgorithmus
{
    class Algorithmus
    {
        public List<Node> unVisitList = new List<Node>();

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
                    node.distance = 0;
                }
                else
                {
                    node.distance = Double.MaxValue;
                    unVisitList.Add(node);
                }
            }


            Node minNode = graph.nodeList[startId];
            while (unVisitList.Count>0)
            {
                foreach (Edge e in minNode.edgeList)
                {
                    double distance = minNode.distance + e.distance;

                    if (distance < e.endNode.distance)
                    {
                        e.endNode.distance = distance;
                        e.endNode.previousNode = e.startNode;
                    }
                }

                minNode = getMinNode();
                unVisitList.Remove(minNode);
            }

            Console.WriteLine(display(endId, graph) + " result:" + Math.Round(graph.nodeList[endId].distance, 5));

        }

        public Node getMinNode()
        {
            double min = Double.MaxValue;
            Node node = null;
            foreach (Node n in unVisitList)
            {
                if (n.distance < min)
                {
                    min = n.distance;
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
                    node.distance = 0;
                }
                else
                {
                    node.distance = Double.MaxValue;
                }
            }

            bool negativeCycle = false;

            for (int i = 0; i < graph.nodeList.Count-1; i++)
            {
                foreach (Edge e in graph.edgeList)
                {
                    double weight = e.startNode.distance + e.distance;

                    if (weight < e.endNode.distance)
                    {
                        e.endNode.previousNode = e.startNode;
                        e.endNode.distance = weight;
                    }

                }

            }

            //negativeCycle checken!
            foreach (Edge e in graph.edgeList)
            {
                if (e.startNode.distance < double.MaxValue)
                {
                    double weight = e.startNode.distance + e.distance;

                    if (weight < e.endNode.distance)
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
                Console.WriteLine(display(endId, graph) + " result:" + Math.Round(graph.nodeList[endId].distance, 5));
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
                return node.previousNode + "," + findVater(node.previousNode, graph);
            }
            else
            {
                return "";
            }
        }
    }
}
