using System.Collections.Generic;
using Morpher.Ukrainian;

namespace Morpher.Generic.Ukrainian
{
    class Language : ILanguage <IParadigm>
    {
        IEnumerable<ICase<IParadigm>> ILanguage<IParadigm>.Cases
        {
            get { return Case.All; }
        }

        ICase<IParadigm> ILanguage<IParadigm>.Nominative
        {
            get { return Case.Nominative; }
        }
    }
}