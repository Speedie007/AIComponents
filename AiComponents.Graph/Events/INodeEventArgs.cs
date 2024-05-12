using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{
    public partial interface INodeEventArgs//<TNodeContext>
        //where TNodeContext : NodeBaseContextEntity
    {
        BaseGraphNode NodeItem { get; }
    }
}
