/*
 * https://www.geeksforgeeks.org/depth-first-search-or-dfs-for-a-graph/
 */
using AiComponents.Graph.Events.Node;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Enumeration;
using AIComponents.SearchComponents.Infrastructure.Interfaces;


namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract partial class BaseDepthFirstSearch<T, TGraph> : IDepthFirstSearch<T, TGraph>
         where TGraph : IGraph<T, INode<T>, IEdge<T>>
        where T : BaseEntity
    {
        public EnumSearchType SearchType => EnumSearchType.DepthFirstSreach;
        public INode<T> StartVertexNode { get; private set; }
        public TGraph Graph { get; private set; }
        public Stack<INode<T>> FrontierStack { get; private set; }

        #region Cstor
        protected BaseDepthFirstSearch(TGraph searchGraph, INode<T> startVertexNode)
        {
            Graph = searchGraph;
            SetStartingNode(startVertexNode);
            FrontierStack = new Stack<INode<T>>();
            AddNodeEventHandlers();
        }

        public void ExcuteSearch()
        {
            throw new NotImplementedException();
        }

        public void ResetSearch()
        {
            FrontierStack.Clear();
            foreach (var nodeItem in Graph.GraphAdjacencyList)
            {
                nodeItem.Key.ResetLevel();
                nodeItem.Key.ResetVisited();

            };
        }

        public void SetStartingNode(INode<T> startingVertexNode)
        {
            StartVertexNode = startingVertexNode;
            ResetSearch();
        }

        public abstract void ProcessVisitedVertexNode(NodeVisitedEventArgs<T> args);

        public abstract void ProcessFirstVisitedVertexNode(FirstNodeVisitedEventArgs<T> args);

        public abstract void ProcessLastVisitedVertexNode(LastNodeVisitedEventArgs<T> args);

        public abstract void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<T> args);

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
            foreach (var node in FrontierStack)
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
