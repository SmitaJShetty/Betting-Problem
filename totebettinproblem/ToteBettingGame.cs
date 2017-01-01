using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ToteBettinProblem
{
    public class ToteBettingGame:IGame
    {
        double _commission {get;set;}

        public ToteBettingGame(double Commission)
        {
            _commission=Commission;
        }

        public Func<double, double> GetCommissionRule()
        {
            Func<double,double> testCommission= (_totalSum) => {
               return (100 - _commission)*_totalSum / 100;
            }; 
   
            return testCommission;
        }

        public Func<Collection<Bet>, Result, Collection<Dividend>> GetRule()
        {
             Func<Collection<Bet>, Result, Collection<Dividend>> testfunc = (_bets, _result) => {
                //Take all bets, get all W
                 //Take all sum of stakes of all bets -- A
                 //Of W bets, take all bets that have winner (first winning number) -- B
                 //Get total of all money A/B = yield

                Func<double,double> _commissionRule= GetCommissionRule();
                double _totalSum= _bets.Sum(_b => _b.Stake);
                
                double _totalSumAfterDeductions = _commissionRule(_totalSum);
                int _interestingWinner = _result.ResultList.ElementAt(0);

                IEnumerable<Bet> _winners = _bets.Where(_b => _b.Winner == _interestingWinner);
                 Collection<Dividend> _divs= new Collection<Dividend>();

                 if ((_winners!=null) && (_winners.Count()>0))
                 {
                     double _winningTotal = _winners.Sum(_w => _w.Stake);  

                     if(_winningTotal>0)
                     {
                         var _dividend = _totalSumAfterDeductions/_winningTotal;
                         Dividend _div = new Dividend(new Product(){ Name = "W"},_interestingWinner,_dividend);
                         _divs.Add(_div);
                     }
                 }

                 return _divs;
             };  

            return testfunc;
        }

        public Collection<Dividend> CalculateDividends(Collection<Bet> BetList,Result Reslt, Func<Collection<Bet>,Result,Collection<Dividend>> Rule) { 
            return Rule(BetList,Reslt);
        }
    }
}
