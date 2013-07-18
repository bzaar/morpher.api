using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morpher;

namespace AspNetSamples
{
    public partial class FacebookStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FlushingLiteral1.SetContent(RenderStory());

            this.FlushingLiteral1.SetResponse(Response);
        }

        static IEnumerable<string> RenderStory()
        {
            yield return "<table border=0 width='100%'>";

            var english   = TellStory(en, GetEnglishGrammar  ()).GetEnumerator();
            var russian   = TellStory(ru, GetRussianGrammar  ()).GetEnumerator();
            var ukrainian = TellStory(uk, GetUkrainianGrammar()).GetEnumerator();

            while (english.MoveNext() && russian.MoveNext() && ukrainian.MoveNext())
            {
                yield return "<tr>";

                yield return Td (english.Current);
                yield return Td (russian.Current);
                yield return Td (ukrainian.Current);

                yield return "</tr>";
            }

            yield return "</table>";

        }

        private static string Td (string s)
        {
            return "<td width='33%'>" + (s) + "</td>";
        }
    }
}
