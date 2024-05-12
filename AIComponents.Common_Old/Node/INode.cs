using AIComponents.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Node
{
    public partial  interface INode<TNodeContext>
        where TNodeContext : NodeBaseContextEntity
    {
        TNodeContext NodeItem { get; }
    }
}
