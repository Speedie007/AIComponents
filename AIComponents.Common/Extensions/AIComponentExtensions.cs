using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//FOR Cloning 
/*
 * https://www.linkedin.com/pulse/fastest-way-deepcopy-objects-c-ashutosh-pareek-g976f
 ***********************/

namespace AIComponents.Common.Extensions
{
    public static class AIComponentExtensions
    {
        //public static T CreateDeepCopy<T>(T obj)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        IFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, obj);
        //        ms.Seek(0, SeekOrigin.Begin);
        //        return (T)formatter.Deserialize(ms);
        //    }
        //}
    }
}
