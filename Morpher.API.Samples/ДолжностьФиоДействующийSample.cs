using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpher.Russian;

namespace Morpher.API.Samples
{
    [TestClass]
    public class ДолжностьФиоДействующийSample
    {
        /// <summary>
        /// Строит строку вида "должность ФИО, действующий..." в заданном падеже,
        /// согласуя слово "действующий" с родом ФИО.
        /// </summary>
        static string ДолжностьФиоДействующий (string должность, string фио, Case @case)
        {
            // Получить объект IDeclension, при помощи которого будем склонять.
            var declension = Factory.Russian.Declension;

            // Указание категории Name (имя человека) необязательно, 
            // но помогает программе в сложных случаях типа Любовь - Любови или Любви?
            var fio = declension.Parse (фио, Category.Name);

            // Согласовать слово "действующий" по роду с ФИО.
            string действующий = fio.Gender.Get(new Действующий());

            var составляющие = new [] {declension.Parse(должность), fio, declension.Parse(действующий)};

            // Поставить все составляющие в нужный падеж и расставить знаки препинания.
            return String.Format ("{0} {1}, {2}", составляющие.Select(@case.Get).ToArray());
        }

        // Склонение по родам пока не реализовано.  Но для одного слова его несложно реализовать вручную:
        class Действующий : IGenderParadigm<string>
        {
            public string Masculine  {get { return "действующий"; }}
            public string Feminine   {get { return "действующая"; }}
            public string Neuter     {get { return "действующее"; }}
            public string Plural     {get { return "действующие"; }}
        }

        [TestMethod]
        public void TestMethod1()
        {
            string s = ДолжностьФиоДействующий ("директор по маркетингу", "Самохвалов Юрий Геннадьевич", Case.Dative);

            Assert.AreEqual("директору по маркетингу Самохвалову Юрию Геннадьевичу, действующему", s);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string s = ДолжностьФиоДействующий ("директор по маркетингу", "Самохвалов Ю.Г.", Case.Dative);

            Assert.AreEqual("директору по маркетингу Самохвалову Ю.Г., действующему", s);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string s = ДолжностьФиоДействующий ("завскладом", "Винокур Борис Глебович", Case.Dative);

            Assert.AreEqual("завскладом Винокуру Борису Глебовичу, действующему", s);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string s = ДолжностьФиоДействующий ("гражданин РФ", "Слепов Сергей Николаевич", Case.Nominative);

            Assert.AreEqual("гражданин РФ Слепов Сергей Николаевич, действующий", s);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string s = ДолжностьФиоДействующий ("и.о. вождя пролетариата", "Крупская Надежда Константиновна", Case.Dative);

            Assert.AreEqual("и.о. вождя пролетариата Крупской Надежде Константиновне, действующей", s);
        }
    }
}
