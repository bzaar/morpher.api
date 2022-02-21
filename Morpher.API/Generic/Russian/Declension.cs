using Morpher.Russian;

namespace Morpher.Generic.Russian
{
    class Declension : Language, IDeclension<IParadigm>
    {
        private readonly IDeclension declension;

        public Declension (IDeclension declension)
        {
            this.declension = declension;
        }

        IFullParadigm<IParadigm> IDeclension<IParadigm>.Parse(string s)
        {
            var fullParadigm = declension.Parse (s);
            return fullParadigm == null ? null : new Paradigm (fullParadigm);
        }
    }
}