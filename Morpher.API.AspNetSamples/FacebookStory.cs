using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AspNetSamples
{
    partial class FacebookStory
    {
        private static readonly Dictionary <string, string> en = new Dictionary <string, string> ();
        private static readonly Dictionary <string, string> ru = new Dictionary <string, string> ();
        private static readonly Dictionary <string, string> uk = new Dictionary <string, string> ();

        static FacebookStory ()
        {
            en.Add ("title", "A FACEBOOK STORY");
            ru.Add ("title", "ИСТОРИЯ НА ФЕЙСБУКЕ");
            uk.Add ("title", "ІСТОРІЯ НА ФЕЙСБУЦІ");

            // THE CAST
            en.Add ("bob", "Bob");  en.Add ("alice", "Alice");
            ru.Add ("bob", "Боб");  ru.Add ("alice", "Алиса");
            uk.Add ("bob", "Боб");  uk.Add ("alice", "Аліса");

            en.Add ("celebrity", "Brad Pitt");
            ru.Add ("celebrity", "Брэд Питт");
            uk.Add ("celebrity", "Бред Пітт");

            en.Add ("photo", "photo");
            ru.Add ("photo", "фотография");
            uk.Add ("photo", "фотографія");

            en.Add ("likes", "<{0}> likes <{1}>.");
            ru.Add ("likes", "<{0}:Д> нравится <{1}>.");
            uk.Add ("likes", "<{0}:Д> подобається <{1}>.");

            en.Add ("likes2", "<{0}> likes <{1}:possessive> <{2}>.");
            ru.Add ("likes2", "<{0}:Д> нравится <{2}> <{1}:Р>.");
            uk.Add ("likes2", "<{0}:Д> подобається <{2}> <{1}:Р>.");

            en.Add ("commented", "<{0}> has commented on <{1}:possessive> <{2}>.");
            ru.Add ("commented", "<{0}> прокомментировал <{2}:В> <{1}:Р>.");
            uk.Add ("commented", "<{0}> прокоментував <{2}:З> <{1}:Р>.");

            en.Add ("emailed", "<{0}> has sent <{1}> an email.");
            ru.Add ("emailed", "<{0}> послал <{1}:Д> письмо.");
            uk.Add ("emailed", "<{0}> послав <{1}:Д> лист.");
        }

        /// <summary> Tells the story in the chosen language. </summary>
        static IEnumerable<string> TellStory (Dictionary <string, string> dict, Morpher.IDynamicDeclension grammar)
        {
            // THE PLOT. See if you can read the story from it!
            var story = new [] 
            {
                new {Verb = "title",     Actors = ""},
                new {Verb = "likes2",    Actors = "bob,alice,photo"},
                new {Verb = "commented", Actors = "bob,alice,photo"},
                new {Verb = "emailed",   Actors = "bob,alice"},
                new {Verb = "likes",     Actors = "bob,alice"},
                new {Verb = "likes",     Actors = "alice,celebrity"},
            };

            return story.Select (sentence => Regex.Replace (
                string.Format (dict [sentence.Verb], sentence.Actors.Split (',')), 
                @"<(?<id>\w*)(:(?<format>\w*))?>",
                match => GetDeclension (dict [match.Groups ["id"].Value], match.Groups ["format"].Value, grammar)));
        }

        static Morpher.IDynamicDeclension GetEnglishGrammar ()
        {
            return new EnglishGrammar ();
        }

        static Morpher.IDynamicDeclension GetRussianGrammar ()
        {
            var caseNames = new Morpher.Russian.RussianInitials(); // Use Russian initials to identify cases.
            return Morpher.Factory.Russian.Declension.AsGeneric().AsDynamic(caseNames);
        }

        static Morpher.IDynamicDeclension GetUkrainianGrammar ()
        {
            var caseNames = new Morpher.Ukrainian.UkrainianInitials(); // Use Ukrainian initials to identify cases.
            return Morpher.Factory.Ukrainian.Declension.AsGeneric().AsDynamic(caseNames);
        }

        // Английская грамматика не является частью Morpher.API.dll.  
        // Здесь приведена тривиальная реализация для демонстрации расширяемости библиотеки.
        class EnglishGrammar : Morpher.IDynamicDeclension
        {
            public string GetCase (string s, string @case)
            {
                if (@case == "possessive") s += "'s";
                // TODO: drop the s for plurals and Jesus; see 
                // http://www.englishclub.com/grammar/nouns-possessive.htm
                return s;
            }
        }

        private static string GetDeclension (string s, string format, Morpher.IDynamicDeclension morpher)
        {
            return Bold (string.IsNullOrEmpty (format) ? s : morpher.GetCase (s, format));
        }

        static string Bold (string s)
        {
            return "<b>" + s + "</b>";
        }
    }
}
