using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicConnectivity.Tests
{
    [TestClass]
    public class ConnectionMapTests
    {
        [TestMethod]
        public void ConnectionTest()
        {
            var map = new ConnectionMap();
            var component0 = new Component(0);
            var component1 = new Component(1);
            var component2 = new Component(2);
            var component3 = new Component(3);
            var component4 = new Component(4);
            var component5 = new Component(5);
            var component6 = new Component(6);
            var component7 = new Component(7);
            var component8 = new Component(8);
            var component9 = new Component(9);
            
            map.Union(component0, component1);
            map.Union(component2,component3);
            map.Union(component4,component5);
            map.Union(component6, component2);
            map.Union(component7, component8);
            map.Union(component8, component0);

            Assert.IsTrue(map.Connected(component7, component0));
            Assert.IsFalse(map.Connected(component0, component2));

            map.Union(component0, component2);

            Assert.IsTrue(map.Connected(component6, component7));
            Assert.IsFalse(map.Connected(component9, component0));
            Assert.IsFalse(map.Connected(component9, component3));
        }
    }
}
