/* 
This program will print a breadth first search traversal
from a given source vertex.

The function, BFS(int s) traverses vertices reachable from s.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BREADTHFIRSTSEARCH {

    
    // This class represents a directed graph using adjacency list representation
    class Graph {

        // Number of vertices
        private int numV;

        // Adjacency Lists
        LinkedList<int>[] adj;

        public Graph(int v) {
            adj = new LinkedList<int>[v];

            for(int i = 0; i < adj.Length; i++) {
                adj[i] = new LinkedList<int>();
            }
            numV = v;
        }
        
        // Function to add an edge into the graph
        public void AddEdge(int v, int w) {
            adj[v].AddLast(w);
        }

        // Function to print BFS traversal from a given source "s"
        public void BFS(int s) {

            // Mark all the vertices as not visited (Set to false by default)
            bool[] visited = new bool [numV];
            for (int i = 0; i < numV; i++) {
                visited[i] = false;
            }

            // Create a que for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as visited and enque it
            visited[s] = true;
            queue.AddLast(s);

            while(queue.Any()) {

                // Dequeue a vertex from queue and print it
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                // Get all adjacent vertices of the dequeued vertex s.
                // If an adjacent has not been visited, then mark it visited and enqueue it.
                LinkedList<int> list = adj[s];
                foreach(var val in list) {
                    if(!visited[val]) {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }

        // Driver code to test the methods of the Graph Class
        static void Main(string[] args) {

            // Create a graph
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.Write("Following is Breadth First " + "Traversal starting from vertex 2) ");

            g.BFS(2);
        }
    }
}