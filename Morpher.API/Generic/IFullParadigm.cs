namespace Morpher.Generic
{
    public interface IFullParadigm <TParadigm>
    {
        TParadigm Singular {get;}
        TParadigm Plural   {get;}
    }
}