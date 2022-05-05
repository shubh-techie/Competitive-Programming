using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.GraphDemo
{
    public class GraphHelper
    {
        public List<List<int>> printGraph(int V, List<List<int>> adj)
        {
            List<List<int>> adjNew = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
                adjNew.Add(new List<int>() { 1 });
                adjNew[i].Add(i);
                foreach (var neigh in adj[i])
                {
                    adjNew[i].Add(neigh);
                }
            }
            return adjNew;
        }

        List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            List<int> result = new List<int>();
            if (adj == null || adj.Count == 0) return result;

            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            visited[0] = true;
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                result.Add(vertex);
                foreach (var neigh in adj[vertex])
                {
                    if (visited[neigh] == false)
                    {
                        visited[neigh] = true;
                        queue.Enqueue(neigh);
                    }
                }
            }

            return result;
        }


        public List<int> dfsOfGraph(int V, List<List<int>> adj)
        {
            List<int> result = new List<int>();
            if (adj == null || adj.Count == 0) return result;
            bool[] visited = new bool[V];
            dfsOfGraphHelper(adj, visited, result, 0);
            return result;
        }

        private void dfsOfGraphHelper(List<List<int>> adj, bool[] visited, List<int> result, int currNode)
        {
            result.Add(currNode);
            visited[currNode] = true;
            foreach (var neighNode in adj[currNode])
            {
                if (visited[neighNode] == false)
                    dfsOfGraphHelper(adj, visited, result, neighNode);
            }
        }

        public int numIslands(ref List<List<int>> grid)
        {
            int result = 0;
            if (grid == null || grid.Count == 0) return result;
            int rows = grid.Count;
            int cols = grid[0].Count;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        checkedIsland(grid, i, j, rows, cols);
                        result++;
                    }
                }
            }
            return result;
        }

        private void checkedIsland(List<List<int>> grid, int i, int j, int row, int col)
        {
            if (i < 0 || j < 0 || i >= row || j >= col || grid[i][j] != 1) return;
            grid[i][j] = -1;

            int[] rDirection = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] cDirection = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int k = 0; k < 8; k++)
            {
                checkedIsland(grid, i + rDirection[k], j + cDirection[k], row, col);
            }
        }

        public bool isCycle(int V, List<List<int>> adj)
        {
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false && isCycleHelper(adj, i, -1, visited))
                    return true;
            }

            return false;
        }

        private bool isCycleHelper(List<List<int>> adj, int sourceNode, int parentNode, bool[] visited)
        {
            visited[sourceNode] = true;

            foreach (var neighNode in adj[sourceNode])
            {
                if (visited[neighNode] == false)
                {
                    if (isCycleHelper(adj, neighNode, sourceNode, visited))
                        return true;
                }
                else if (neighNode != parentNode)
                    return true;

            }

            return false;
        }

        private bool isCycleHelper1(List<List<int>> adj, int sourceNode, int parentNode, bool[] visited)
        {
            if (visited[sourceNode] == true)
                return false;

            if (sourceNode != parentNode)
                return true;

            visited[sourceNode] = true;
            foreach (var neighNode in adj[sourceNode])
            {
                if (isCycleHelper(adj, neighNode, sourceNode, visited))
                    return true;
            }

            return false;
        }

        public bool isCyclicinCylic(int V, List<List<int>> adj)
        {
            HashSet<int> path = new HashSet<int>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < V; i++)
            {
                if (!visited.Contains(i) && isCyclicinCylicHelper(adj, i, visited, path))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isCyclicinCylicHelper(List<List<int>> adj, int currNode, HashSet<int> visited, HashSet<int> path)
        {
            if (path.Contains(currNode))
                return true;
            if (visited.Contains(currNode))
                return false;

            visited.Add(currNode);
            path.Add(currNode);

            foreach (var neighNode in adj[currNode])
            {
                if (isCyclicinCylicHelper(adj, neighNode, visited, path))
                    return true;
            }
            path.Remove(currNode);
            return false;
        }

        public bool is_Possible(ref List<List<int>> grid)
        {
            int rows = grid.Count, cols = grid[0].Count;
            bool[,] visited = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1 && !visited[i, j] && is_PossibleHelper(grid, i, j, rows, cols, visited))
                        return true;

                }
            }

            return false;
        }

        private bool is_PossibleHelper(List<List<int>> grid, int i, int j, int rows, int cols, bool[,] visited)
        {
            if (grid[i][j] == 2) return true;
            int[] rNo = { 1, -1, 0, 0 };
            int[] cNo = { 0, 0, +1, -1 };

            visited[i, j] = true;

            for (int k = 0; k < 4; k++)
            {
                if (isValid(grid, i + rNo[k], j + cNo[k], rows, cols, visited))
                {
                    if (is_PossibleHelper(grid, i + rNo[k], j + cNo[k], rows, cols, visited))
                        return true;
                }
            }
            return false;
        }

        private bool isValid(List<List<int>> grid, int row, int col, int rows, int cols, bool[,] visited)
        {
            return row >= 0 && col >= 0 && row < rows && col < cols && grid[row][col] == 3 && visited[row, col] == false;
        }


        public List<int> topoSort(int V, List<List<int>> adj)
        {
            int[] indegree = new int[V];
            for (int i = 0; i < V; i++)
            {
                foreach (var item in adj[i])
                {
                    indegree[item]++;
                }
            }

            Queue<int> queue = new Queue<int>();
            foreach (var item in indegree)
            {
                if (item == 0)
                    queue.Enqueue(item);
            }

            List<int> result = new List<int>();

            while (queue.Count > 0)
            {
                int pVertex = queue.Dequeue();
                result.Add(pVertex);
                
                foreach (var nVertex in adj[pVertex])
                {
                    indegree[nVertex]--;
                    if (indegree[nVertex] == 0)
                        queue.Enqueue(nVertex);
                }
            }

            return result; 
        }
    }
}
