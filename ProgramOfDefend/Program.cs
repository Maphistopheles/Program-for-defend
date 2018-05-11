using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramOfDefend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the file: ");
            string s = Console.ReadLine();
            Network Web = new Network(s);
            Console.WriteLine("Doy you want to change the protections of the nodes?");
            string ans = Console.ReadLine();
            if(ans == "yes")
            {
                Console.WriteLine("Enter the number of node, number of koef and numbers of A and M");
                string param = Console.ReadLine();
                string[] array = param.Split(',');
                int NumOfNode = int.Parse(array[0]);
                int numOfCoef = int.Parse(array[1]);
                double A = double.Parse(array[2]);
                double M = double.Parse(array[3]);
                Web.AddElementInNode(NumOfNode, numOfCoef, A, M);

            }
        }
    }
}
