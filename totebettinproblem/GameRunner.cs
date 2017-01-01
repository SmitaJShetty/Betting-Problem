using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ToteBettinProblem
{
    public class GameRunner
    {
        public Collection<IGame> GamesSet { set; get; }
        public Collection<Bet> BetList { set; get; }
        public Result Reslt { get; set; }

        public GameRunner(Collection<IGame> GSet)
        {
            GamesSet = GSet;
        }

        public ICollection<Dividend> RunAllGames()
        {
            List<Dividend> _divs= new List<Dividend>();
           
            foreach (IGame _g in GamesSet)
            {
                _divs.AddRange(_g.CalculateDividends(BetList,Reslt,_g.GetRule()));
            }
            return _divs;
        }
    }
}
