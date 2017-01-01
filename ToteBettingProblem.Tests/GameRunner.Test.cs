using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToteBettinProblem;
using System.Collections;
using System.Collections.ObjectModel;

namespace ToteBettingProblem.Tests
{
    [TestClass]
    public class GameRunnerTest
    {        
        [TestMethod]
        public void Constructor_ShouldContain_CollectionOfGameInterfaces_Forproperty()
        {
            Collection<IGame> _games = new Collection<IGame>();
            _games.Add(new ToteBettingGame(15.00));

            GameRunner _runner = new GameRunner(_games);

            Assert.IsNotNull(_runner);
            Assert.IsInstanceOfType(_runner, typeof(GameRunner));

            Assert.AreEqual(_runner.GamesSet.Count, 1);
            Assert.IsInstanceOfType(_runner.GamesSet, typeof(Collection<IGame>));
            Assert.IsInstanceOfType(_runner.GamesSet[0],typeof(IGame));             
        }

        private Collection<Bet> GenerateBetList()
        {
            Collection<Bet> _bets = new Collection<Bet>();
            //Bet format: Prod: Winner: stake
            _bets.Add(new Bet("W:2:3.5", ':'));
            _bets.Add(new Bet("W:1:3.0", ':'));
            _bets.Add(new Bet("W:3:2.5", ':'));

            return _bets;
        }

        private Result GenerateResult()
        {         
            Result _r=new Result("2:3:1",':');
            return (_r);
        }

        public void GameRunner_Should_RunAllGames()
        {
            Collection<IGame> _games = new Collection<IGame>();
            _games.Add(new ToteBettingGame(15.00));

            GameRunner _runner = new GameRunner(_games);
            _runner.BetList=GenerateBetList();
            _runner.Reslt=GenerateResult();

            Collection<Dividend> _divs= _runner.RunAllGames();
            Assert.IsInstanceOfType(_divs,typeof(Collection<Dividend>));
            Assert.IsNotNull(_divs);
            Assert.AreEqual(_divs.Count, 1);
            Assert.AreEqual(_divs[0].Prod.Name,"W");
            Assert.AreEqual(_divs[0].Selection,2);
            Assert.AreEqual(_divs[0].Yield, (3.5 / 9.0));            
        }
    }

}
