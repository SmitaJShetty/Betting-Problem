using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using ToteBettinProblem;

namespace ToteBettingProblem.Tests
{
    [TestClass]
    public class ToteBettingProblemTest
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
             Assert.IsInstanceOfType(_game.GetCommissionRule(),typeof(Func<double,double>));

             Func<double,double> _testFunc= _game.GetCommissionRule();

             if (_testFunc != null)
             {
                  double _netValue= _testFunc(1000.0);
                 Assert.AreEqual((100.00-10.0)*1000/100,_netValue);
             }
        }

        [TestMethod]
        public void GetRule_ReturnsFunction_GetDivs()
        {
            ToteBettingGame _game = new ToteBettingGame(13.0);
            Func<Collection<Bet>,Result,Collection<Dividend>> _testFunc = _game.GetRule();
            Assert.IsNotNull(_testFunc);

            Collection<Bet> _bets = new Collection<Bet>();
            _bets.Add(new Bet("W:2:3.2",':'));
            _bets.Add(new Bet("W:1:3.1", ':'));
            
            Result _r = new Result("2:2:1",':');

           Collection<Dividend> _divs= _testFunc(_bets, _r);
           Assert.IsNotNull(_divs);
           Assert.IsInstanceOfType(_divs,typeof(Collection<Dividend>));
           Assert.AreEqual(Math.Round(_divs.FirstOrDefault().Yield,2), Math.Round((.87)* (3.2 + 3.1)/3.2,2));
        }
    }
}
