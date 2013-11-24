namespace Morpher.Russian
{
    /// <summary>
    /// Provides spelling of Russian numbers.
    /// </summary>
    public interface INumberSpelling
    {
        /// <summary>
        /// Spells a number as a Russian numeral in the given grammatical <paramref name="case"/>.
        /// </summary>
        /// <param name="n">The number to spell.</param>
        /// <param name="unit">
        /// A Russian word or phrase that represents the unit of measure to be added after the numeral.
        /// Upon return, it normally changes its form to agree with the numeral (thus the ref).
        /// </param>
        /// <param name="case">
        /// The case to apply to the numeral and the unit to produce e.g. двум котам, двух котов, etc.
        /// </param>
        /// <returns>The number spelled in words e.g. 'сто' for 100 or null if <paramref name="unit"/> is not in Russian.</returns>
        string Spell (decimal n, ref string unit, ICase <IParadigm> @case);
    }
}