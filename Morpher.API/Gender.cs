namespace Morpher
{
    public abstract class Gender 
    {
        public abstract T Get <T> (IGenderParadigm<T> p);

        class _Masculine : Gender
        {
            public override T Get <T> (IGenderParadigm<T> p)
            {
                return p.Masculine;
            }
        }

        class _Feminine : Gender
        {
            public override T Get <T> (IGenderParadigm<T> p)
            {
                return p.Feminine;
            }
        }

        class _Neuter : Gender
        {
            public override T Get <T> (IGenderParadigm<T> p)
            {
                return p.Neuter;
            }
        }

        class _Plural : Gender
        {
            public override T Get <T> (IGenderParadigm<T> p)
            {
                return p.Masculine;
            }
        }

        public static Gender Masculine = new _Masculine ();
        public static Gender Feminine  = new _Feminine ();
        public static Gender Neuter    = new _Neuter ();
        public static Gender Plural    = new _Plural ();
    }
}



