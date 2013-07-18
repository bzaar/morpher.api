using System.Collections.Generic;

namespace Morpher.Ukrainian
{
    class Language : ILanguage<IParadigm>
    {
        IEnumerable<ICase<IParadigm>> ILanguage<IParadigm>.Cases
        {
            get { return Case.All; }
        }

        ICase<IParadigm> ILanguage<IParadigm>.Nominative
        {
            get { return Case.Nominative; }
        }
    }

    class GenericDeclension : Language, IDeclension<IParadigm>
    {
        private readonly IDeclension declension;

        public GenericDeclension (IDeclension declension)
        {
            this.declension = declension;
        }

        IFullParadigm<IParadigm> IDeclension<IParadigm>.Analyse(string s)
        {
            var fullParadigm = declension.Analyse (s);
            return fullParadigm == null ? null : new GenericParadigm (fullParadigm);
        }
    }

    class GenericParadigm : IFullParadigm<IParadigm>
    {
        private readonly IFullParadigm paradigm;

        public GenericParadigm (IFullParadigm paradigm)
        {
            this.paradigm = paradigm;
        }

        IParadigm IFullParadigm<IParadigm>.Singular
        {
            get { return paradigm; }
        }

        IParadigm IFullParadigm<IParadigm>.Plural
        {
            get { throw new System.NotImplementedException ("Множественное число пока не реализовано для украинского."); }
        }
    }
}