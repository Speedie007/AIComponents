using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.ProtoType
{
    public  partial interface IPrototype<T>
    {
        T CreateDeepCopy();
    }
}
