namespace Morpher.Russian
{
    /// <summary xml:lang="en">
    /// Represents a set of inflectional forms of a Russian word or phrase, both singular and plural.  Normally instantiated by calling <see cref="IDeclension.Parse"/>.
    /// </summary>
    /// <summary xml:lang="ru">
    /// Результат работы метода <see cref="IDeclension.Parse"/> - набор падежно-числовых форм слова или словосочетания.
    /// </summary>
    public interface IParse : IParadigm
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
        /// True if the word or noun phrase is animate, false otherwise.
        /// </summary>
        bool IsAnimate {get;}

        /// <summary xml:lang="en">
        /// Paucal form, normally appears after the numerals 2, 3 and 4.
        /// </summary>
        /// <summary xml:lang="en">
        /// Паукальная форма, встречающаяся после числительных оба, два, три и четыре.
        /// </summary>
        string Paucal {get;}
    }
}