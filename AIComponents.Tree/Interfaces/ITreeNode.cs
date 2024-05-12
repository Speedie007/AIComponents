using AIComponents.Common.Node;
using AIComponents.Data.Domain;
using System.Xml.Linq;

namespace AIComponents.Tree.Interfaces
{
    public partial interface ITreeNode<TNodeContext> :INode<TNodeContext>
        where TNodeContext : NodeBaseContextEntity
    {
        TNodeContext FirstChild { get; }
        TNodeContext  NextSibling { get; }  
    }
}
