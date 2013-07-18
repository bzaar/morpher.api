using Morpher.MorpherWebService;

namespace Morpher.Russian
{
    abstract class Paradigm : IParadigm
    {
        private readonly string lemma;

        protected Paradigm (string lemma)
        {
            this.lemma = lemma;
        }

        protected abstract Forms Forms {get;}
        protected abstract string Locative {get;}

        string IParadigm.Locative
        {
            get { return Locative; }
        }

        string ISlavicParadigm.Nominative
        {
            get { return lemma; }
        }

        string ISlavicParadigm.Genitive
        {
            get { return Forms.Р; }
        }

        string ISlavicParadigm.Dative
        {
            get { return Forms.Д; }
        }

        string ISlavicParadigm.Accusative
        {
            get { return Forms.В; }
        }

        string ISlavicParadigm.Instrumental
        {
            get { return Forms.Т; }
        }

        string ISlavicParadigm.Prepositional
        {
            get { return Forms.П; }
        }
       
    }
}