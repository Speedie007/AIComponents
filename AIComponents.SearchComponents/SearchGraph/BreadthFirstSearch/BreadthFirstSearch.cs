using AiComponents.Graph;
using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.BaseSearchComponents;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.SearchGraph.BreadthFirstSearch
{
    public partial class BreadthFirstSearch<TGraph, TVertex, TEdge, TResultSet> :
        BaseBreadthFirstSearch<TGraph, TVertex, TEdge, TResultSet>

        // where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>, new()
        where TGraph : BaseGraph<TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        public BreadthFirstSearch(TGraph graph, TVertex startVertexNode = null, TVertex endVertexNode = null) : base(graph, startVertexNode, endVertexNode)
        {
        }

        //public BreadthFirstSearch(
        //    TGraph graph,
        //    TVertex startVertexNode = default,
        //    TVertex endVertexNode = default) : base(graph, startVertexNode, endVertexNode)
        //{
        //}

        public override event EventHandler<TVertex> OnForwardGrapNodeFound;
        public override event EventHandler<TVertex> OnReverseGrapNodeFound;

        public override void ExcuteSearch()
        {
            //TResultSet result = new TSearchResult();
            //Ensure That the Graph and Search Queue is correctly initialized by Restting to defaults before starting the BFS.
            //ResetSearch();
            var resultSet = SearchResult.GenerateNewResultSet();
            // Mark the current node(Starting Node) as visited and enqueue it
            var vertexNode = Graph.GetVertex(StartVertexNode.GetNodeIdentifier());
            vertexNode.MarkNodeAsVisited();
            OnForwardGrapNodeFound.Invoke(this, vertexNode);
            resultSet.PreOrder_ForwardTracking.Add(vertexNode);

            ForwardFrontierQueue.Enqueue(vertexNode);

            while (ForwardFrontierQueue.Count > 0)
            {
                // Dequeue a vertex from queue and Process it
                var currentNode = ForwardFrontierQueue.Dequeue();

                // Get all adjacent vertices of the dequeued
                // vertex currentNode If an adjacent has not
                // been visited, then mark it visited and
                // enqueue it
                foreach (var edge in Graph.GetEdges(currentNode).Where(x => !x.GetAdjacentVertex().IsVisited))
                {
                    var adjacentVertexNode = Graph.GetVertex(edge.GetAdjacentVertex().GetNodeIdentifier());
                    if (!adjacentVertexNode.IsVisited)
                    {
                        adjacentVertexNode.MarkNodeAsVisited();
                        OnForwardGrapNodeFound.Invoke(this, vertexNode);
                        resultSet.PreOrder_ForwardTracking.Add(adjacentVertexNode);
                        ForwardFrontierQueue.Enqueue(adjacentVertexNode);
                    }
                }
            }

            SearchResult.ResultSets.Add(resultSet);

        }

        protected override void ForwardGrapNodeFoundEventHandler(object sender, TVertex e)
        {
            //Console.WriteLine($"Forward Node Found/Visted: Search:{nameof(BreadthFirstSearch)},{this.GetType()}, NodeId:{e.NodeDataContext.Id}");
        }

        protected override void ReverseGrapNodeFoundEventHandler(object sender, TVertex e)
        {
            //Console.WriteLine($"Reverse Node Found/Visted: Search:{nameof(BreadthFirstSearch)},{this.GetType()}, NodeId:{e.NodeDataContext.Id}");
        }
    }
}
