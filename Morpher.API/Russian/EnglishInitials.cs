namespace Morpher.Russian
{
    public class EnglishInitials : IParadigm
    {
        public string Nominative    {get { return "N"; }}
        public string Genitive      {get { return "G"; }}
        public string Dative        {get { return "D"; }}
        public string Accusative    {get { return "A"; }}
        public string Instrumental  {get { return "I"; }}
        public string Prepositional {get { return "P"; }}
        public string Locative      {get { return "L"; }}
    }
}