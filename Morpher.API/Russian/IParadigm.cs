namespace Morpher.Russian
{
    /// <summary xml:lang="en">
    /// Represents the Russian case paradigm, a set of word forms that differ by case.  Each form is represented by its own string property.
    /// </summary>
    /// <summary xml:lang="ru">
    /// Представляет русскую падежную парадигму (набор падежных форм), где каждая форма представлена строковым свойством.
    /// </summary>
    public interface IParadigm : ISlavicParadigm
    {
        string Locative {get;}
    }
}