using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra3
{
    public class SimpleGraph : IGraph<int>
    {
        private const double NF = double.PositiveInfinity;
        private double[,] Table;

        public SimpleGraph(int numVertices)
        {
            Table = new double[numVertices, numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    Table[i, j] = NF;
                }
            }
        }

        public List<int> GetVertices()
        {
            var result = new List<int>();

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                result.Add(i + 1);
            }

            return result;
        }
        public List<int> GetNeighbors(int vertex)
        {
            var result = new List<int>();

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                if (Table[vertex - 1, i] < NF && vertex - 1 != i)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        public void SetWeight(int u, int v, double w)
        {
            Table[u - 1, v - 1] = w;
        }

        public double GetWeight(int u, int v)
        {
            return Table[u - 1, v - 1];
        }
    }
}
