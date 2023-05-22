using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra3
{
    public interface IGraph<VertexType>
    {
        void SetWeight(VertexType u, VertexType v, double w);
        List<VertexType> GetVertices();
        List<VertexType> GetNeighbors(VertexType vertex);
        double GetWeight(VertexType u, VertexType v);
    }
}
