using System;

namespace Morpher
{
    public class Gender 
    {
        readonly Func <IGenderParadigm, string> func;

        Gender (Func <IGenderParadigm, string> func)
        {
            this.func = func;
        }

        public string Get (IGenderParadigm paradigm)
        {
            return func (paradigm);
        }

        public static Gender Masculine = new Gender (p => p.Masculine);
        public static Gender Feminine  = new Gender (p => p.Feminine);
        public static Gender Neuter    = new Gender (p => p.Neuter);
        public static Gender Plural    = new Gender (p => p.Plural);
    }
}

