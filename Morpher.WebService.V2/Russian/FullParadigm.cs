using System;
using Morpher.WebService.V2.MorpherWebService;

namespace Morpher.Russian
{
    class Parse : Paradigm, IParse
    {
        private readonly GetXmlResult result;

        public Parse (GetXmlResult result, string lemma) : base (lemma)
        {
            this.result = result;
        }

        IGender IParse.Gender
        {
            get 
            {
                switch (result.род)
                {
                    case "Мужской": return Gender.Masculine;      
                    case "Женский": return Gender.Feminine;      
                    case "Средний": return Gender.Neuter;      
                    case "": return Gender.Plural;      
                } 

                throw new ApplicationException("Веб-сервис вернул неожиданное значение рода: " + result.род);
            }
        }

        IParadigm IParse.Plural
        {
            get { throw new NotImplementedException (); }
        }

        protected override Forms Forms
        {
            get { return result; }
        }

        protected override string Locative
        {
            get { return result.где; }
        }

        bool IParse.IsAnimate
        {
            get { throw new NotImplementedException (); }
        }

        string IParse.Paucal
        {
            get { throw new NotImplementedException (); }
        }
    }
}