using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToteBettinProblem;

namespace ToteBettingProblem.Tests
{
    [TestClass]
    public class DividendTest
    {
        [TestMethod]
        public void Dividend_Constructor_Shouldreturn_AnObjectWith_EnteredValues()
        {
            Product _prod=new Product();
            _prod.Name="W";
            double _yield = 2.0;
            int _selection = 2; 
            Dividend _div = new Dividend(_prod, _selection, _yield);

            Assert.IsNotNull(_div);
            Assert.IsInstanceOfType(_div, typeof(Dividend));
            Assert.AreEqual(_div.Yield, _yield);
            Assert.AreEqual(_div.Selection, _selection);
            Assert.AreEqual(_div.Prod.Name,_prod.Name);
        }
    }
}
