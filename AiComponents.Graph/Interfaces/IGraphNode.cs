using AIComponents.Data.Domain;

namespace AiComponents.Graph.Interfaces
{
    public partial interface IGraphNode//<TNodeContext> 
        : INode//<TNodeContext>
         //where TNodeContext : NodeBaseContextEntity
    {
        int Level { get; }
        bool IsVisited { get; }
        bool IsStartNode { get; }
        bool IsEndNode { get; }
        void IncrementLevel();
        void MarkNodeAsVisited();
        void SetAsStartingNode();
        void SetAsEndNode();
        void RemoveAsStartingNode();
        void RemoveAsEndNode();
        /// <summary>
        /// 
        /// </summary>
        int GetNodeIdentifier();
        void ResetLevel();
        void ResetVisited();



    }
}
