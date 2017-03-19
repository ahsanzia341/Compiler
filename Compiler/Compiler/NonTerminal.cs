using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class NonTerminal
    {
        public int Id { get; set; }

        public char Name { get; set; }

        public List<string> Production { get; set; }

        public NonTerminal(char c, List<string> Production)
        {
            this.Production = Production;
            Name = c;
        }
    }
}
