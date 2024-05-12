using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.BaseSearchComponents;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.SearchGraph.DepthFirstSearch
{
    public partial class DepthFirstSearchIterativeTraversal<TGraph, TVertex, TEdge, TResultSet> :
        BaseDepthFirstSearchIterativeTraversal<TGraph, TVertex, TEdge, TResultSet>,
        IGraphDepthFirstSearch<TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>, new()
        where TGraph : BaseGraph<TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        public DepthFirstSearchIterativeTraversal(TGraph graph, TVertex startVertexNode = null, TVertex endVertexNode = null) : base(graph, startVertexNode, endVertexNode)
        {

        }

        public override event EventHandler<TVertex> OnForwardGrapNodeFound;
        public override event EventHandler<TVertex> OnReverseGrapNodeFound;

        public override void ExcuteSearch()
        {
            //Ensure That the Graph and Search Queue is correctly initialized by Restting to defaults before starting the BFS.
            ResetSearch();

            // Mark the current node(Starting Node) as visited and enqueue it
            var vertexNode = Graph.GetVertex(StartVertexNode.GetNodeIdentifier());
            //Before We Begin transversing the graph the starting node is added to the frontier/Stack as it is the first item to be inspected.
            ExecuteDepthFirstSearchIterativeTraversal(vertexNode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartingVertex">
        /// <para>This is that starting point(Node/Vertex) within the graph.</para>
        /// <para>The Node Model/Object Will come from you internal graph DataStructure which is an AdjecentList.</para>
        /// <para>The Node Houses the following properties:=> Id,IsVisited,Depth(Depth - NOT USED HERE!) </para>
        /// <para>You can add any properies you my require for processing logic goal search or any other relivant requirements.</para>
        /// </param>
        /// <returns>Integer value indicating how many nodes where visited</returns>
        private void ExecuteDepthFirstSearchIterativeTraversal(TVertex StartingVertex)
        {

            var resultSet = SearchResult.GenerateNewResultSet();
            //Before We Begin transversing the graph the starting node is added to the frontier/Stack as it is the first item to be inspected.
            ForwardFrontierStack.Push(StartingVertex);

            // var ReverseFrontierStack = new Stack<TVertex>();

            while (ForwardFrontierStack.Count() > 0 || ReverseFrontierStack.Count() > 0)
            {
                if (ForwardFrontierStack.Count == 0)
                {
                    while (ForwardFrontierStack.Count == 0 && ReverseFrontierStack.Count > 0)
                    {
                        var CurrentNodeBeingBackTracked = ReverseFrontierStack.Peek();
                        var currentEdges = Graph.GetEdges(CurrentNodeBeingBackTracked);
                        if (Graph.GetEdges(CurrentNodeBeingBackTracked).Any(x => !x.GetAdjacentVertex().IsVisited))
                            //Add to the ForwardFrontierStack For Processing
                            ForwardFrontierStack.Push(CurrentNodeBeingBackTracked);
                        else
                            resultSet.PostOrder_BackTracking.Add(ReverseFrontierStack.Pop());
                    }
                }
                else
                {
                    var CurrentNodeBeingVisited = ForwardFrontierStack.Pop();

                    //Bit of a difference for the normal process of tracking the node with seperate Vistied Datastore.
                    //Instead the KeyNode for the AdjcencyList(Graph Structure is used) since in the base implementation all the relevant info is in the model/Class which can be reused from a central location.
                    //This was done as we are not working with integers here and allows a central point to manage the model that you create.
                    //In other words if you want to add custom properties for you model(Node) for other possible prossing logic such as goal searching criteria or processing logic its housed and access from one central point.
                    if (!CurrentNodeBeingVisited.IsVisited)//IF => NOT VISITED...
                    {
                        CurrentNodeBeingVisited.MarkNodeAsVisited();
                        resultSet.PreOrder_ForwardTracking.Add(CurrentNodeBeingVisited);
                        //Get associated edges from the graph structure(AdjacencyList)
                        var edges = Graph.GetEdges(CurrentNodeBeingVisited);

                        if (edges.Any(x => !x.GetAdjacentVertex().IsVisited))
                        {
                            ReverseFrontierStack.Push(CurrentNodeBeingVisited);
                        }
                        else
                        {
                            resultSet.PostOrder_BackTracking.Add(CurrentNodeBeingVisited);
                        }
                        //in this case the edge is a  to the vertex object reference stored in the graph(AdjacencyList)
                        foreach (var edge in edges)
                        {
                            /*uncomment this line of code to get the edgeModel which contains the metadata about the edge.
                             * This is if you wish to/require details such as weights or other custom details you added to the model.
                             * ********************************************************************************************************/
                            //EdgeModel NodeEdge = GetEdge(CurrentNodeBeingVisited.Id, edgeToId);

                            /*Get a the next related node object from the graph that forms the edge defined.
                             * Note this is important for this implementation as we need a reference the Node/Vertex object 
                             * stored as the key of the AdjacencyList
                             * ********************************************************************************************/
                            if (!edge.GetAdjacentVertex().IsVisited)
                            {
                                ForwardFrontierStack.Push(Graph.GetVertex(edge.GetAdjacentVertex().GetNodeIdentifier()));
                            }
                        }
                    }
                }

            }
            SearchResult.ResultSets.Add(resultSet);
        }


        //public override void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<TNodeContext> args)
        //{

        //    Console.WriteLine($"DFS Node Item - {args.NodeItem} Level Changed To {args.NewLeveL} Pervious Level {args.PreviousLevel}");
        //}

        //public override void VertexNodeVisited(NodeVisitedEventArgs<TNodeContext> args)
        //{
        //    // PreOrder_ForwardTracking.Add(args.NodeItem as TVertex);
        //    Console.WriteLine($"Next DFS Node Items To Be Processed - {args.NodeItem.GetNodeIdentifier()}");
        //}

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
