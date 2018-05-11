using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramOfDefend
{
    class Node
    {
        public List<ParamOfKoef> ListK1;
        public List<ParamOfKoef> ListK2;
        public List<ParamOfKoef> ListK3;
        public int NumberOfNode { get; set; }
        public int NumberOfKoefInNode { get; set; }
        public double K1 { get; set; }
        public double K2 { get; set; }
        public double K3 { get; set; }
        public double KoefOfNode { get; set; }

        public Node ( int NumberOfNode)
        {
            this.NumberOfNode = NumberOfNode;
            ListK1 = new List<ParamOfKoef>();
            ListK2 = new List<ParamOfKoef>();
            ListK3 = new List<ParamOfKoef>();
            K1 = 1;
            K2 = 1;
            K3 = 1;
            
        }
        public void CountKoef ()
        {
            foreach (ParamOfKoef el in ListK1)
            {
                K1 *= el.FirstKoef;
            }
            foreach (ParamOfKoef el in ListK2)
            {
                K2 *= el.FirstKoef;
            }
            foreach (ParamOfKoef el in ListK3)
            {
                K3 *= el.FirstKoef;
            }
            KoefOfNode = K1 * K2 * K3;
        }


    }
}
