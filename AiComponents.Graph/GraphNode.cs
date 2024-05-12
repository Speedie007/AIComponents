

using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events;
using AIComponents.Data.Domain;

namespace AiComponents.Graph
{
    public partial class GraphNode//<TNodeContext> 
        : BaseGraphNode//<TNodeContext> 
       // where TNodeContext : NodeBaseContextEntity
    {
        
        public GraphNode(NodeBaseContextEntity vertexNode, bool isStartNode = false, bool isEndNode = false) : base(vertexNode, isStartNode, isEndNode)
        {
           
        }

        //public override event NodeVisitedEventHandler? OnNodeVisited;
    }
}
