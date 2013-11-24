using Morpher.WebService.V2.MorpherWebService;

namespace Morpher.Ukrainian
{
    class Paradigm : IParadigm
    {
        private readonly FormsUkr forms;

        public Paradigm (FormsUkr forms)
        {
            this.forms = forms;
        }

        FormsUkr Forms {get {return forms;}}

        string ISlavicParadigm.Nominative
        {
            get { return Forms.Н; }
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
            get { return Forms.З; }
        }

        string ISlavicParadigm.Instrumental
        {
            get { return Forms.О; }
        }

        string ISlavicParadigm.Prepositional
        {
            get { return Forms.М; }
        }

        string IParadigm.Vocative
        {
            get { return Forms.К; }
        }
    }
}