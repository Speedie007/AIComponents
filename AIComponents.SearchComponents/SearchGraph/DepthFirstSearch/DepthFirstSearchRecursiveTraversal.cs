using AiComponents.Graph.BaseComponents;
using AIComponents.Common.Errors;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.BaseSearchComponents;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.SearchGraph.DepthFirstSearch
{
    public partial class DepthFirstSearchRecursiveTraversal<TGraph, TVertex, TEdge, TResultSet> :

        BaseGraphSearch<TGraph, TVertex, TEdge, TResultSet>,
        IGraphDepthFirstSearch<TVertex>

       // where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode
        where TEdge : BaseGraphEdge<TVertex>, new()
        where TGraph : BaseGraph<TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {

        public DepthFirstSearchRecursiveTraversal(TGraph graph, TVertex startVertexNode = default, TVertex endVertexNode = default) : base(graph, startVertexNode, endVertexNode)
        {
            ForwardFrontierStack = new Stack<TVertex>();
            ReverseFrontierStack = new Stack<TVertex>();
        }

        public Stack<TVertex> ForwardFrontierStack { get; private set; }
        public Stack<TVertex> ReverseFrontierStack { get; private set; }

        public override event EventHandler<TVertex> OnForwardGrapNodeFound;
        public override event EventHandler<TVertex> OnReverseGrapNodeFound;

        public override void ExcuteSearch()
        {
            //Ensure That the Graph and Search Queue is correctly initialized by Restting to defaults before starting the BFS.
            ResetSearch();

            // Mark the current node(Starting Node) as visited and enqueue it
            var vertexNode = Graph.GetVertex(StartVertexNode.GetNodeIdentifier());
            var resultSet = SearchResult.GenerateNewResultSet();
            //Before We Begin transversing the graph the starting node is added to the frontier/Stack as it is the first item to be inspected.
            ExecuteDepthFirstSearchRecersiveTraversal(vertexNode, resultSet);
            //SearchResult.SaveError(new GeneralError("Before TopologicalSortDFS"));
            SearchResult.ResultSets.Add(resultSet); 
            //SearchResult.LogResults();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex">
        /// <para>This is that starting point(Node/vertex) within the graph.</para>
        /// <para>The Node Model/Object Will come from you internal graph DataStructure which is an AdjecentList.</para>
        /// <para>The Node Houses the following properties:=> Id,IsVisited,Depth(Depth - NOT USED HERE!) </para>
        /// <para>You can add any properies you my require for processing logic goal search or any other relivant requirements.</para>
        /// </param>
        /// <returns>Integer value indicating how many nodes where visited</returns>
        private void ExecuteDepthFirstSearchRecersiveTraversal(TVertex vertex, TResultSet resultSet)
        {
            /*******************************
             * Pocess Node Per-Ordering Here
             * *****************************/
            resultSet.PreOrder_ForwardTracking.Add(vertex);
            /********************************/
            vertex.MarkNodeAsVisited();
            foreach (var edge in Graph.GetEdges(vertex).Where(x => !x.GetAdjacentVertex().IsVisited))
            {
                var adjacentVertex = edge.GetAdjacentVertex();
                if (!adjacentVertex.IsVisited)
                    ExecuteDepthFirstSearchRecersiveTraversal(adjacentVertex, resultSet);
            }
            /*******************************
            * Pocess Node Post-Ordering Here
            * *****************************/
            resultSet.PostOrder_BackTracking.Add(vertex);
            /********************************/
        }
        

        protected override void ForwardGrapNodeFoundEventHandler(object sender, TVertex e)
        {
            Console.WriteLine($"Forward Node Found/Visted: Search:{nameof(BreadthFirstSearch)},{this.GetType()}, NodeId:{e.NodeDataContext.Id}");
        }

        protected override void ReverseGrapNodeFoundEventHandler(object sender, TVertex e)
        {
            Console.WriteLine($"Reverse Node Found/Visted: Search:{nameof(BreadthFirstSearch)},{this.GetType()}, NodeId:{e.NodeDataContext.Id}");
        }
    }
}
