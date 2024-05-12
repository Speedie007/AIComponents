using AIComponents.Data.Domain;
using AiComponents.Graph.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph.Result;

namespace AIComponents.SearchComponents.SearchGraph.Result.ResultSets
{
    public abstract partial class BaseGraphResultSet<TVertex> : IGraphResultSet<TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        public BaseGraphResultSet()
        {
            PreOrder_ForwardTracking = new List<TVertex>();
            PostOrder_BackTracking = new List<TVertex>();
        }

        public List<TVertex> PreOrder_ForwardTracking { get; private set; }
        public List<TVertex> PostOrder_BackTracking { get; private set; }


    }
}
