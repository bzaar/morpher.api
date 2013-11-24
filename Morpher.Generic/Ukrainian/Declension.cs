using Morpher.Ukrainian;

namespace Morpher.Generic.Ukrainian
{
    class Declension : Language, IDeclension<IParadigm>
    {
        private readonly IDeclension declension;

        public Declension (IDeclension declension)
        {
            this.declension = declension;
        }

        IFullParadigm<IParadigm> IDeclension<IParadigm>.Parse (string s)
        {
            var parse = declension.Parse (s);
            return parse == null ? null : new Paradigm (parse);
        }
    }
}