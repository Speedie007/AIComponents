using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.SearchComponents.Infrastructure.Interfaces.Graph.Result
{
    public partial interface IGraphResultSet<TVertex>
    {
        List<TVertex> PreOrder_ForwardTracking { get; }
        List<TVertex> PostOrder_BackTracking { get; }
    }
}
