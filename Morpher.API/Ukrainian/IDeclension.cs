namespace Morpher.Ukrainian
{
    public interface IDeclension
    {
        IParse Parse (string s, ParseArgs args = null);
    }
}