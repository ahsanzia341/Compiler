using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class CFG
    {
        public List<NonTerminal> NonTerminal { get; set; }

        public CFG()
        {
            NonTerminal = new List<Compiler.NonTerminal>();
        }
        public bool CheckIfValidString(string Input)
        {
            bool Validity = true;
            string NTerminal = NonTerminal.First().HasString;
            int InputPointer = 0;
            int NTerminalPointer = 0;
            while(InputPointer < Input.Length)
            {
                if (NTerminal[NTerminalPointer] != Input[InputPointer])
                {
                    if (NonTerminal.Exists(n => n.Name == NTerminal[NTerminalPointer]))
                    {
                        NTerminal = NonTerminal.Find(n => n.Name == NTerminal[NTerminalPointer]).HasString;
                        NTerminalPointer = 0;
                    }
                    else
                    {
                        Validity = false;
                        return Validity;
                    }
                }
                else if(NonTerminal.Exists(n=>n.Name == Input[InputPointer]))
                {
                    Validity = false;
                    return Validity;
                }
                else
                {
                    NTerminalPointer++;
                    InputPointer++;
                }
            }
            return Validity;
        }
        public void AddNonTerminal(NonTerminal NTerminal)
        {
            NonTerminal.Add(NTerminal);
        }
    }
}
