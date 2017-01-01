using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToteBettinProblem;

namespace ToteBettingProblem.Tests
{
    /// <summary>
    /// Summary description for Bet
    /// </summary>
    [TestClass]
    public class BetTest
    {            
       [TestMethod]
        public void BetConstructor1_CreateBetWith_InputStrAndSeparator()
        {
            string _inputStr = "W:2:2.3";

            Bet _actualBet = new Bet(_inputStr, ':');

            int _selection = 2;
            double _stake = 2.3;
            string _product = "W";

            Assert.IsInstanceOfType(_actualBet, typeof(Bet));
            Assert.IsNotNull(_actualBet);
            Assert.AreEqual(_actualBet.Winner, _selection);
            Assert.IsInstanceOfType(_actualBet.Product, typeof(Product));
            Assert.AreEqual(_actualBet.Product.Name, _product);
            Assert.AreEqual(_actualBet.Stake, _stake);
        }
    }}
