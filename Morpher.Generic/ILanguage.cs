using System.Collections.Generic;

namespace Morpher.Generic
{
    public interface ILanguage <TParadigm> 
    {
        IEnumerable <ICase <TParadigm>> Cases {get;}

        ICase <TParadigm> Nominative {get;}
    }
}