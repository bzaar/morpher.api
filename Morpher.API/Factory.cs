using System;

namespace Morpher
{
    public class RussianFactory
    {
        private readonly AppConfig.Factory factory;

        internal RussianFactory (AppConfig.Factory factory)
        {
            this.factory = factory;
        }

        public Russian.IDeclension Declension
        {
            get {return factory.GetInterface <Russian.IDeclension> ();}
        }

        public Russian.INumberSpelling NumberSpelling
        {
            get {return factory.GetInterface <Russian.INumberSpelling> (); }
        }

        public IGenericInterfaces<Russian.IParadigm> Generic 
        {
            get
            {
                return new GenericInterfaces();
            }
        }

        private class GenericInterfaces : IGenericInterfaces<Russian.IParadigm>
        {
            IDeclension<Russian.IParadigm> IGenericInterfaces<Russian.IParadigm>.Declension
            {
                get { throw new NotImplementedException (); }
            }

            INumberSpelling<Russian.IParadigm> IGenericInterfaces<Russian.IParadigm>.NumberSpelling
            {
                get { throw new NotImplementedException (); }
            }
        }
    }

    public interface IGenericInterfaces <TParadigm>
    {
        IDeclension<TParadigm> Declension {get;}
        INumberSpelling<TParadigm> NumberSpelling {get;}
    }

    public class UkranianFactory
    {
        private readonly AppConfig.Factory factory;

        internal UkranianFactory (AppConfig.Factory factory)
        {
            this.factory = factory;
        }

        public Ukrainian.IDeclension Declension
        {
            get {return factory.GetInterface <Ukrainian.IDeclension> ();}
        }

        public Ukrainian.INumberSpelling NumberSpelling
        {
            get {return factory.GetInterface <Ukrainian.INumberSpelling> (); }
        }

        public IGenericInterfaces<Russian.IParadigm> Generic 
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Factory
    {
        static readonly AppConfig.Factory factory = new AppConfig.Factory ();

        public static RussianFactory Russian
        {
            get {return new RussianFactory(factory);}
        }

        public static UkranianFactory Ukrainian
        {
            get {return new UkranianFactory(factory);}
        }
    }
}
