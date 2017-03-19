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
            
            NonTerminal n1 = new NonTerminal('S',new List<string>() {"AAbT","cdA" });
            NonTerminal n3 = new NonTerminal('T', new List<string>() { "abT", "cab" });
            NonTerminal n2 = new NonTerminal('A', new List<string>() { "rafi", "emad", "" });
            Cfg.AddNonTerminal(n1);
            Cfg.AddNonTerminal(n2);
            Cfg.AddNonTerminal(n3);
            Console.WriteLine(Cfg.CheckIfValidString(""));
        }
    }
}
