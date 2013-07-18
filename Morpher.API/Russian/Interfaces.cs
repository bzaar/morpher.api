namespace Morpher.Russian
{
    public interface IParadigm : ISlavicParadigm
    {
        string Locative {get;}
    }

    /// <summary>
    /// Represents a set of inflectional forms of a Russian word or phrase, both singular and plural.
    /// </summary>
    public interface IFullParadigm : IParadigm
    {
        /// <summary>
        /// Returns the plural forms or null for 'pluralia tantum' words e.g. ворота, ножницы.
        /// </summary>
        IParadigm Plural {get;}

        /// <summary>
        /// Gets the gender of the head word of the noun phrase.
        /// </summary>
        IGender Gender {get;}

        /// <summary>
        /// True if the word or noun phrase is considered animate, false otherwise.
        /// </summary>
        bool IsAnimate {get;}
    }

    /// <summary>
    /// Provides declension of Russian words and phrases by case and number.
    /// </summary>
    public interface IDeclension
    {
        /// <summary>
        /// Analyses a Russian word or phrase e.g. "Генеральный директор".
        /// </summary>
        /// <returns>
        /// null if <param name="s"/> is not recognized as a Russian word or phrase.
        /// </returns>
        IFullParadigm Analyse (string s);
    }

    /// <summary>
    /// Provides spelling of Russian
    /// </summary>
    public interface INumberSpelling
    {
        /// <summary>
        /// Spells a number as a Russian numeral in the given grammatical <paramref name="case"/>.
        /// </summary>
        /// <param name="n">The nuber to spell.</param>
        /// <param name="unit">
        /// A Russian word or phrase that represents the unit of measure to be added after the numeral.
        /// Upon return, it normally changes its form to agree with the numeral (thus the ref).
        /// </param>
        /// <param name="case">
        /// The case to apply to the numeral and the unit to produce e.g. двум котам, двух котов, etc.
        /// </param>
        /// <returns>The number spelled in words e.g. 'сто' for 100.</returns>
        string Spell (decimal n, ref string unit, ICase <IParadigm> @case);
    }
}
