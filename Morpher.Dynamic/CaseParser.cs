using System.Collections.Generic;
using System.Linq;

namespace Morpher
{
    public class CaseParser <TParadigm>
    {
        readonly Dictionary <string, ICase <TParadigm>> caseNames;

        public CaseParser (IEnumerable <ICase <TParadigm>> cases, TParadigm names)
        {
            caseNames = cases.ToDictionary (@case => names.Get (@case));
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