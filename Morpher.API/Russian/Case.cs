using System;
using System.Collections.Generic;

namespace Morpher.Russian
{
    public class Case : ICase <IParadigm>
    {
        private readonly Func <IParadigm, string> func;

        Case (Func<IParadigm, string> func)
        {
            this.func = func;
        }

        public string Get (IParadigm paradigm)
        {
            return func (paradigm);
        }

        public static Case Nominative    = new Case(p => p.Nominative   );
        public static Case Genitive      = new Case(p => p.Genitive     );
        public static Case Dative        = new Case(p => p.Dative       );
        public static Case Accusative    = new Case(p => p.Accusative   );
        public static Case Instrumental  = new Case(p => p.Instrumental );
        public static Case Prepositional = new Case(p => p.Prepositional);
        public static Case Locative      = new Case(p => p.Locative     );

        public static IEnumerable<ICase<IParadigm>> All
        {
            get
            {
                yield return Nominative   ;
                yield return Genitive     ;
                yield return Dative       ;
                yield return Accusative   ;
                yield return Instrumental ;
                yield return Prepositional;
                yield return Locative     ;
            }
        }
    }
}