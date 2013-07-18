using System;
using Morpher.MorpherWebService;

namespace Morpher.Ukrainian
{
    class FullParadigm : IFullParadigm
    {
        private readonly GetXmlUkrResult result;
        private readonly string lemma;

        public FullParadigm (GetXmlUkrResult result, string lemma)
        {
            this.result = result;
            this.lemma = lemma;
        }

        Gender IFullParadigm.Gender
        {
            get { throw new NotImplementedException (); }
        }

        string IParadigm.Vocative
        {
            get { return result.К; }
        }

        string ISlavicParadigm.Nominative
        {
            get { return lemma; }
        }

        string ISlavicParadigm.Genitive
        {
            get { return result.Р; }
        }

        string ISlavicParadigm.Dative
        {
            get { return result.Д; }
        }

        string ISlavicParadigm.Accusative
        {
            get { return result.З; }
        }

        string ISlavicParadigm.Instrumental
        {
            get { return result.О; }
        }

        string ISlavicParadigm.Prepositional
        {
            get { return result.М; }
        }
    }
}