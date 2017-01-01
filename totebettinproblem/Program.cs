using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using Ninject;

namespace ToteBettinProblem
{
    class Program
    {
        static void Main(string[] args)
        {            
            Ninject.IKernel _iKernel = new StandardKernel(new TestModule());

            Console.WriteLine("Print all bets and result.");
            string _input = null;
            
            GameRunner _gameRunner = _iKernel.Get<GameRunner>();
          
            StringBuilder _sb = new StringBuilder();

            while(!String.IsNullOrEmpty(_input = Console.ReadLine()))
            {
                _sb.Append(_input).Append("|");
            }

            List<string> _inputList = _sb.ToString().Split(new string[]{"|"},StringSplitOptions.None).ToList();

           _gameRunner.BetList=  GetBets(_inputList.Where(_s => _s.StartsWith("Bet")));
           _gameRunner.Reslt = GetResult(_inputList.Where(_r => _r.StartsWith("Result")));

           ICollection<Dividend> _divs= _gameRunner.RunAllGames();

           _divs.ToList().ForEach(_a => Console.WriteLine(String.Format("{0}:{1}:{2}", _a.Prod.Name, _a.Selection, Math.Round(_a.Yield,2))));
            Console.ReadKey();
        }
        

        private static Collection<Bet> GetBets(IEnumerable<string> Input)
        {
            Collection<Bet> _bets=new Collection<Bet>();

            string _betStr = "Bet:";
            int _excludeIndex = _betStr.Length;

            foreach (string _s in Input)
            {
                Bet _b = new Bet(_s.Substring(_excludeIndex, _s.Length - _betStr.Length), ':');
                _bets.Add(_b);
            }

            return _bets;
        }

        //make one
        private static Result GetResult(IEnumerable<string> Input)
        {
            string _resultStr = "Result:";
            int _excludeIndex = _resultStr.Length;
            string _s = Input.FirstOrDefault();

            Result _result = new Result(_s.Substring(_excludeIndex,_s.Length-_resultStr.Length) ,':');
            return _result;
        }
    }
}
