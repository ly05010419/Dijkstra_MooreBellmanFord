﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace namespaceStuktur
{

    class Graph
    {
        public List<Node> nodeList;

        public List<Edge> edgeList;

        public Edge[,] array;

        public Graph(List<Node> nodeList, List<Edge> edgeList)
        {
            this.nodeList = nodeList;
            this.edgeList = edgeList;

            array = new Edge[nodeList.Count, nodeList.Count];

            foreach (Edge e in edgeList) {
                array[e.startNode.id,e.endNode.id] = e;
                array[e.endNode.id,e.startNode.id] = e;
            }
        }


        public void reset() {
            foreach (Node d in nodeList) {
                d.visited = false;
            }
        }


        public Edge findEdge(Node startNode,Node endNode)
        {
            Edge edge = array[startNode.id, endNode.id];
            return edge;
        }

    }

    class MST
    {
        public List<Node> nodeList;

        public List<Edge> edgeList;

        public MST(List<Edge> edgeList,int size)
        {
            
            this.edgeList = edgeList;
            this.nodeList = new List<Node>();

            for (int i = 0; i < size; i++)
            {
                Node node = new Node(i);
                nodeList.Add(node);
            }

            foreach (Edge edge in edgeList)
            {
               
                Node startNode = nodeList[edge.startNode.id];
                Node endNode = nodeList[edge.endNode.id];

                startNode.edgeList.Add(edge);
                endNode.edgeList.Add(edge);

                startNode.nodeList.Add(endNode);
                endNode.nodeList.Add(startNode);

                startNode.distance = edge.distance;
                endNode.distance = edge.distance;
            }

        }


        public void reset()
        {
            foreach (Node d in nodeList)
            {
                d.visited = false;
            }

        }


    }

    class Node : IComparable<Node>
    {
        public int id;

        public List<Edge> edgeList;

        public List<Node> nodeList;

        public bool visited = false;

        public double distance;

        public Node previousNode;

        public Node(int id)
        {
            this.id = id;
            this.edgeList = new List<Edge>();
            this.nodeList = new List<Node>();
            this.distance = float.MaxValue;
        }

        public int CompareTo(Node other)
        {
            return this.distance.CompareTo(other.distance);
        }

        public override string ToString()
        {
            return "" + id;
        }

    }

    class Edge : IComparable<Edge>
    {
        public Node endNode;
        public Node startNode;
        public double distance;

        public Edge(Node startNode, Node endNode, double weight)
        {
            this.startNode = startNode;
            this.endNode = endNode;
            this.distance = weight;
        }

        public int CompareTo(Edge other)
        {
           return this.distance.CompareTo(other.distance);
        }
    }

   


}