namespace Morpher.Generic
{
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