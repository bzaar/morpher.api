namespace Morpher.Generic
{
    public interface INumberSpelling <TParadigm> : ILanguage <TParadigm> 
    {
        string Spell (decimal n, ref string unit, ICase <TParadigm> @case);
    }
}