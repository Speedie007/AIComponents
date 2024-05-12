

using AiComponents.Graph.Interfaces;
using AIComponents.Common.Errors;
using AIComponents.Common.Interfaces;
using AIComponents.Common.Result;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.BaseComponents
{
    public abstract partial class BaseGraph<TVertex, TEdge> : IGraph<TVertex, TEdge>
        // where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>, new()
    {
        #region cstor
        public BaseGraph(bool isDirectedGraph = false)
        {
            //Intitilse the AdacencyList to represent the graph
            GraphAdjacencyList = new SortedList<TVertex, LinkedList<TEdge>>();
            IsDirectedGraph = isDirectedGraph;
        }
        public BaseGraph(List<TVertex> vertexNodes, bool isDirectedGraph = false) : this(isDirectedGraph)
        {
            //Populate the Model with the verties provided, will still need to add the relivant edges seperately.
            foreach (var node in vertexNodes)
                if (node != null)
                    GraphAdjacencyList.TryAdd(node, new LinkedList<TEdge>());
        }
        public BaseGraph(List<KeyValuePair<TVertex, LinkedList<TEdge>>> allVertexNodesWithEdges, bool isDirectedGraph = false) : this(isDirectedGraph)
        {
            //Populate the Model with the verties provided, will still need to add the relivant edges seperately.
            GraphAdjacencyList = new SortedList<TVertex, LinkedList<TEdge>>(allVertexNodesWithEdges.ToDictionary());

        }
        #endregion

        /// <summary>
        /// A collection of edges E, represented as ordered pairs of vertices (u,v)- ParentNode and ChildNode
        /// </summary>
        public SortedList<TVertex, LinkedList<TEdge>> GraphAdjacencyList { get; private set; } = new SortedList<TVertex, LinkedList<TEdge>>();
        public bool IsDirectedGraph { get; private set; }

        public virtual bool TryAddVertex(TVertex vertex)
        {
            return GraphAdjacencyList.TryAdd(vertex, new LinkedList<TEdge>());
        }
        public virtual List<TVertex> GetAllLeafNodes()
        {
            var leafNodes = new List<TVertex>();
            foreach (var node in GraphAdjacencyList.Where(x => x.Value.Count == 0))
                leafNodes.Add(node.Key);
            return leafNodes;
        }

        public bool HasEdges(TVertex vertexNode)
        {
            //LinkedList<TEdge> edgeList;
            if (GraphAdjacencyList.TryGetValue(vertexNode, out LinkedList<TEdge>? edgeList))
                return edgeList.Count() > 0;
            return false;

        }
        public virtual IResult TryAddEdge(TEdge edge)
        {
            var result = new GeneralResult();
            //if (edge == null)
            //    result.SaveError(new GeneralError($"Edge is Null unable to add the Graph Edge for {typeof(TEdge).Name}"));
            //if (!result.Success)
            //    return result;

            var forwardVertex = edge.GetVertex();
            var adjecentVertex = edge.GetAdjacentVertex();

            if (forwardVertex == null)
                result.SaveError(new GeneralError($"Forward Vertex Null unable to add the Graph Edge for {GetType().Name}"));

            if (adjecentVertex == null)
                result.SaveError(new GeneralError($"Adjecent Vertex Null unable to add the Graph Edge for {GetType().Name}"));


            if (result.Success)
            {
                TryAddVertex(forwardVertex);
                if (GraphAdjacencyList.TryGetValue(forwardVertex, out var forwardVertexNodeAdjacencyList))
                {
                    var forwardEdge = new TEdge();
                    forwardEdge.Edge = new KeyValuePair<TVertex, TVertex>(forwardVertex, adjecentVertex);

                    if (!ContainsEdge(forwardVertex, forwardEdge))
                        forwardVertexNodeAdjacencyList.AddLast(forwardEdge);
                }
                else
                    result.SaveError(new GeneralError($"Unable to locate edge list for {forwardVertex.GetType().Name}, Vertex Id:{forwardVertex.GetNodeIdentifier()}"));

                if (!IsDirectedGraph && result.Success)
                {
                    TryAddVertex(adjecentVertex);
                    if (GraphAdjacencyList.TryGetValue(adjecentVertex, out var reverseVertexNodeAdjacencyList))
                    {
                        var reverseEdge = new TEdge();
                        reverseEdge.Edge = new KeyValuePair<TVertex, TVertex>(adjecentVertex, forwardVertex);

                        if (!ContainsEdge(adjecentVertex, reverseEdge))
                            reverseVertexNodeAdjacencyList.AddLast(reverseEdge);
                    }
                    else
                        result.SaveError(new GeneralError($"Unable to locate edge list for {adjecentVertex.GetType().Name}, Vertex Id:{adjecentVertex.GetNodeIdentifier()}"));
                }

            }
            //result.SaveError(new GeneralError($"Simulation ERROR - unable to add the Graph Edge for {GetType().Name}[{typeof(TNodeContext).Name}-{typeof(TVertex).Name}-{typeof(TEdge).Name}]"));
            //if (!result.Success)
            //{
            //    result.LogResults();
            //}
            return result;
        }
        //public virtual bool TryAddEdge(BaseGraphEdge<TNodeContext,TVertex> forwardEdge, BaseGraphEdge<TNodeContext, TVertex> reverseEdge)
        public virtual bool TryAddEdge(TEdge forwardEdge, TEdge reverseEdge)
        {
            //if (vertexNode == null)
            //    return false;// throw new ArgumentNullException(nameof(vertexNode), "The Vertex(Parent NodeDataContext) Can not be Null!.");
            //else
            //    TryAddVertex(vertexNode);
            if (forwardEdge == null)
                return false;// throw new ArgumentNullException(nameof(forwardEdge), $"The Edge {nameof(forwardEdge)}  for Vertex(Parent NodeDataContext) ID:{vertexNode.Id} Can not be Null!.");

            //Add Forward Edge to the node
            //Check if it not already added to the AdjcenyList
            TVertex forwardVertexNode = forwardEdge.GetVertex();
            //Ensure that the Node Exists in the Graph
            if (!HasVertex(forwardVertexNode))
                TryAddVertex(forwardVertexNode);

            if (GraphAdjacencyList.TryGetValue(forwardVertexNode, out var forwardVertexNodeAdjacencyList))
            {
                var forwardEdgeAdded = false;
                //var forwardEdge = new KeyValuePair<TNodeContext, TNodeContext>(vertexNode, forwardEdgeNode);
                //Ensure the integrity of the data structure test to ensure that the forwardEdge vertex(ChildNode) is not already Added.
                if (!ContainsEdge(forwardVertexNode, (TEdge)forwardEdge))
                {
                    forwardVertexNodeAdjacencyList.AddLast((TEdge)forwardEdge);
                    forwardEdgeAdded = true;
                }
                else//Already Exists
                    forwardEdgeAdded = true;
                if (!IsDirectedGraph)
                {

                }
                if (!IsDirectedGraph)
                {
                    var reverseEdgeAdded = false;
                    var AdjecentVertex = reverseEdge.GetVertex();
                    if (!HasVertex(AdjecentVertex))
                        TryAddVertex(AdjecentVertex);

                    //if the adjecnt node exists 
                    if (GraphAdjacencyList.TryGetValue(AdjecentVertex, out var reverseVertexNodeAdjacencyList))
                    {

                        //Ensure the integrity of the data structure test to ensure that the forwardEdge vertex(ChildNode) is not already Added.
                        if (!ContainsEdge(AdjecentVertex, (TEdge)reverseEdge))
                        {
                            reverseVertexNodeAdjacencyList.AddLast((TEdge)reverseEdge);
                            reverseEdgeAdded = true;
                        }
                        else//Already Added/Exists for the adjecent Node edges.
                            reverseEdgeAdded = true;

                        return reverseEdgeAdded;
                    }
                }
                else
                {
                    return forwardEdgeAdded;
                }
            }

            return false;
        }

        public virtual TEdge? GetEdge(TVertex vertexNode, TVertex adjacentNode)
        {
            if (GraphAdjacencyList.TryGetValue(vertexNode, out var vertexNodeAdjacencyList))
                return vertexNodeAdjacencyList.Where(x => x.GetAdjacentVertex().GetNodeIdentifier() == adjacentNode.GetNodeIdentifier()).FirstOrDefault();
            else
                return default;
        }

        public bool TryRemoveEdge(TVertex vertexNode, TEdge edge)
        {
            if (GraphAdjacencyList.TryGetValue(vertexNode, out var vertexNodeAdjacencyList))
                foreach (TEdge currentEdge in vertexNodeAdjacencyList)
                    if (currentEdge.GetAdjacentVertex().GetNodeIdentifier() == edge.GetAdjacentVertex().GetNodeIdentifier())
                        return vertexNodeAdjacencyList.Remove(currentEdge);

            return false;
        }

        public bool HasVertex(TVertex vertexNode)
        {
            return GraphAdjacencyList.ContainsKey(vertexNode);
        }

        public LinkedList<TEdge> GetEdges(TVertex vertexNode)
        {
            if (GraphAdjacencyList.TryGetValue(vertexNode, out var vertexNodeAdjacencyList))
                return vertexNodeAdjacencyList;
            else
                return new LinkedList<TEdge>();
        }

        public TVertex GetVertex(int nodeId)
        {
            return GraphAdjacencyList.Keys.FirstOrDefault(x => x.GetNodeIdentifier() == nodeId);
        }

        public bool ContainsEdge(TVertex vertexNode, TEdge edge)
        {
            if (GraphAdjacencyList.TryGetValue(vertexNode, out var nodeAdjacencyList))
            {
                var adjacentNode = nodeAdjacencyList.Where(x => x.GetAdjacentVertex().GetNodeIdentifier() == edge.GetAdjacentVertex().GetNodeIdentifier()).FirstOrDefault();
                if (adjacentNode != null)
                    return true;

                return false;
            }
            else
                return false;
        }

        public virtual double GetEdgeWeight(TEdge edge)
        {
            return 0;
        }

        public virtual bool SetEdgeWeight(TEdge edge, double edgeWeight = 0)
        {
            return false;
        }

        public bool IsTree()
        {
            var amountOfNodes = GraphAdjacencyList.Keys.Count;

            if (amountOfNodes == 0)
            {
                return false;
            }
            else
            {
                var amountOfEdges = 0;
                foreach (var nodeEdges in GraphAdjacencyList.Values)
                {
                    amountOfEdges += nodeEdges.Count;
                }
                if (amountOfEdges == amountOfNodes - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasStartingNode()
        {
            return GraphAdjacencyList.Keys.Where(x => x.IsStartNode == true).Any();
        }
        public bool HasEndNode()
        {
            return GraphAdjacencyList.Keys.Where(x => x.IsEndNode == true).Any();
        }
        public int AmountOfEdges()
        {
            var totalEdges = 0;
            foreach (var item in GraphAdjacencyList.Values)
            {
                totalEdges += item.Count;
            }
            if (!IsDirectedGraph)
            {
                return totalEdges / 2;
            }
            else
            {
                return totalEdges;
            }
        }

        public bool TryRemoveVertex(TVertex vertexNode)
        {
            var vertexRemoved = false;
            if (HasVertex(vertexNode))
            {
                vertexRemoved = GraphAdjacencyList.Remove(vertexNode);
                if (vertexRemoved)
                {
                    foreach (TVertex vertex in GraphAdjacencyList.Keys)
                    {
                        LinkedList<TEdge> edges = GetEdges(vertex);
                        foreach (TEdge edge in edges)
                        {
                            if (edge.GetAdjacentVertex().GetNodeIdentifier() == vertexNode.GetNodeIdentifier())
                            {
                                TryRemoveEdge(vertex, edge);
                            }
                        }
                    }
                }
            }

            return vertexRemoved;
        }


    }
}
