using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;

namespace ToteBettinProblem
{
   public class Bet
    {
       //Bet format: Prod: Winner: stake
       public Product Product {get;set;}
       public int Winner { get; set; }
       public double Stake { get; set; }

       public Bet(string Input, char Separator)
       {
           if (!String.IsNullOrEmpty(Input))
           {
               if (Separator != '\n')
               {
                   var _output = Input.Split(new char[] { Separator }, StringSplitOptions.None);

                   try
                   {
                      if(_output.Length >= 3)
                       {
                          Product = new Product() {  Name = _output.ElementAt(0)};
                          Winner = int.Parse(_output.ElementAt(1));

                          try
                          {
                              Stake = Convert.ToDouble(_output.ElementAt(2));
                          }
                          catch { throw; }
                       }
                   }
                   catch
                   {
                       throw;
                   }
               }
           }
       }
    }
}
