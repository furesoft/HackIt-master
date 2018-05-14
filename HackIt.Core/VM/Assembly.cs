using System;
using System.Collections.Generic;

namespace HackIt.Core.VM
{
    public class Assembly
    {
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        public Stack<object> Stack { get; set; } = new Stack<object>();

        public Stack<object> Register { get; set; } = new Stack<object>();

        public List<Type> UsableTypes { get; set; } = new List<Type>();
        public List<object> UsableInstances { get; set; } = new List<object>();

        public static int Run(byte[] bin)
        {
            int pointer = 0;

            while(pointer < bin.Length)
            {
                switch ((OpCodes)bin[pointer])
                {
                    case OpCodes.Add:
                        break;
                    case OpCodes.Sub:
                        break;
                    case OpCodes.Div:
                        break;
                    case OpCodes.Mul:
                        break;
                    case OpCodes.Call:
                        break;
                    case OpCodes.End:
                        return 0;
                    case OpCodes.Label:
                        break;
                    case OpCodes.Stop:
                        break;
                    case OpCodes.LdI:
                        break;
                    case OpCodes.LdF:
                        break;
                    case OpCodes.LdStr:
                        break;
                    case OpCodes.Jmp:
                        break;
                    case OpCodes.LRI:
                        break;
                    case OpCodes.LRF:
                        break;
                    case OpCodes.LRStr:
                        break;
                    case OpCodes.Ret:                         
                        break;
                    default:
                        break;
                }
            }

            return 0; // only until vm is ready
        }
    }
}