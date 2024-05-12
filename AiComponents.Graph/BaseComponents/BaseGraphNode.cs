using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.BaseComponents
{
    public abstract partial class BaseGraphNode : IGraphNode
        //IComparable<BaseGraphNode<TNodeContext>>
        //where TNodeContext : NodeBaseContextEntity
    {
        #region Properties
        //public delegate void NodeVisitedEventHandler(NodeVisitedEventArgs<TNodeContext> args); //where T : NodeBaseContextEntity;
        public NodeBaseContextEntity NodeDataContext { get; private set; }

        private int _Level;
        public int Level
        {
            get => _Level;
            private set
            {
                if (value != _Level)
                {
                    var perviousLevel = _Level;
                    _Level = value;
                    //OnNodeLevelChanged?.Invoke(new NodeLevelEventArgs<TNodeContext>(this, perviousLevel, value));
                }
            }
        }
        private bool _IsVisited;
        public bool IsVisited
        {
            get => _IsVisited;
            private set
            {
                _IsVisited = value;
                if (IsVisited)
                {
                    //if (IsStartNode)
                    //    OnFirstNodeVisited?.Invoke(new FirstNodeVisitedEventArgs<TNodeContext>(this));

                    //if (IsEndNode)
                    //    OnLastNodeVisited?.Invoke(new LastNodeVisitedEventArgs<TNodeContext>(this, _Level));

                    //OnNodeVisited?.Invoke(new NodeVisitedEventArgs<TNodeContext>(this));
                }
            }
        }
        public bool IsStartNode { get; private set; }
        public bool IsEndNode { get; private set; }
        #endregion

        #region Event Handlers
        //public event NodeLevelEventHandler<TNodeContext>? OnNodeLevelChanged;
        //public event NodeVisitedEventHandler? OnNodeVisited;
        //public event FirstNodeVisitedEventHandler<TNodeContext>? OnFirstNodeVisited;
        //public event LastNodeVisitedEventHandler<TNodeContext>? OnLastNodeVisited;
        #endregion

        #region cstr

        public BaseGraphNode(NodeBaseContextEntity nodeContext, bool isStartNode = false, bool isEndNode = false)
        {
            NodeDataContext = nodeContext;
            Level = 0;
            IsVisited = false;
            IsEndNode = isEndNode;
            IsStartNode = isStartNode;
        }

        //event NodeVisitedEventHandler<TNodeContext> INode<TNodeContext>.OnNodeVisited
        //{
        //    add
        //    {
        //        throw new NotImplementedException();
        //    }

        //    remove
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


        #endregion

        #region Methods
        public int GetNodeIdentifier()
        {
            return NodeDataContext.Id;
        }

        public void IncrementLevel()
        {
            Level++;
        }

        public void MarkNodeAsVisited()
        {
            IsVisited = true;
        }

        public void ResetLevel()
        {
            _Level = 0;
        }

        public void ResetVisited()
        {
            _IsVisited = false;
        }

        public int CompareTo(INode? other)
        {
            // this.NodeDataContext.GetType() == 
            if (other == null)
                return 1;
            if (GetHashCode() > other.GetHashCode())
                return 1;

            if (GetHashCode() < other.GetHashCode())
                return -1;

            return 0;
        }
        public override int GetHashCode()
        {
            return NodeDataContext.Id.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            var item = obj as NodeBaseContextEntity;

            if (item == null)
                return false;
            //if (item.GetType() == typeof(IWeightedEdge<decimal>))
            //{

            //}

            return NodeDataContext.Id.Equals(item.Id);

        }

        public void SetAsStartingNode()
        {
            IsStartNode = true;
        }

        public void SetAsEndNode()
        {
            IsEndNode = true;
        }

        public void RemoveAsStartingNode()
        {
            IsStartNode = false;
        }

        public void RemoveAsEndNode()
        {
            IsEndNode = false;
        }




        #endregion

    }
}
