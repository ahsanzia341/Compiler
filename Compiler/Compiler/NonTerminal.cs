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

        public string HasString { get; set; }

        public NonTerminal(char c, string HasString)
        {
            Name = c;
            this.HasString = HasString;
        }
    }
}
