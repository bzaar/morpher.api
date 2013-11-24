using System;
using System.Text;
using Morpher.Generic;

namespace Morpher.API.Samples
{
    class ДенежнаяЕдиница 
    {
        public string ПолноеНаименованиеЦелойЧасти {get; set;}
        public string ПолноеНаименованиеДробнойЧасти {get; set;}
        public string СокращенноеНаименованиеЦелойЧасти {get; set;}
        public string СокращенноеНаименованиеДробнойЧасти {get; set;}

        public string СуммаПрописью (decimal summa, ISpeller language)
        {
            var sb = new StringBuilder ();

            sb.Append (summa.ToString ("N2"));
            sb.Append (' ');
            sb.Append (СокращенноеНаименованиеЦелойЧасти);
            sb.Append (' ');
            sb.Append ('(');
            int i = sb.Length; // запомнить позицию первой буквы прописи
            sb.Append (Прописью (Math.Floor (summa), ПолноеНаименованиеЦелойЧасти, language));
            sb.Append (' ');
            sb.Append (Цифрами (summa * 100 % 100, ПолноеНаименованиеДробнойЧасти, language));
            sb.Append (')');

            sb [i] = char.ToUpper (sb [i]); // сделать первую букву прописи заглавной

            return sb.ToString ();
        }

        static string Прописью (decimal n, string unit, ISpeller language)
        {
            return language.Spell (n, ref unit) + " " + unit;
        } 

        static string Цифрами (decimal n, string unit, ISpeller language)
        {
            language.Spell (n, ref unit);
            return n.ToString ("00") + " " + unit;
        } 
    }
}