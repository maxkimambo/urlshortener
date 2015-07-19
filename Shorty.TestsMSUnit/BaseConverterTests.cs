using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shorty.Core;

namespace Shorty.TestsMSUnit
{
    [TestClass]
    public class BaseConverterTests
    {
       
        [TestMethod]
        public void ShouldConvertDecimalToBasex()
        {
            var converter = new BaseConverter();
            var result2 = converter.Encode(1979);

            Assert.AreEqual("Wx", result2); 


        }
        [TestMethod]
        public void ShouldConvertBasexBackToDecimal()
        {
            var converter = new BaseConverter();
            var result = converter.Decode("Wx"); 

            Assert.IsTrue(result == 1979);
        }

       
    }
    
}
