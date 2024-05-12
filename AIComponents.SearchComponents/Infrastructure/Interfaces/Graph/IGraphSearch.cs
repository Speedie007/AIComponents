using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph.Result;
using AIComponents.SearchComponents.SearchGraph.Result;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.Infrastructure.Interfaces.Graph
{
    public partial interface IGraphSearch<TGraph, TVertex, TEdge, TResultSet>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>, new()
        where TGraph : BaseGraph<TVertex, TEdge>
         where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        event EventHandler<TVertex> OnForwardGrapNodeFound;
        TGraph Graph { get; }
        GraphSearchResult<TVertex, TResultSet> SearchResult { get; }
        void ExcuteSearch();
        void ResetSearch();
        void SetStartingNode(TVertex startingVertexNode);
        void SetEndNode(TVertex endVertexNode);
        //void VertexNodeVisited(NodeVisitedEventArgs<TNodeContext> args);
        ////void ProcessFirstVisitedVertexNode(FirstNodeVisitedEventArgs<TNodeContext> args);
        ////void ProcessLastVisitedVertexNode(LastNodeVisitedEventArgs<TNodeContext> args);
        //void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<TNodeContext> args);


    }
}
