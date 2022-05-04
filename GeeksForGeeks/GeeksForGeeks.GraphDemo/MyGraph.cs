using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.GraphDemo
{
    public class MyGraph
    {
        public int VertexCount;
        public List<List<int>> AdjencyList;

        public MyGraph(int vertexCount)
        {
            this.VertexCount = vertexCount;
            this.AdjencyList = new List<List<int>>();
            for (int i = 0; i < VertexCount; i++)
            {
                AdjencyList.Add(new List<int>());
            }
        }

        public void AddEdges(int vNo, int vNode)
        {
            AdjencyList[vNo].Add(vNode);
        }

        public void AddEdgesUnDirectedGraph(int vNo, int vNode)
        {
            AdjencyList[vNo].Add(vNode);
            AdjencyList[vNode].Add(vNo);
        }

        public void PrintGraph()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                List<int> nodes = this.AdjencyList[i];
                Console.Write(i);
                for (int j = 0; j < nodes.Count; j++)
                {
                    Console.Write("-> " + nodes[j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print the graph in Breath first search
        /// </summary>
        /// <param name="sVertex"></param>
        public void BFSGraph(int sVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(sVertex);
            visited.Add(sVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                List<int> allAdj = this.AdjencyList[vertex];
                for (int i = 0; i < allAdj.Count; i++)
                {
                    if (!visited.Contains(allAdj[i]))
                    {
                        visited.Add(allAdj[i]);
                        queue.Enqueue(allAdj[i]);
                    }
                }
            }

            Console.WriteLine();
        }

        public void DfsGraph(List<List<int>> adj, int nVertex, int source)
        {
            bool[] visited = new bool[nVertex];
            DFSHelper(adj, source, visited);
            Console.WriteLine();
        }

        private void DFSHelper(List<List<int>> adj, int source, bool[] visited)
        {
            visited[source] = true;
            Console.Write(source + " ");

            List<int> nNode = adj[source];
            foreach (var item in nNode)
            {
                if (visited[item] == false)
                    DFSHelper(adj, item, visited);
            }
        }

        public void DfsForDisconnectedGraph(List<List<int>> adj, int nVertex, int source)
        {
            bool[] visited = new bool[nVertex];
            for (int i = 0; i < nVertex; i++)
            {
                if (visited[i] == false)
                    DFSHelper(adj, source, visited);
            }
            Console.WriteLine();
        }

        public void DfsUsingStack()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[this.VertexCount];
            stack.Push(0);
            visited[0] = true;
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
                List<int> neightAdj = this.AdjencyList[node];
                for (int i = 0; i < neightAdj.Count; i++)
                {
                    if (visited[neightAdj[i]] == false)
                    {
                        visited[neightAdj[i]] = true;
                        stack.Push(neightAdj[i]);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
