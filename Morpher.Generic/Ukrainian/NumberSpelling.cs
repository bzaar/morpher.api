using Morpher.Ukrainian;

namespace Morpher.Generic.Ukrainian
{
    class NumberSpelling : Language, INumberSpelling <IParadigm>
    {
        readonly INumberSpelling inner;

        public NumberSpelling(INumberSpelling inner)
        {
            this.inner = inner;
        }

        string INumberSpelling<IParadigm>.Spell (decimal n, ref string unit, ICase <IParadigm> @case)
        {
            return inner.Spell (n, ref unit, @case);
        }
    }
}
