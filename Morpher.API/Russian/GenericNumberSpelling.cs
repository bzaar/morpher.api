namespace Morpher.Russian
{
    class GenericNumberSpelling : Language, INumberSpelling <IParadigm>
    {
        readonly INumberSpelling inner;

        public GenericNumberSpelling(INumberSpelling inner)
        {
            this.inner = inner;
        }

        string INumberSpelling<IParadigm>.Spell (decimal n, ref string unit, ICase <IParadigm> @case)
        {
            return inner.Spell (n, ref unit, @case);
        }
    }
}
