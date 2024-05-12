using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{
    public abstract partial class BaseNodeEventArgs : EventArgs, INodeEventArgs//<TNodeContext>
         //where TNodeContext : NodeBaseContextEntity
    {
        public BaseGraphNode NodeItem { get; private set; }

        public BaseNodeEventArgs(BaseGraphNode nodeItem)
        {
            NodeItem = nodeItem;
        }
    }
}
