using Morpher.Generic;

public static class MorpherGenericExtensions
{
    public static IDeclension<Morpher.Russian.IParadigm> AsGeneric (this Morpher.Russian.IDeclension declension)
    {
        return new Morpher.Generic.Russian.Declension (declension);
    }

    public static IDeclension<Morpher.Ukrainian.IParadigm> AsGeneric (this Morpher.Ukrainian.IDeclension declension)
    {
        return new Morpher.Generic.Ukrainian.Declension (declension);
    }

    public static INumberSpelling<Morpher.Russian.IParadigm> AsGeneric (this Morpher.Russian.INumberSpelling numberSpelling)
    {
        return new Morpher.Generic.Russian.NumberSpelling (numberSpelling);
    }

    public static INumberSpelling<Morpher.Ukrainian.IParadigm> AsGeneric (this Morpher.Ukrainian.INumberSpelling numberSpelling)
    {
        return new Morpher.Generic.Ukrainian.NumberSpelling (numberSpelling);
    }
}