using Morpher.Ukrainian;

namespace Morpher.Generic.Ukrainian
{
    class Paradigm : IFullParadigm <IParadigm>
    {
        private readonly IParse paradigm;

        public Paradigm (IParse paradigm)
        {
            this.paradigm = paradigm;
        }

        IParadigm IFullParadigm<IParadigm>.Singular
        {
            get { return paradigm; }
        }

        IParadigm IFullParadigm<IParadigm>.Plural
        {
            get { throw new System.NotImplementedException ("Множественное число пока не реализовано для украинского."); }
        }
    }
}