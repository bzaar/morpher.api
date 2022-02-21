namespace Morpher.Generic
{
    public interface IDeclension <TParadigm> : ILanguage <TParadigm> 
    {
        IFullParadigm <TParadigm> Parse (string s);
    }
}