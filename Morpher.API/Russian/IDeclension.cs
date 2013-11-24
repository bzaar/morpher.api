namespace Morpher.Russian
{
    /// <summary>
    /// Provides declension of Russian words and phrases by case and number.
    /// </summary>
    public interface IDeclension
    {
        /// <summary>
        /// Parses a Russian word or phrase e.g. "Генеральный директор".
        /// </summary>
        /// <returns>
        /// null if <paramref name="s"/> is not recognized as a Russian word or phrase.
        /// </returns>
        IParse Parse (string s, ParseArgs args = null);
    }
}