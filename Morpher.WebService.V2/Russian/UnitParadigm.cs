using Morpher.WebService.V2.MorpherWebService;

namespace Morpher.Russian
{
    class UnitParadigm : Paradigm
    {
        private readonly Forms forms;

        public UnitParadigm (Forms forms) : base (forms.И)
        {
            this.forms = forms;
        }

        protected override Forms Forms
        {
            get { return forms; }
        }

        protected override string Locative
        {
            get { return forms.П; } // Совпадает с предложным.
        }
    }
}