using Morpher.Generic;

namespace Morpher.Russian.Tests
{
    public class DynamicSpeller <TParadigm> : IDynamicSpeller
    {
        private readonly INumberSpelling <TParadigm> genericSpeller;
        readonly CaseParser<TParadigm> caseParser;

        public DynamicSpeller (INumberSpelling<TParadigm> genericSpeller, TParadigm caseNames)
        {
            this.genericSpeller = genericSpeller;
            this.caseParser = new CaseParser <TParadigm> (genericSpeller, caseNames);
        }

        string IDynamicSpeller.Spell(decimal n, ref string unit, string @case)
        {
            return genericSpeller.AddCase (caseParser.Parse (@case)).Spell (n, ref unit);
        }
    }
}