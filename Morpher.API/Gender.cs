using System;

namespace Morpher
{
    public class Gender : IGender
    {
        private readonly Func <IGenderParadigm, string> func;

        private Gender (Func<IGenderParadigm, string> func)
        {
            this.func = func;
        }

        string IGender.Get (IGenderParadigm paradigm)
        {
            return func (paradigm);
        }

        public static IGender Masculine = new Gender (p => p.Masculine);
        public static IGender Feminine  = new Gender (p => p.Feminine);
        public static IGender Neuter    = new Gender (p => p.Neuter);
        public static IGender Plural    = new Gender (p => p.Plural);
    }
}

