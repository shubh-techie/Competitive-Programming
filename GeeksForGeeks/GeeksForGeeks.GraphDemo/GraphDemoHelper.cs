using System;
using System.Collections.Generic;

namespace GeeksForGeeks.GraphDemo
{
    public class GraphDemoHelper
    {
        public GraphDemoHelper()
        {
            Console.WriteLine("GraphDemoHelper learning start");

            GraphBasicDemo();

            Console.WriteLine("GraphDemoHelper learning end");
        }

        private void GraphBasicDemo()
        {
            MyGraph myGraph = new MyGraph(5);

            myGraph.AddEdgesUnDirectedGraph(0, 1);
            myGraph.AddEdgesUnDirectedGraph(0, 2);
            myGraph.AddEdgesUnDirectedGraph(1, 3);
            myGraph.AddEdgesUnDirectedGraph(1, 2);
            myGraph.AddEdgesUnDirectedGraph(2, 3);

            //myGraph.PrintGraph();

            myGraph.BFSGraph(0);
            myGraph.DfsGraph(myGraph.AdjencyList, 5, 0);
            myGraph.DfsUsingStack();
            ShortestPath(myGraph.AdjencyList, 0);

            DeductCycle(myGraph.AdjencyList, myGraph.VertexCount);
            DeductCycleinDirectGraph(myGraph.AdjencyList, myGraph.VertexCount);
        }

        private bool DeductCycleinDirectGraph(List<List<int>> adjencyList, int vertexCount)
        {
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> trackPath = new HashSet<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                if (!visited.Contains(i) && DeductCycleinDirectGrapHelper(adjencyList, visited, i, trackPath))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DeductCycleinDirectGrapHelper(List<List<int>> adjencyList, HashSet<int> visited, int source, HashSet<int> trackPath)
        {
            if (trackPath.Contains(source))
                return true;

            if (visited.Contains(source))
                return false;

            visited.Add(source);
            trackPath.Add(source);
            foreach (var neigh in adjencyList[source])
            {
                if (DeductCycleinDirectGrapHelper(adjencyList, visited, neigh, trackPath))
                    return true;
            }

            trackPath.Remove(source);
            return false;
        }

        private bool DeductCycle(List<List<int>> adjencyList, int vertexCount)
        {
            bool[] visited = new bool[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                if (visited[i] != false && HasCycleCheck(adjencyList, visited, i, -1))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasCycleCheck(List<List<int>> adjencyList, bool[] visited, int source, int parent)
        {
            visited[source] = true;

            foreach (var neighbour in adjencyList[source])
            {
                if (visited[neighbour] == false && HasCycleCheck(adjencyList, visited, neighbour, source))
                    return true;
                else if (neighbour != parent)
                    return true;
            }

            return false;
        }

        private void ShortestPath(List<List<int>> adjencyList, int source)
        {
            List<int> path = new List<int> { 0, 0, 0, 0, 0 };
            bool[] visited = new bool[adjencyList.Count];
            Queue<int> queue = new Queue<int>();
            ShortestPathHelper(adjencyList, source, path, visited, queue);
            Console.WriteLine("Path : " + string.Join(',', path));
        }

        private void ShortestPathHelper(List<List<int>> adjencyList, int source, List<int> path, bool[] visited, Queue<int> queue)
        {
            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int pVertex = queue.Dequeue();
                foreach (var nVertex in adjencyList[pVertex])
                {
                    if (visited[nVertex] == false)
                    {
                        path[nVertex] = path[pVertex] + 1;
                        visited[nVertex] = true;
                        queue.Enqueue(nVertex);
                    }
                }
            }
        }
    }
}
