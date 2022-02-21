using System.Collections.Generic;
using Morpher.Russian;

namespace Morpher.Generic.Russian
{
    class Language : ILanguage <IParadigm>
    {
        IEnumerable<ICase<IParadigm>> ILanguage <IParadigm>.Cases
        {
            get { return Cases.AllCases; }
        }

        ICase<IParadigm> ILanguage <IParadigm>.Nominative
        {
            get { return Case.Nominative; }
        }
    }
}