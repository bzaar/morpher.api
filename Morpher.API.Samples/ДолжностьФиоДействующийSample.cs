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
            var fio = Factory.Russian.Declension.Analyse(фио); // TODO: Category.FIO

            // Согласовать слово "действующий" по роду с ФИО.
            string действующий = fio.Gender.Get(new Действующий());

            var парадигмыСоставляющих = new []
                                            {
                                                Factory.Russian.Declension.Analyse(должность),
                                                fio,
                                                Factory.Russian.Declension.Analyse(действующий)
                                            };

            // Поставить все составляющие в нужный падеж.
            var составляющие = парадигмыСоставляющих.Select(@case.Get);

            return String.Format ("{0} {1}, {2}", составляющие.ToArray());
        }

        // Склонение по родам пока не реализовано.  Но для одного слова его несложно реализовать вручную:
        class Действующий : IGenderParadigm
        {
            string IGenderParadigm.Masculine  {get { return "действующий"; }}
            string IGenderParadigm.Feminine   {get { return "действующая"; }}
            string IGenderParadigm.Neuter     {get { return "действующее"; }}
            string IGenderParadigm.Plural     {get { return "действующие"; }}
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
