namespace Morpher
{
    public interface IDynamicSpeller
    {
        string Spell (decimal n, ref string unit, string @case);
    }
}