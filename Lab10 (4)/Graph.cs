using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10__4_
{
    class Graph
    {
        private int V = 0;

        private int[,] graph = null;

        public Graph(int[,] matrix, int numOfVert)
        {
            graph = matrix;
            V = numOfVert;
        }

        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }

        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            int[] vPath = new int[V];

            int[] checkedv = new int[V];
            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] > -1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;
                        if (j == endPos)
                        {
                           return backChain(vPath, startPos, endPos);
                        }
                        
                    }
                }
            }
            return null;
        }
       
    }
}
