using Morpher.Russian;

namespace Morpher.Generic.Russian
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
            get { return paradigm.Plural; }
        }
    }
}