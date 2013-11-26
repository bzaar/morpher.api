using System.Collections.Generic;
using System.Linq;
using Morpher.Generic;

namespace Morpher
{
    public class CaseParser <TParadigm>
    {
        readonly Dictionary <string, ICase <TParadigm>> caseNames;

        public CaseParser (ILanguage <TParadigm> language, TParadigm names)
        {
            caseNames = language.Cases.ToDictionary (@case => names.Get (@case));
        }

        public bool TryParse (string s, out ICase <TParadigm> @case)
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