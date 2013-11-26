namespace Morpher.Ukrainian
{
    public class UkrainianInitials : IParadigm
    {
#pragma warning disable 1591
        public string Nominative    {get { return "Н"; }}
        public string Genitive      {get { return "Р"; }}
        public string Dative        {get { return "Д"; }}
        public string Accusative    {get { return "З"; }}
        public string Instrumental  {get { return "О"; }}
        public string Prepositional {get { return "М"; }}
        public string Vocative      {get { return "К"; }}
#pragma warning restore 1591
    }
}