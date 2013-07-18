using System;
using Morpher.MorpherWebService;

namespace Morpher.Russian
{
    class FullParadigm : Paradigm, IFullParadigm
    {
        private readonly GetXmlResult result;

        public FullParadigm (GetXmlResult result, string lemma) : base (lemma)
        {
            this.result = result;
        }

        IGender IFullParadigm.Gender
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

        IParadigm IFullParadigm.Plural
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

        bool IFullParadigm.IsAnimate
        {
            get { throw new NotImplementedException (); }
        }
    }
}