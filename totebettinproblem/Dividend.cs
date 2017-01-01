using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToteBettinProblem
{   
    public class Dividend
    {
        //format: <product>:<Selection>:<yield>
        public Product Prod { get; set; }
        public int Selection { get; set; }
        public double Yield { get; set; }

        public Dividend(Product Product,int Selectn, double Yld)
        {
            Prod = Product;
            Selection = Selectn;
            Yield = Yld;
        }
    }
}
