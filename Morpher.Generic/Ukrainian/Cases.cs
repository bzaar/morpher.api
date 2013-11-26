using System.Collections.Generic;

namespace Morpher.Ukrainian
{
    public class Cases
    {
        public static IEnumerable<ICase<IParadigm>> AllCases
        {
            get
            {
                yield return Case.Nominative   ;
                yield return Case.Genitive     ;
                yield return Case.Dative       ;
                yield return Case.Accusative   ;
                yield return Case.Instrumental ;
                yield return Case.Prepositional;
                yield return Case.Vocative     ;
            }
        }
    }
}