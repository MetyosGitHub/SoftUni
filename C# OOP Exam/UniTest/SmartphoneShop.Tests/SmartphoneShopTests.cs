using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_Smartphone_Creator()
        {
            var smartphone = new Smartphone("HTC", 100);
            Assert.AreEqual("HTC", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);

        }
        [Test]
        public void Test_Shop_Creator()
        {
            var shop = new Shop(10);
            Assert.AreEqual(10, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_Shop_Throws_Exception_For_Capacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var shop = new Shop(-10);
                
            });
            
        }
        [Test]
        public void Test_Add_Method_Works()
        {
            var smartphone = new Smartphone("HTC", 100);
            var shop = new Shop(10);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Test_Add_Method_Over_Capacity_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(1);
                shop.Add(smartphone);
                shop.Add(smartphone);
            });
            
        }
        [Test]
        public void Test_Add_Method_If_Model_Exists_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(10);
                shop.Add(smartphone);
                shop.Add(smartphone);
            });

        }
        [Test]
        public void Test_Remove_Method_Works()
        {
            var smartphone = new Smartphone("HTC", 100);
            var shop = new Shop(10);
            shop.Add(smartphone);
            shop.Remove("HTC");
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_Remove_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(10);
                shop.Add(smartphone);
                shop.Remove("HT");
                Assert.AreEqual(1, shop.Count);
            });
            
        }
        [Test]
        public void Test_TestPhone_Method_Works()
        {
            var smartphone = new Smartphone("HTC", 100);
            var shop = new Shop(10);
            shop.Add(smartphone);
            shop.TestPhone("HTC", 10);
            Assert.AreEqual(90, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Test_TestPhone_Method_Throws_Exception_For_No_Model()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(10);
                shop.Add(smartphone);
                shop.TestPhone("HT", 10);
            });
            
            
        }
        [Test]
        public void Test_TestPhone_Method_Throws_Exception_For_No_Battery()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(10);
                shop.Add(smartphone);
                shop.TestPhone("HTC", 110);
            });


        }
        [Test]
        public void Test_ChargePhone_Method_Works()
        {
            var smartphone = new Smartphone("HTC", 100);
            var shop = new Shop(10);
            shop.Add(smartphone);
            shop.TestPhone("HTC", 10);
            shop.ChargePhone("HTC");
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Test_ChargePhone_Method_Throws_Exception_For_No_Model()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var smartphone = new Smartphone("HTC", 100);
                var shop = new Shop(10);
                shop.Add(smartphone);
                shop.TestPhone("HTC", 10);
                shop.ChargePhone("HT");
            });


        }
    }
}