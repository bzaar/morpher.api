namespace Morpher.Russian
{
    public static class IDeclensionExtensions
    {
        public static IParse Parse (this IDeclension declension, string s, Category category)
        {
            return declension.Parse (s, new ParseArgs {Category = category});
        }
    }
}