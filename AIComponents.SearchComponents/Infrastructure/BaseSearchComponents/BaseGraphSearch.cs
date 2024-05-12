using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph;
using AIComponents.SearchComponents.SearchGraph.Result;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract class BaseGraphSearch<TGraph, TVertex, TEdge, TResultSet> :
        IGraphSearch<TGraph, TVertex, TEdge, TResultSet>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge< TVertex>, new()
        where TGraph : BaseGraph< TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {

        #region Cstor
        public BaseGraphSearch(TGraph graph, TVertex startVertexNode = null, TVertex endVertexNode = null)
        {
            Graph = graph;
            SetStartingNode(startVertexNode);
            SetEndNode(endVertexNode);
            //AddNodeEventHandlers();

            SearchResult = new GraphSearchResult< TVertex, TResultSet>();

            OnForwardGrapNodeFound += ForwardGrapNodeFoundEventHandler;
            OnReverseGrapNodeFound += ReverseGrapNodeFoundEventHandler;
        }
        #endregion

        #region Events
        public abstract event EventHandler<TVertex> OnForwardGrapNodeFound;
        public abstract event EventHandler<TVertex> OnReverseGrapNodeFound;
        protected abstract void ForwardGrapNodeFoundEventHandler(object sender, TVertex e);
        protected abstract void ReverseGrapNodeFoundEventHandler(object sender, TVertex e);
        #endregion

        #region Properties
        //public delegate void NodeVisitedEventHandler(NodeVisitedEventArgs<TNodeContext> args); //where T : NodeBaseContextEntity;
        public TGraph Graph { get; private set; }
        // public EnumSearchType SearchType { get; private set; }
        public TVertex StartVertexNode { get; private set; }
        public TVertex EndVertexNode { get; private set; }
        public GraphSearchResult< TVertex, TResultSet> SearchResult { get; private set; }
        #endregion

        #region Methods
        public abstract void ExcuteSearch();
        public virtual void ResetSearch()
        {
            // Frontier.Clear();
            foreach (var nodeItem in Graph.GraphAdjacencyList)
            {
                nodeItem.Key.ResetLevel();
                nodeItem.Key.ResetVisited();
            }
        }
        public virtual void SetEndNode(TVertex endVertexNode)
        {
            if (endVertexNode != null)
            {
                foreach (var vertexNode in Graph.GraphAdjacencyList.Keys)
                {
                    if (vertexNode.NodeDataContext.Id == endVertexNode.NodeDataContext.Id)
                        vertexNode.SetAsEndNode();
                    else
                        vertexNode.RemoveAsEndNode();
                }
                EndVertexNode = endVertexNode;
            }
            else
            {
                foreach (var vertexNode in Graph.GraphAdjacencyList.Keys)
                    vertexNode.RemoveAsEndNode();

                EndVertexNode = endVertexNode;
            }

        }
        public virtual void SetStartingNode(TVertex startingVertexNode)
        {
            if (startingVertexNode != null)
            {
                foreach (var vertexNode in Graph.GraphAdjacencyList.Keys)
                {
                    if (vertexNode.NodeDataContext.Id == startingVertexNode.NodeDataContext.Id)
                        vertexNode.SetAsStartingNode();
                    else
                        vertexNode.RemoveAsStartingNode();
                }
                StartVertexNode = startingVertexNode;
            }
            else
            {
                foreach (var vertexNode in Graph.GraphAdjacencyList.Keys)
                    vertexNode.RemoveAsStartingNode();
                StartVertexNode = null;
            }

        }
        #endregion

        #region Event Processors
        //public abstract void VertexNodeVisited(NodeVisitedEventArgs<TNodeContext> args);
        ////public abstract void ProcessFirstVisitedVertexNode(FirstNodeVisitedEventArgs<TNodeContext> args);
        ////public abstract void ProcessLastVisitedVertexNode(LastNodeVisitedEventArgs<TNodeContext> args);
        //public abstract void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<TNodeContext> args);


        #endregion
    }
}
