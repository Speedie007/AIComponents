using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{
    public partial class FirstNodeVisitedEventArgs : BaseNodeEventArgs//<TNodeContext>
        //where TNodeContext : NodeBaseContextEntity
    {
        public FirstNodeVisitedEventArgs(BaseGraphNode nodeItem) : base(nodeItem)
        {
        }
    }
}
