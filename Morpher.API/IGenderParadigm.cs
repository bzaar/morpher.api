namespace Morpher
{
    public interface IGenderParadigm <out T>
    {
        T Masculine {get;}
        T Feminine  {get;}
        T Neuter    {get;}
        T Plural    {get;}
    }
}