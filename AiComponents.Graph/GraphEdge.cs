

using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;


namespace AiComponents.Graph
{
    public partial class GraphEdge< TVertex> : BaseGraphEdge< TVertex>
         //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        public GraphEdge() : base() { }
        public GraphEdge(TVertex vertexNode, TVertex adjacentNode) : base(vertexNode, adjacentNode)
        {
        }
    }

}
