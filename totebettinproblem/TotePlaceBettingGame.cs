using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ToteBettinProblem
{
    public class TotePlaceBettingGame:IGame
    { 
        double _commission {get;set;}

        public TotePlaceBettingGame(double Commission)
        {
            _commission=Commission;
        }

        public Func<double, double> GetCommissionRule()
        {
            Func<double,double> testCommission= (total) => {
               return (100 - _commission) * total/100;
            }; 
   
            return testCommission;
        }

        public Func<IEnumerable<Bet>, int,double, Collection<Dividend>> GetSubRule()
        {
            Func<IEnumerable<Bet>, int, double, Collection<Dividend>> testfunc = (_bets, _winnerSelection, _totalSumAfterDeductions) =>
            {
               Collection<Dividend> _divs = new Collection<Dividend>();

                if ((_bets != null) && (_bets.Count() > 0))
                {
                    double _winningTotal = _bets.Sum(_w => _w.Stake);

                    if (_winningTotal > 0)
                    {
                        var _dividend = _totalSumAfterDeductions / _winningTotal;
                        Dividend _div = new Dividend(new Product() { Name = "P" }, _winnerSelection, _dividend);
                        _divs.Add(_div);
                    }
                }

                return _divs;
            };

            return testfunc;
        }

        public Func<Collection<Bet>, Result, Collection<Dividend>> GetRule()
        {
            //calculate sum after deductions
            //divide all based on winner of each result
            //calculate based on each group
            Func<Collection<Bet>, Result, Collection<Dividend>> testfunc = (_bets, _result) =>
                {
                    Collection<Dividend> _divs = new Collection<Dividend>();

                    Func<double, double> _commissionRule = GetCommissionRule();
                    double _totalSum = _bets.Sum(_b => _b.Stake);

                    double _totalSumAfterDeductions = _commissionRule(_totalSum);
                    var _subRule = GetSubRule();
                    
                    IEnumerable<Bet> _currentSet = null;
                    var _set = new Collection<Dividend>(); ;

                    foreach (int _resultValue in _result.ResultList)
                    {
                        _currentSet = _bets.Where(_s => _s.Winner == _resultValue);
                        _set = _subRule(_currentSet, _resultValue, _totalSumAfterDeductions);

                        foreach(Dividend _d in _set)
                        {
                            _divs.Add(_d); 
                        }
                        //_divs.Concat(_set);
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
