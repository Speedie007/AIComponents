using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Events
{
    public partial class NodeLevelEventArgs : BaseNodeEventArgs//<TNodeContext> 
        //where TNodeContext : NodeBaseContextEntity
    {
        public int PreviousLevel { get; set; }
        public int NewLeveL { get; }

        public NodeLevelEventArgs(BaseGraphNode nodeItem, int previousLevel, int newLeveL) : base(nodeItem)
        {
            PreviousLevel = previousLevel;
            NewLeveL = newLeveL;
        }

         
    }
}
