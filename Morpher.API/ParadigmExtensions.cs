namespace Morpher
{
    public static class ParadigmExtensions
    {
        /// <summary>
        /// Возвращает форму указанного падежа <paramref name="@case"/>.
        /// </summary>
        public static string Get <TParidigm> (this TParidigm paridigm, ICase <TParidigm> @case)
        {
            return @case.Get (paridigm);
        }
    }
}