namespace HackIt.Core.VM
{
    public class Instruction
    {
        public object Argument { get; set; }
        public OpCodes OpCode { get; set; }
        public static Instruction Load(OpCodes opcode, object argument)
        {
            var instr = new Instruction();

            instr.Argument = argument;
            instr.OpCode = opcode;

            return instr;
        }
    }
}