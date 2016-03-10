using MSStories.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MSStories.Tests
{
    public class TestHomeController
    {
       [Fact] 
        public void Show()
        {
            int z = 3;
            Assert.Equal(3, z);
        }

        [Theory]
        [InlineData(1,2,3)]
        public void Plus(int x,int y, int result)
        {
            //var home = new HomeController();
            var res = 1 + 2;
            Assert.Equal(result, res);
        }
    }
}
