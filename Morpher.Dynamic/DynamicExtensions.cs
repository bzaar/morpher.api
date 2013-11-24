using Morpher;
using Morpher.Generic;

public static class DynamicExtensions
{
    public static IDynamicDeclension AsDynamic <TParadigm> (this IDeclension <TParadigm> declension, TParadigm caseNames)
    {
        return new DynamicDeclension <TParadigm> (declension, caseNames);
    }
}