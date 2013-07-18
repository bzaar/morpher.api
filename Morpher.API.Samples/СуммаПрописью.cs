using System;

namespace Morpher.API.Samples
{
    class СуммаПрописью
    {
        public static void СуммаПрописьюНаРазныхЯзыках <TParadigm> (INumberSpelling <TParadigm> language, ДенежнаяЕдиница денежнаяЕдиница, ICase <TParadigm> @case) 
        {
            Console.WriteLine (денежнаяЕдиница.СуммаПрописью (100m, language.AddCase (@case)));
        }
    }
}
