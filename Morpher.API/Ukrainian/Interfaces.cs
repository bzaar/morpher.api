namespace Morpher.Ukrainian
{
    public interface IParadigm : ISlavicParadigm
    {
        string Vocative {get;}
    }

    public enum Gender
    {
        Masculine, Feminine, Neuter, Plural
    }

    public interface IFullParadigm : IParadigm
    {
        Gender Gender {get;}
    }

    public interface IDeclension
    {
        IFullParadigm Analyse (string s);
    }

    public interface INumberSpelling
    {
        string Spell (decimal n, ref string unit, ICase <IParadigm> @case);
    }
}
