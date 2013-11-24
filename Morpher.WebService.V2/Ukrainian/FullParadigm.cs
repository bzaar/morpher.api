using System;
using Morpher.WebService.V2.MorpherWebService;

namespace Morpher.Ukrainian
{
    class Parse : IParse
    {
        private readonly GetXmlUkrResult result;
        private readonly string lemma;

        public Parse (GetXmlUkrResult result, string lemma)
        {
            this.result = result;
            this.lemma = lemma;
        }

        Gender IParse.Gender
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