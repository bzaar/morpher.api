using Morpher.Generic;

namespace Morpher
{
    public class DynamicDeclension <TParadigm> : IDynamicDeclension
    {
        readonly IDeclension<TParadigm> inner;
        readonly CaseParser<TParadigm> caseParser;

        public DynamicDeclension (IDeclension <TParadigm> inner, TParadigm caseNames)
        {
            this.inner = inner;
            this.caseParser = new CaseParser <TParadigm> (inner.Cases, caseNames);
        }

        public string GetCase (string phrase, string @case)
        {
            var fullParadigm = inner.Parse (phrase);

            if (fullParadigm == null) return null;

            var singular = fullParadigm.Singular;

            if (singular.Equals (default (TParadigm))) return null;

            return singular.Get (caseParser.Parse (@case));
        }
    }
}
