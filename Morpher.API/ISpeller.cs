namespace Morpher
{
    public interface ISpeller
    {
        string Spell (decimal n, ref string unit);
    }

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

    public class Speller <TParadigm> : ISpeller
    {
        private readonly INumberSpelling <TParadigm> speller;
        private readonly ICase <TParadigm> @case;

        public Speller (INumberSpelling <TParadigm> speller, ICase <TParadigm> @case)
        {
            this.speller = speller;
            this.@case = @case;
        }

        string ISpeller.Spell (decimal n, ref string unit)
        {
            return this.speller.Spell (n, ref unit, @case);
        }
    }
}