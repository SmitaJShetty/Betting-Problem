using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ToteBettinProblem
{
    public class IResult{
        
    }

    public class Result: IResult
    {
        public int First { get; set; }
        public int Second {get;set;}
        public int Third {get;set;}

        public IEnumerable<int> ResultList{get;set;}

        public Result(int[] Result)
        {
            ResultList = Result;
            SetWinners();
        }

        public Result(string ResultStr, char Separator)
        {
            IEnumerable<int> ResultOutput=null;

            if (!String.IsNullOrEmpty(ResultStr))
            {
                if (Separator != '\n')
                { 
                   var _output= ResultStr.Split(new char[]{Separator},StringSplitOptions.None);

                   try
                   {                      
                       ResultOutput = _output.Select(s=> int.Parse(s));
                   }
                   catch {
                       throw;
                   }
                }
            }

            if (ResultOutput != null)
            {
                ResultList = ResultOutput;
                SetWinners();
            }
        }

        private void SetWinners() {

            if (ResultList.Count() >= 3)
            {
                First = ResultList.ElementAt(0);
                Second =ResultList.ElementAt(1);
                Third = ResultList.ElementAt(2);
            }
        }
    }
}
