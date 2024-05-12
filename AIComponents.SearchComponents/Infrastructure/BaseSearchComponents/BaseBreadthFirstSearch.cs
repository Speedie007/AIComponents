using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract partial class BaseBreadthFirstSearch< TGraph, TVertex, TEdge, TResultSet> :
        BaseGraphSearch< TGraph, TVertex, TEdge, TResultSet>,
        IGraphBreadthFirstSearch< TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge< TVertex>, new()
        where TGraph : BaseGraph< TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        public BaseBreadthFirstSearch(
            TGraph graph,
            TVertex startVertexNode = default,
            TVertex endVertexNode = default) : base(graph, startVertexNode, endVertexNode)
        {
            ForwardFrontierQueue = new Queue<TVertex>();
            ReverseFrontierQueue = new Queue<TVertex>();
        }

        public Queue<TVertex> ForwardFrontierQueue { get; private set; }
        public Queue<TVertex> ReverseFrontierQueue { get; private set; }

        public override void ResetSearch()
        {
            base.ResetSearch();
            ForwardFrontierQueue.Clear();
            ReverseFrontierQueue.Clear();
        }
    }
}
