using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ToteBettinProblem;

namespace ToteBettingProblem.Tests
{
    [TestClass]
    public class TotePlaceBetGameTest
    {
        [TestMethod]
        public void ToteBettingGame_ShouldReturn_An_object_WithCommission()
        {
            ToteBettingGame _game = new ToteBettingGame(10.0);
            Assert.IsNotNull(_game);
            Assert.IsInstanceOfType(_game, typeof(ToteBettingGame));
        }

        [TestMethod]
        public void GetCommission_ReturnsFunctionType_GetValue()
        {
            ToteBettingGame _game = new ToteBettingGame(10.0);
            Assert.IsInstanceOfType(_game.GetCommissionRule(), typeof(Func<double, double>));

            Func<double, double> _testFunc = _game.GetCommissionRule();

            if (_testFunc != null)
            {
                double _netValue = _testFunc(1000.0);
                Assert.AreEqual((100.00 - 10)*1000 / 100, _netValue);
            }
        }
        
        [TestMethod]
        public void GetRule_ReturnsFunction_GetDivs()
        {
            TotePlaceBettingGame _game = new TotePlaceBettingGame(13.0);
            Func<Collection<Bet>, Result, Collection<Dividend>> _testFunc = _game.GetRule();
            Assert.IsNotNull(_testFunc);

            Collection<Bet> _bets = new Collection<Bet>();
            _bets.Add(new Bet("P:2:3.2", ':'));
            _bets.Add(new Bet("P:1:2", ':'));
            _bets.Add(new Bet("P:2:2.9", ':'));
            _bets.Add(new Bet("P:1:4.0", ':'));
            _bets.Add(new Bet("P:2:1.7", ':'));
            _bets.Add(new Bet("P:3:6.5", ':'));

            Result _r = new Result("2:1:3", ':');

            Collection<Dividend> _divs = _testFunc(_bets, _r);
            Assert.IsNotNull(_divs);
            Assert.IsInstanceOfType(_divs, typeof(Collection<Dividend>));

            Assert.AreEqual(_divs.Count, 3);
            
            //pool total
            double _grossSum = 3.2+2+2.9+4+1.7+6.5;

            //Net value
            double _netSum= (100 - 13.0)*_grossSum/100;

            //first place calculation
            double _firstPlaceSum = 1.7+2.9+3.2;
            double _firstPlaceDividend = _netSum / _firstPlaceSum;

            //first place calculation            
            double _secondPlaceSum = 2 + 4.0;
            double _secondPlaceDividend = _netSum / _secondPlaceSum;

            //first place calculation
            double _thirdPlaceDividend = _netSum / 6.5;

            Assert.AreEqual(_divs.Where(_d => _d.Selection == 2).FirstOrDefault().Yield, _firstPlaceDividend);
            Assert.AreEqual(_divs.Where(_d => _d.Selection == 1).FirstOrDefault().Yield, _secondPlaceDividend);
            Assert.AreEqual(_divs.Where(_d => _d.Selection == 3).FirstOrDefault().Yield, _thirdPlaceDividend);          

        }
    }
}
