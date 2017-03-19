using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class CFG
    {
        public List<NonTerminal> NonTerminals { get; set; }

        public List<string> Stack = new List<string>();
        public CFG()
        {
            NonTerminals = new List<Compiler.NonTerminal>();
        }
        
        public bool CheckIfValidString(string Input)
        {
            bool Validity = true;
            List<string> NTerminal = NonTerminals.First().Production;
            int InputPointer = 0;
            int NTerminalStringPointer = 0;
            int NTerminalPointer = 0;
            int Index = 0;
           
            while(InputPointer < Input.Length)
            {
               
                if (NTerminalStringPointer < NTerminal[NTerminalPointer].Length)
                {
                    if (NTerminal[NTerminalPointer][NTerminalStringPointer] != Input[InputPointer])
                    {
                        if (NonTerminals.Exists(n => n.Name == NTerminal[NTerminalPointer][NTerminalStringPointer]))
                        {
                            string Splitted = NTerminal[NTerminalPointer].Remove(0, NTerminalStringPointer + 1);
                            try
                            {
                                Stack.Add(Splitted);
                                Index++;
                            }
                            catch (Exception E)
                            {

                            }
                            NTerminal = NonTerminals.Find(n => n.Name == NTerminal[NTerminalPointer][NTerminalStringPointer]).Production;
                            NTerminalStringPointer = 0;
                        }
                        else if (NTerminalPointer < NTerminal.Count - 1)
                        {
                            NTerminalPointer++;
                        }
                        else if (NTerminal.Exists(x => x == "") && Index > 0)
                        {
                            Index--;
                            NTerminal = new List<string>();
                            NTerminal.Add(Stack[Index]);
                            NTerminalStringPointer = 0;
                            NTerminalPointer = 0;
                            Stack.RemoveAt(Index);
                        }
                        else
                        {
                            Validity = false;
                            return Validity;
                        }
                    }
                    else if (NonTerminals.Exists(n => n.Name == Input[InputPointer]))
                    {
                        Validity = false;
                        return Validity;
                    }
                    else
                    {
                        NTerminalStringPointer++;
                        InputPointer++;
                    }
                }
                else
                {
                    if (Index > 0)
                    {
                        Index--;
                        NTerminal = new List<string>();
                        NTerminal.Add(Stack[Index]);
                        NTerminalStringPointer = 0;
                        NTerminalPointer = 0;
                        Stack.RemoveAt(Index);
                    }
                    else
                    {
                        return Validity;
                    }
                    //some condtions
                    //int StackPointer = 0;

                    //int Index = Stack.FindIndex(n => n[0] == Input[InputPointer]);

                    //try
                    //{
                    //    NTerminal = new List<string>();
                    //    NTerminal.Add(Stack[Index]);
                    //    while (Stack[Index].Length > StackPointer)
                    //    {
                    //        if (Stack[Index][StackPointer] != Input[InputPointer])
                    //        {
                    //            if (NonTerminals.Exists(n => n.Name != NTerminal[NTerminalPointer][NTerminalStringPointer]))
                    //            {
                    //                return false;
                    //            }
                    //        }
                    //        StackPointer++;
                    //        InputPointer++;
                    //    }
                    //    Stack.RemoveAt(Index);
                    //}
                    //catch
                    //{
                    //    NTerminalPointer++;
                    //}
                }
                if(InputPointer==Input.Length && NTerminalStringPointer<NTerminal[NTerminalPointer].Length)
                {
                    Validity = false;
                    return Validity;
                }
              
            }
            return Validity;
        }
        public void AddNonTerminal(NonTerminal NTerminal)
        {
            NonTerminals.Add(NTerminal);
        }
    }
}
