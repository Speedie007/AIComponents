using NUnit.Framework;
using AIComponents.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Common.Errors.Tests
{
    [TestFixture()]
    public class GeneralErrorTests
    {
        [Test()]
        public void GeneralErrorTest()
        {
            Assert.Fail();
        }
    }
}