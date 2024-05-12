

using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;
using System;

namespace AiComponents.Graph
{
    public partial class GraphWeightedEdge< TVertex, TWeightType> :
        GraphEdge< TVertex>,
        IGraphWeightedEdge< TVertex, TWeightType>

        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
         where TWeightType: unmanaged
    {
        public GraphWeightedEdge() : base()
        {
           // Metric = (TWeightType)default;
        }

        public GraphWeightedEdge(
            TVertex vertexNode,
            TVertex adjacentNode,
            TWeightType metric) : base(vertexNode, adjacentNode)
        {
            Metric = metric;
        }

        public TWeightType Metric { get; private set; }

    }
}
