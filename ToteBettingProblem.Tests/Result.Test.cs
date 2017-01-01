using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using ToteBettinProblem;

namespace ToteBettingProblem.Tests
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public void Constructor_ShouldReturn_A_ResultObject_With_Str_And_Separator()
        {
            string _inputStr = "3:2:1";
            Result _r = new Result(_inputStr, ':');
            Assert.IsNotNull(_r);
            Assert.IsInstanceOfType(_r, typeof(Result));
                      
            Assert.AreEqual(_r.ResultList.ElementAt(0), 3);
            Assert.AreEqual(_r.ResultList.ElementAt(1), 2);
            Assert.AreEqual(_r.ResultList.ElementAt(2), 1);
        }

        public void Constructor_Should_Return_A_ResultObject_WithResultArray()
        {
            int[] _arrayInt = new int[3]{2,3,1}; 

            Result _r = new Result(_arrayInt);
            Assert.IsNotNull(_r);
            Assert.IsInstanceOfType(_r, typeof(Result));

            Assert.AreEqual(_r.ResultList.ElementAt(0), 2);
            Assert.AreEqual(_r.ResultList.ElementAt(1), 3);
            Assert.AreEqual(_r.ResultList.ElementAt(2), 1);
        
        }
    }
}
