using System;
using System.Collections.Generic;
using System.Linq;
using Morpher.Generic;

namespace Morpher.API.Samples
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine (Factory.Russian.Declension.Parse("генеральный директор").Dative);

            // Склоняем на разных языках одной и той же функцией:
            PrintAll (GetAllCases (Factory.Russian.Declension.AsGeneric(), "кот"));
            PrintAll (GetAllCases (Factory.Ukrainian.Declension.AsGeneric(), "кіт"));

            GetAllCases (Factory.Russian.NumberSpelling.AsGeneric(), 38, "попугай");
            GetAllCases (Factory.Ukrainian.NumberSpelling.AsGeneric(), 38, "попугай");

            var uk = Factory.Ukrainian.NumberSpelling.AsGeneric();
            var рубли = new ДенежнаяЕдиница {
                                               ПолноеНаименованиеЦелойЧасти = "рубль",
                                               ПолноеНаименованиеДробнойЧасти = "копейка",
                                               СокращенноеНаименованиеЦелойЧасти = "руб."
                                            };
            var евро = new ДенежнаяЕдиница {
                                               ПолноеНаименованиеЦелойЧасти = "евро",
                                               ПолноеНаименованиеДробнойЧасти = "цент",
                                               СокращенноеНаименованиеЦелойЧасти = "евро"
                                           };

            СуммаПрописью.СуммаПрописьюНаРазныхЯзыках (Factory.Russian.NumberSpelling.AsGeneric(), рубли, Russian.Case.Prepositional);
        }



        private static IEnumerable <string> GetAllCases <TParadigm> (IDeclension <TParadigm> lang, string s)
        {
            var analysed = lang.Parse(s);

            return lang.Cases.Select(c => analysed.Singular.Get(c));
        }

        private static void PrintAll (IEnumerable <string> cases)
        {
            cases.ToList().ForEach(Console.WriteLine);
        }

        static void GetAllCases <TParadigm> (INumberSpelling <TParadigm> lang, decimal n, string unit)
        {
            PrintAll (lang.Cases.Select (c => Spell (lang, n, unit, c)));
        }

        static string Spell <TParadigm> (INumberSpelling <TParadigm> lang, decimal n, string unit, ICase <TParadigm> @case)
        {
            return lang.Spell(n, ref unit, @case) + " " + unit;
        }
    }
}
