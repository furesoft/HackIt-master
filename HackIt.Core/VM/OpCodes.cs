namespace HackIt.Core.VM
{
    public enum OpCodes
    {
        Add,
        Sub,
        Div,
        Mul,
        Call,
        End,
        Label,
        Stop,
        LdI,
        LdF,
        LdStr,
        Jmp,
        LRI,
        LRF,
        LRStr,
        Ret
    }
}