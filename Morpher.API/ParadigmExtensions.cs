namespace Morpher
{
    public static class ParadigmExtensions
    {
        public static string Get <TParidigm> (this TParidigm paridigm, ICase <TParidigm> @case)
        {
            return @case.Get (paridigm);
        }
    }
}