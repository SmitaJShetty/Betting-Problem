using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ToteBettinProblem
{   
    public interface IGame
    {
        Collection<Dividend> CalculateDividends(Collection<Bet> BetList,Result R,Func<Collection<Bet>,Result,Collection<Dividend>> Rule);
        Func<Collection<Bet>, Result, Collection<Dividend>> GetRule (); //returns a function containing collection of dividends
    }
}
