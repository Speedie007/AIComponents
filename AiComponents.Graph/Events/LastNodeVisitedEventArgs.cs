using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{
    public partial class LastNodeVisitedEventArgs : BaseNodeEventArgs//<TNodeContext> 
        //where TNodeContext : NodeBaseContextEntity
    {
        //public LastNodeVisitedEventArgs(BaseGraphNode<TNodeContext> nodeItem) : base(nodeItem)
        //{
        //}

        public LastNodeVisitedEventArgs(BaseGraphNode nodeItem, int deepestLevel = 0) : base(nodeItem)
        {
            DeepestLevel = deepestLevel;
        }

        public int DeepestLevel { get; }
    }
}
