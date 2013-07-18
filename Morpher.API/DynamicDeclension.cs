using System.Collections.Generic;
using System.Linq;

namespace Morpher
{
    public interface IDynamicDeclension
    {
        string GetCase (string phrase, string @case);
    }

    public class DynamicDeclension <TParadigm> : IDynamicDeclension
    {
        readonly IDeclension<TParadigm> inner;
        readonly CaseParser<TParadigm> caseParser;

        public DynamicDeclension (IDeclension <TParadigm> inner, TParadigm caseNames)
        {
            this.inner = inner;
            this.caseParser = new CaseParser <TParadigm> (inner, caseNames);
        }

        public string GetCase(string phrase, string @case)
        {
            var fullParadigm = inner.Analyse (phrase);

            if (fullParadigm == null) return null;

            var singular = fullParadigm.Singular;

            if (singular.Equals (default (TParadigm))) return null;

            return singular.Get (caseParser.Parse (@case));
        }
    }

    public class CaseParser <TParadigm>
    {
        readonly Dictionary <string, ICase <TParadigm>> caseNames;

        public CaseParser (ILanguage <TParadigm> language, TParadigm names)
        {
            caseNames = language.Cases.ToDictionary (@case => names.Get (@case));
        }

        public bool TryParse (string s, out ICase<TParadigm> @case)
        {
            return caseNames.TryGetValue (s, out @case);
        }

        public ICase <TParadigm> Parse (string s)
        {
            ICase <TParadigm> @case;

            TryParse (s, out @case);

            return @case;
        }
    }
}
