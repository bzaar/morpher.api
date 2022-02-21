using Morpher;
using Morpher.Generic;

public static class MorpherDynamicExtensions
{
    public static IDynamicDeclension AsDynamic <TParadigm> (this IDeclension <TParadigm> declension, TParadigm caseNames)
    {
        return new DynamicDeclension <TParadigm> (declension, caseNames);
    }

    public static IDynamicSpeller AsDynamic <TParadigm> (this INumberSpelling <TParadigm> numberSpelling, TParadigm caseNames)
    {
        return new DynamicSpeller <TParadigm> (numberSpelling, caseNames);
    }
}