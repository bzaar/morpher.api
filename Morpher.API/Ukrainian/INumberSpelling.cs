namespace Morpher.Ukrainian
{
    public interface INumberSpelling
    {
        string Spell (decimal n, ref string unit, ICase <IParadigm> @case);
    }
}