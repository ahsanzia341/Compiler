using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            CFG Cfg = new CFG();
            NonTerminal n1 = new NonTerminal('S',"AbS");
            NonTerminal n2 = new NonTerminal('A', "abS");
            Cfg.AddNonTerminal(n1);
            Cfg.AddNonTerminal(n2);
            Console.WriteLine(Cfg.CheckIfValidString("Aababab"));

        }
    }
}
