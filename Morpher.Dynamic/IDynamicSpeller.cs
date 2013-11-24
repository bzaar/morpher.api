namespace Morpher.Russian.Tests
{
    public interface IDynamicSpeller
    {
        string Spell (decimal n, ref string unit, string @case);
    }
}