using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events.Node;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Enumeration;
using AIComponents.SearchComponents.Infrastructure.Interfaces;

/** Info Reference
https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/ 
 */


namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract partial class BaseBreadthFirstSearchVV3<TGraphContext, TGraph, TVertex, TEdge> : IBreadthFirstSearch<TGraphContext>, IDisposable
        where TGraphContext : GraphBaseContextEntity
        where TVertex : BaseNode<TGraphContext>
        where TEdge : BaseEdge<TGraphContext>
        where TGraph : IGraph<TGraphContext, TVertex, TEdge>
    {
        public EnumSearchType SearchType { get; private set; } = EnumSearchType.BreadthFirstSearch;
        public Queue<INode<TGraphContext>> FrontierQueue { get; private set; }
        public INode<TGraphContext> StartVertexNode { get; private set; }
        public TGraph Graph { get; private set; }


        #region cstor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchGraph"></param>
        /// <param name="startVertexNode"></param>
        public BaseBreadthFirstSearch(TGraph searchGraph, INode<TGraphContext> startVertexNode)
        {
            Graph = searchGraph;
            ResetStartingNode(startVertexNode);
            FrontierQueue = new Queue<INode<TGraphContext>>();
            AddNodeEventHandlers();
        }

        public virtual void ExcuteSearch()
        {
            //Ensure That the Graph and Search Queue is correctly initialized by Restting to defaults before starting the BFS.
            ResetSearch();

            // Mark the current node(Starting Node) as visited and enqueue it
            var vertexNode = Graph.GetVertex(StartVertexNode.GetNodeIdentifier());
            vertexNode.MarkNodeAsVisited();
            FrontierQueue.Enqueue(vertexNode);

            while (FrontierQueue.Count > 0)
            {
                // Dequeue a vertex from queue and Process it
                var currentNode = FrontierQueue.Dequeue();

                // Get all adjacent vertices of the dequeued
                // vertex currentNode If an adjacent has not
                // been visited, then mark it visited and
                // enqueue it
                foreach (var edge in Graph.GetEdges((BaseNode<TGraphContext>)currentNode))
                {
                    var adjacentVertexNode = Graph.GetVertex(edge.GetAdjacentVertex().GetNodeIdentifier());
                    if (!adjacentVertexNode.IsVisited)
                    {
                        adjacentVertexNode.MarkNodeAsVisited();
                        FrontierQueue.Enqueue(adjacentVertexNode);
                    }
                }
            }
        }

        public virtual void ResetSearch()
        {
            FrontierQueue?.Clear();
            foreach (var nodeItem in Graph.GraphAdjacencyList)
            {
                nodeItem.Key.ResetLevel();
                nodeItem.Key.ResetVisited();

            }
        }

        public virtual void ResetStartingNode(INode<TGraphContext> startingVertexNode)
        {
            StartVertexNode = startingVertexNode;
            ResetSearch();
        }

        public abstract void ProcessVisitedVertexNode(NodeVisitedEventArgs<TGraphContext> args);
        public abstract void ProcessFirstVisitedVertexNode(FirstNodeVisitedEventArgs<TGraphContext> args);
        public abstract void ProcessLastVisitedVertexNode(LastNodeVisitedEventArgs<TGraphContext> args);
        public abstract void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<TGraphContext> args);

        private void AddNodeEventHandlers()
        {
            foreach (var node in Graph.GraphAdjacencyList)
            {
                node.Key.OnNodeVisited += ProcessVisitedVertexNode;
                node.Key.OnFirstNodeVisited += ProcessFirstVisitedVertexNode;
                node.Key.OnLastNodeVisited += ProcessLastVisitedVertexNode;
                node.Key.OnNodeLevelChanged += ProcessVertexNodeLevelChanged;
            }
        }
        private void RemoveNodeEventHandlers()
        {
            foreach (var node in FrontierQueue)
            {
                node.OnNodeVisited -= ProcessVisitedVertexNode;
                node.OnFirstNodeVisited -= ProcessFirstVisitedVertexNode;
                node.OnLastNodeVisited -= ProcessLastVisitedVertexNode;
                node.OnNodeLevelChanged -= ProcessVertexNodeLevelChanged;
            }
        }
        public void Dispose()
        {
            RemoveNodeEventHandlers();
        }

        #endregion
    }
}
