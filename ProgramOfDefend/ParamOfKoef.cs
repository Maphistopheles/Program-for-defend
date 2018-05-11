using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramOfDefend
{
    class ParamOfKoef
    {
        public double A { get; set; }
        public double M { get; set; }
        public double FirstKoef { get; set; }

        public ParamOfKoef(double A, double M)
        {
            this.A = A;
            this.M = M;
            FirstKoef = M / (A + M);
        }
    }
}
