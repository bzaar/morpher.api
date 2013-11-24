namespace Morpher.Generic
{
    public static class SpellingExtensions
    {
        public static ISpeller AddCase <TParadigm> (this INumberSpelling <TParadigm> speller, ICase <TParadigm> @case)
        {
            return new Speller <TParadigm> (speller, @case);
        }

        public static ISpeller DefaultCase <TParadigm> (this INumberSpelling <TParadigm> speller)
        {
            return new Speller <TParadigm> (speller, speller.Nominative);
        }
    }
}