using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{

    public partial class NodeVisitedEventArgs: BaseNodeEventArgs//<TNodeContext>
        //where TNodeContext : NodeBaseContextEntity
    {
        public NodeVisitedEventArgs(BaseGraphNode nodeItem) : base(nodeItem)
        {

        }

         
    }
}
