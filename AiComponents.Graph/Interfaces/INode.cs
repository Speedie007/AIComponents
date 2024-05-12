using AiComponents.Graph.Events;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Interfaces
{
    public partial interface INode : IComparable<INode>
         //where TNodeContext : NodeBaseContextEntity
    {
        NodeBaseContextEntity NodeDataContext { get; }

        //event NodeVisitedEventHandler<TNodeContext> OnNodeVisited;
        //event LastNodeVisitedEventHandler<TNodeContext> OnLastNodeVisited;
        //event FirstNodeVisitedEventHandler<TNodeContext> OnFirstNodeVisited;
        //event NodeLevelEventHandler<TNodeContext> OnNodeLevelChanged;
    }
}
