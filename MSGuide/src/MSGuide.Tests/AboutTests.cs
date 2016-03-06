using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MSGuide.Tests
{
    public class AboutTests
    {
        [Theory]
        [InlineData(1,1,2)]
        public void Plus(int x,int y,int result)
        {
            var z = x + y;
            Assert.Equal(result, z);
        }
    }
}
