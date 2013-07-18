using Morpher;

public static class MorpherExtensions
{
    public static IDeclension<Morpher.Russian.IParadigm> AsGeneric (this Morpher.Russian.IDeclension declension)
    {
        return new Morpher.Russian.GenericDeclension (declension);
    }

    public static IDeclension<Morpher.Ukrainian.IParadigm> AsGeneric (this Morpher.Ukrainian.IDeclension declension)
    {
        return new Morpher.Ukrainian.GenericDeclension (declension);
    }

    public static INumberSpelling<Morpher.Russian.IParadigm> AsGeneric (this Morpher.Russian.INumberSpelling numberSpelling)
    {
        return new Morpher.Russian.GenericNumberSpelling (numberSpelling);
    }

    public static INumberSpelling<Morpher.Ukrainian.IParadigm> AsGeneric (this Morpher.Ukrainian.INumberSpelling numberSpelling)
    {
        return new Morpher.Ukrainian.GenericNumberSpelling (numberSpelling);
    }

    public static IDynamicDeclension AsDynamic <TParadigm> (this IDeclension <TParadigm> declension, TParadigm caseNames)
    {
        return new DynamicDeclension <TParadigm> (declension, caseNames);
    }
}
