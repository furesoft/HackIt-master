using System.Collections.Generic;

namespace HackIt.Core.VM
{
    public class Function
    {
        public string Name { get; set; }
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        public Stack<object> Stackframe { get; set; } = new Stack<object>();

    }
}