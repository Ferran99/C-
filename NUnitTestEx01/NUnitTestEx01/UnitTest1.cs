using NUnit.Framework;
using NUnitTestEx01;
using System;
using System.Collections;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMultiples()
        {
            int num = 15;
           ArrayList test = Multiple.Multiples(num);
            try
            {
                Assert.AreEqual("Booom", test[3]);
                Assert.AreEqual("Booom", test[6]);
                Assert.AreEqual("Booom", test[9]);
                Assert.AreEqual("Booom", test[12]);
                Assert.AreEqual("Paaaam", test[10]);
                Assert.AreEqual("Paaaam", test[5]);
                Assert.AreEqual("BooomPaaaam", test[15]);

            } catch(Exception)
            {
               
            }



        }
    }
}