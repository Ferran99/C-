using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ClassLibrary1
{
    public class Class1
    {
        [TestFixture]
      public class HiTest
        {
            [Test]
            public void sayHiTest()
            {
                Hi hi = new Hi();
              Assert.AreEqual("Hi", hi.sayHi());
               

            }
           
        }
    }
}
